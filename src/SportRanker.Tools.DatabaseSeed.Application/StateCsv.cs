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
        }

        private long? Id { get; }

        private string Abbreviation { get; }

        private string Name { get; }

        private string Capital { get; }


        public Option<State> ToState()
        {
            if (!Id.HasValue 
                || String.IsNullOrEmpty(Name)
                || String.IsNullOrEmpty(Capital)
                || String.IsNullOrEmpty(Abbreviation))
                return Option.None<State>();

            var s = new State
            {
                Id = Id.Value,
                Abbreviation = Abbreviation,
                Name = Name,
                Capital = Capital
            };

            return Option.Some(s);
        }

        private enum StateCsvHeaders
        {
            Id = 0,
            Abbreviation = 1,
            Name = 2,
            Capital = 3
        }
    }
}
