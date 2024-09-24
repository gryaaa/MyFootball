using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyFootball
{
    public static class MatchRepository
    {
        public static List<Match> GetMatches()
        {
            var matches = new List<Match>();
            using (var db = new ApplicationContext())
            {
                matches = db.Matches.Include(m => m.Stadium).ToList();
            }
            return matches;
        }

        public static Match FindMatchById(int id)
        {
            var match = new Match();
            using (var db = new ApplicationContext())
            {
                match = db.Matches.Find(id);
            }
            return match;
        }

        public static void Update(Match match)
        {
            using (var db = new ApplicationContext())
            {
                db.Matches.Update(match);
                db.SaveChanges();
            }
        }

        public static void Add(Match match)
        {
            using (var db = new ApplicationContext())
            {
                db.Matches.Add(match);
                db.SaveChanges();
            }
        }
    }

    public static class TeamRepository
    {
        public static List<Team> GetTeams()
        {
            var teams = new List<Team>();
            using (var db = new ApplicationContext())
            {
                teams = db.Teams
                    .Include(team => team.Coach)
                    .Include(team => team.Stadium)
                    .Include(team=>team.Players)
                    .ToList();
            }
            return teams;
        }

        public static Team FindTeamById(int id)
        {
            var team = new Team();
            using (var db = new ApplicationContext())
            {
                team = db.Teams.Find(id);
            }
            return team;
        }

        public static void Update(Team team)
        {
            using (var db = new ApplicationContext())
            {
                db.Teams.Update(team);
                db.SaveChanges();
            }
        }
    }

    public static class PlayerRepository
    {
        public static List<Player> GetPlayers()
        {
            var players = new List<Player>();
            using (var db = new ApplicationContext())
            {
                players = db.Players.ToList();
            }
            return players;
        }

        public static Player FindPlayerById(int id)
        {
            var player = new Player();
            using (var db = new ApplicationContext())
            {
                player = db.Players.Find(id);
            }
            return player;
        }

        public static void Update(Player player)
        {
            using (var db = new ApplicationContext())
            {
                db.Players.Update(player);
                db.SaveChanges();
            }
        }

        public static void Add(Player player)
        {
            using (var db = new ApplicationContext())
            {

                db.Players.Add(player);
                db.SaveChanges();

            }
        }

        public static void Remove(Player player)
        {
            using (var db = new ApplicationContext())
            {
                db.Players.Remove(player);
                db.SaveChanges();

            }
        }
    }

    public static class StadiumRepository
    {
        public static Stadium FindStadiumById(int id)
        {
            var stadium = new Stadium();
            using (var db = new ApplicationContext())
            {
                stadium = db.Stadiums.Find(id);
            }
            return stadium;

        }
    }

    public static class SeasonRepository
    {
        public static void Update(Season season)
        {
            using (var db = new ApplicationContext())
            {
                db.Seasons.Update(season);
                db.SaveChanges();
            }
        }

        public static Season FindSeasonById(int id)
        {
            Season result = null;
            using (var db = new ApplicationContext())
            {
                result = db.Seasons.Find(id);
            }
            return result;
        }
    }
}
