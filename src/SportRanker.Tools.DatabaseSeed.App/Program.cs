using System;
using SportRanker.Tools.DatabaseSeed.Application;

namespace SportRanker.Tools.DatabaseSeed.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var states = StateReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\states.csv");

            var teams = TeamReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\teams.csv");

            var sports = SportReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\sports.csv");

            var cities = CityReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\cities.csv");

            Console.ReadKey();
        }
    }
}
