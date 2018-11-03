using System;
using Optional;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    internal struct CityCsv
    {
        public CityCsv(string line)
        {
            var csv = line.ToCsvArray();

            Id = csv[(int)CityCsvHeaders.Id].ToLong();
            Name = csv[(int)CityCsvHeaders.Name];
        }

        private long? Id { get; }

        private string Name { get; }

        public Option<City> ToCity()
        {
            if (!Id.HasValue || String.IsNullOrEmpty(Name))
                return Option.None<City>();

            var c = new City
            {            
                Id = Id.Value,
                Name = Name               
            };

            return Option.Some(c);
        }

        private enum CityCsvHeaders
        {
            Id = 0,
            Name = 1,         
        }
    }
}
