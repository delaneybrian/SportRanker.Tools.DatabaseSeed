using System;
using SportRanker.Tools.DatabaseSeed.Application;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var dbSeeder = new DatabaseSeeder();

            var states = StateReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\states.csv");

            var teams = TeamReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\teams.csv");

            var sports = SportReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\sports.csv");

            var cities = CityReader.ParseCsv(
                @"C:\Code\SportRanker\SportRanker.Tools.DatabaseSeed\src\SportRanker.Tools.DatabaseSeed.App\Data\cities.csv");

            //dbSeeder.SeedData<City>(cities, "cities").Wait();

            Console.ReadKey();
        }
    }
}
