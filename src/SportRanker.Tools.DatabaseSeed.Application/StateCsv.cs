using System;
using Optional;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    internal struct StateCsv
    {
        public StateCsv(string line)
        {
            var csv = line.ToCsvArray();

            Id = csv[(int)StateCsvHeaders.Id].ToLong();
            Abbreviation = csv[(int)StateCsvHeaders.Abbreviation];
            Name = csv[(int)StateCsvHeaders.Name];
            Capital = csv[(int)StateCsvHeaders.Capital];
            Rating = csv[(int) StateCsvHeaders.Rating].ToLong();
            ImageUrl = csv[(int) StateCsvHeaders.ImageUrl];
        }

        private long? Id { get; }

        private string Abbreviation { get; }

        private string Name { get; }

        private string Capital { get; }

        private long? Rating { get; }

        private string ImageUrl { get; }

        public Option<State> ToState()
        {
            if (!Id.HasValue 
                || String.IsNullOrEmpty(Name)
                || String.IsNullOrEmpty(Capital)
                || String.IsNullOrEmpty(Abbreviation)
                || !Rating.HasValue)
                return Option.None<State>();

            var s = new State
            {
                Id = Id.Value,
                Abbreviation = Abbreviation,
                Name = Name,
                Capital = Capital,
                Rating = Rating.Value,
                ImageUrl = ImageUrl
            };

            return Option.Some(s);
        }

        private enum StateCsvHeaders
        {
            Id = 0,
            Abbreviation = 1,
            Name = 2,
            Capital = 3,
            Rating = 4,
            ImageUrl = 5
        }
    }
}
