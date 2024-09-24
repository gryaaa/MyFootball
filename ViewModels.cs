using MyFootball.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball
{
    [NotMapped]
    public class MatchViewModel 
    {
        private readonly Match Match;
        public MatchViewModel(Match match)
        {
            Match = match;
            HomeTeam = TeamRepository.FindTeamById(match.HomeTeamId);
            AwayTeam = TeamRepository.FindTeamById(match.AwayTeamId);
        }
        public MatchViewModel() { }

        public int Id { get { return Match.Id; } }
        public string HomeTeamName { get { return HomeTeam.Name; } }
        public string AwayTeamName { get { return AwayTeam.Name; } }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }//2 поля команд прежде всего связаны с нежеланием делать для матча списка команд и производить договоренность 
        public Stadium Stadium { get { return Match.Stadium; } }

        public int? HomeTeamScore
        {
            get { return Match.HomeTeamScore; }
            set { Match.HomeTeamScore = value;}
        }
        public int? AwayTeamScore
        {
            get { return Match.AwayTeamScore; }
            set { Match.AwayTeamScore = value;}
        }
        public DateTime DateTime
        {
            get { return Match.DateTime; }
            set { Match.DateTime = value; MatchRepository.Update(Match); }
        }

        public int TicketCoast 
        { 
            get
            {
                double result = 10.0 / Convert.ToDouble(HomeTeam.LastSeasonPlace + AwayTeam.LastSeasonPlace) * (10000.0 / Stadium.Capacity) * 1000;
                return (Convert.ToInt32(result) / 10) * 10;
            } 
        }
        public bool IsFinished { get { return Match.IsFinished; } }
        public void AssignResult(int homeTeamScore, int awayTeamScore)//результат можно назначить только одновременно обеим командам
        {
            Match.AssignResult(homeTeamScore, awayTeamScore);
            MatchRepository.Update(Match);
        }

        //все что связано с репозиторием должно быть viewmodel
        public IEnumerable<DateTime> TakePossibleTransferDates()
        {
            var takenDates = MatchRepository//занятые дни
                .GetMatches().Where(m => HomeTeam.TakePartInMatch(m) || AwayTeam.TakePartInMatch(m))
                .Select(m => m.DateTime)
                .Where(d => d > DateTime)
                .Select(d => d.Date);


            var thisSeason = SeasonRepository.FindSeasonById(1);//на данный момент программа работает только в рамках одного сезона
            var dateFrom = thisSeason.currentDate;
            var dateTill = thisSeason.endSeason;
            var defaultTime = thisSeason.DefaultStartMatch;

            var datesBetween = Enumerable
                .Range(1, (int)(dateTill - dateFrom).TotalDays - 1)
                .Select(diff => dateFrom.AddDays(diff));

            var result = datesBetween.Except(takenDates).Select(m => new DateTime(m.Year, m.Month, m.Day, defaultTime.Hour, defaultTime.Minute, 0));
            return result;
        }
    }

    [NotMapped]
    public class TeamViewModel//регулирует окно отображения сведений о команде(в том числе добавление и удаление игроков)
    {
        public readonly Team Team;

        public int Id { get { return Team.Id; } }
        public string Name { get { return Team.Name; } }
        public List<Player> Players { get { return Team.Players; } }
        public string? City { get { return Team.City; } }
        public List<MatchViewModel> Matches { get; private set; }
        public Coach HeadCoach { get { return Team.Coach; } }
        public int? LastSeasonPlace { get { return Team.LastSeasonPlace; } }
        public Stadium Stadium { get { return Team.Stadium; } }

        public TeamViewModel(Team team)
        {
            Matches = new List<MatchViewModel>();
            Team = team;
            foreach (var item in MatchRepository.GetMatches())
            {
                if (team.TakePartInMatch(item)) Matches.Add(new MatchViewModel(item));
            }
        }

        //статистика
        public int? Points { get; set; }

        [NotMapped]
        public int WinCount { get; set; }
        [NotMapped]
        public int DrawCount { get; set; }
        [NotMapped]
        public int LoseCount { get; set; }

        public void AddPlayer(Player player)
        {
            Team.Players.Add(player);
            TeamRepository.Update(Team);
        }

        public void RemovePlayer(Player player)
        {
            Team.Players.Remove(player);
            PlayerRepository.Remove(player);
        }
    }

    [NotMapped]
    public class SeasonViewModel
    {
        public static TeamsTableDGV GetTable()//рассчет статистики
        {
            var teams = TeamRepository.GetTeams();
            var matches = MatchRepository.GetMatches().Where(m => m.IsFinished);
            foreach (var match in matches)
            {
                var homeTeam = teams.Single(t => t.Id == match.HomeTeamId);
                var awayTeam = teams.Single(t => t.Id == match.AwayTeamId);
                if (match.HomeTeamScore > match.AwayTeamScore)
                {
                    homeTeam.WinCount++;
                    awayTeam.LoseCount++;
                }
                else if (match.HomeTeamScore == match.AwayTeamScore)
                {
                    homeTeam.DrawCount++;
                    awayTeam.DrawCount++;
                }
                else
                {
                    awayTeam.WinCount++;
                    homeTeam.LoseCount++;
                }
            }

            return new TeamsTableDGV(teams);
        }

    }
}
