using System.Collections.Generic;
using System.IO;
using System.Linq;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    public static class CityReader
    {
        public static ICollection<City> ParseCsv(string csvPath)
        {
            var cities = new List<City>();

            var parsedCities = File
                .ReadAllLines(csvPath)
                .Skip(1)
                .Select(l => new CityCsv(l))
                .ToList();

            foreach (var parsedCity in parsedCities)
            {
                if(parsedCity.ToCity().TrySome(out var city))
                    cities.Add(city);
            }

            return cities;
        }
    }
}
