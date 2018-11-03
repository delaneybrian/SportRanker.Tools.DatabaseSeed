using System;
using Optional;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    internal struct SportCsv
    {
        public SportCsv(string line)
        {
            var csv = line.ToCsvArray();

            Id = csv[(int)SportCsvHeaders.Id].ToLong();
            Name = csv[(int)SportCsvHeaders.Name];
            SportName = csv[(int)SportCsvHeaders.SportName];
        }

        private long? Id { get; }

        private string Name { get; }

        private string SportName { get;  }

        public Option<Sport> ToSport()
        {
            if (!Id.HasValue 
                || String.IsNullOrEmpty(Name)
                || String.IsNullOrEmpty(SportName))
                return Option.None<Sport>();

            var s = new Sport
            {
                Id = Id.Value,
                Name = Name
            };

            return Option.Some(s);
        }

        private enum SportCsvHeaders
        {
            Id = 0,
            Name = 1,
            SportName = 2
        }
    }
}
