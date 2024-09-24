using System.ComponentModel.DataAnnotations.Schema;


namespace MyFootball
{
    public class Match
    {
        public Match(int homeTeamId, int awayTeamId)
        {
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
        }

        public Match() { }

        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public DateTime DateTime { get; set; }

        public Stadium Stadium { get; set; }
        public int StadiumId { get; set; }

        public int TicketCoast { get; set; }

        public bool IsFinished { get; set; }

        public void AssignResult(int homeTeamScore, int awayTeamScore)
        {
            IsFinished = true;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public string? City { get; set; }

        public int? CoachId { get; set; }
        public Coach? Coach { get; set; }

        public int? LastSeasonPlace { get; set; }

        public int? StadiumId { get; set; }
        public Stadium? Stadium { get; set; }

        //статистика
        public int? Points { get; set; }

        [NotMapped]
        public int WinCount { get; set; }
        [NotMapped]
        public int DrawCount { get; set; }
        [NotMapped]
        public int LoseCount { get; set; }  
        
        public bool TakePartInMatch(Match match)
        {
            return Id == match.HomeTeamId || Id == match.AwayTeamId;
        }
    }

    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Number { get; set; }
        public Position Position { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }

    public enum Position//выпадающий список
    {
        Вратарь,
        Защитник,
        Полузащитник,
        Нападающий
    }

    public class Season//нужен только подготовки данных для сезона
    {
        public int Id { get; set; }
        public DateTime currentDate { get; set; }
        public int StartTicketPrice { get; set; }
        public TimeOnly DefaultStartMatch { get; set; }
        public DateTime startSeason { get; set; }
        public DateTime endSeason { get; set; }
        public int MatchesCount;

        public Season() { }

        public Season(int startTicketPrice, TimeOnly defaultStartMatch, DateTime startSeason, DateTime endSeason)
        {
            StartTicketPrice = startTicketPrice;
            DefaultStartMatch = defaultStartMatch;
            this.startSeason = startSeason;
            this.endSeason = endSeason;
            currentDate = startSeason;
        }

        public void CreateSeason()//обязательно изначально должны быть заданы поля у объета
        {
            var period = (endSeason-startSeason).TotalDays;

            var matches = new List<Match>();

            var teams = TeamRepository.GetTeams();
            var teamsCount = teams.Count;
            var tourGameCount = teams.Count / 2;
            MatchesCount = (teamsCount * (teamsCount - 1));//количество размещений по 2 

            var tourCount = MatchesCount / tourGameCount;
            var tourPeriod = Convert.ToInt32(period / tourCount);

            for (int i = 0; i < teams.Count; i++)//первый круг
            {
                for (int j = i+1; j < teams.Count; j++)
                {
                    var team1 = teams[i];
                    var team2 = teams[j];
                    matches.Add(new Match() { HomeTeamId = team1.Id, AwayTeamId = team2.Id, StadiumId = team1.Stadium.Id });
                }
            }
            for (int i = 0; i < teams.Count; i++)//второй круг
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    var team1 = teams[i];
                    var team2 = teams[j];
                    matches.Add(new Match() { HomeTeamId = team2.Id, AwayTeamId = team1.Id, StadiumId = team2.Stadium.Id });
                }
            }

            var date = startSeason;
            for (int i = 0; i < tourCount; i++)
            {
                var tour = new List<Match>();
                var tourTakenTeam = new List<int>();  
                while(tour.Count<tourGameCount)
                {
                    var match = (matches.First(m=>!tourTakenTeam.Contains(m.HomeTeamId)&& !tourTakenTeam.Contains(m.AwayTeamId)));
                    tour.Add(match);
                    matches.Remove(match);
                    tourTakenTeam.Add(match.HomeTeamId);
                    tourTakenTeam.Add(match.AwayTeamId);
                }
                foreach (var match in tour)
                {
                    match.DateTime = new DateTime(date.Year, date.Month, date.Day, 18, 0, 0);
                    //MatchRepository.Add(match);
                }
                date = date.AddDays(tourPeriod);
            }
        }
    }
}
