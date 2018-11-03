using System.Collections.Generic;
using System.IO;
using System.Linq;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    public static class SportReader
    {
        public static ICollection<Sport> ParseCsv(string csvPath)
        {
            var sports = new List<Sport>();

            var parsedSports = File
                .ReadAllLines(csvPath)
                .Skip(1)
                .Select(l => new SportCsv(l))
                .ToList();

            foreach (var parsedSport in parsedSports)
            {
                if (parsedSport.ToSport().TrySome(out var sport))
                    sports.Add(sport);
            }

            return sports;
        }
    }
}
