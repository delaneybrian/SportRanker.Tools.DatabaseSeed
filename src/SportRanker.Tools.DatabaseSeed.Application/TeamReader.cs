using System.Collections.Generic;
using System.IO;
using System.Linq;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    public static class TeamReader
    {
        public static ICollection<Team> ParseCsv(string csvPath)
        {
            var teams = new List<Team>();

            var parsedTeams = File
                .ReadAllLines(csvPath)
                .Skip(1)
                .Select(l => new TeamCsv(l))
                .ToList();

            foreach (var parsedTean in parsedTeams)
            {
                if (parsedTean.ToTeam().TrySome(out var team))
                    teams.Add(team);
            }

            return teams;
        }
    }
}
