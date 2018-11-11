using System;
using System.Collections.Generic;
using Optional;
using SportRanker.Tools.DatabaseSeed.Contracts;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    internal struct TeamCsv
    {
        public TeamCsv(string line)
        {
            var csv = line.ToCsvArray();

            Id = csv[(int)TeamCsvHeaders.Id].ToLong();
            Name = csv[(int)TeamCsvHeaders.Name];
            Sport = csv[(int)TeamCsvHeaders.Sport];
            SportId = csv[(int)TeamCsvHeaders.SportId].ToLong();
            StateName = csv[(int)TeamCsvHeaders.StateName];
            StateId = csv[(int)TeamCsvHeaders.StateId].ToLong();
            CityName = csv[(int)TeamCsvHeaders.CityName];
            CityId = csv[(int)TeamCsvHeaders.CityId].ToLong();
            Rating = csv[(int)TeamCsvHeaders.Rating].ToLong();
            SportRadarId = csv[(int)TeamCsvHeaders.SportRadarId];
            ImageUrl = csv[(int) TeamCsvHeaders.ImageUrl];
        }

        private long? Id { get; }

        private string Name { get; }

        private string Sport { get; }

        private long? SportId { get; }

        private string StateName { get; }

        private long? StateId { get; }

        private string CityName { get; }

        private long? CityId { get; }

        private long? Rating { get; }

        private string SportRadarId { get; }

        private string ImageUrl { get; }

        public Option<Team> ToTeam()
        {
            if (!Id.HasValue
                || String.IsNullOrEmpty(Name)
                || String.IsNullOrEmpty(Sport)
                || !SportId.HasValue
                || String.IsNullOrEmpty(StateName)
                || !StateId.HasValue
                || String.IsNullOrEmpty(CityName)
                || !CityId.HasValue
                || !Rating.HasValue
                || String.IsNullOrEmpty(SportRadarId))
                return Option.None<Team>();

            var t = new Team
            {
                Id = Id.Value,
                Name = Name,
                SportName = Sport,
                SportId = SportId.Value,
                StateName = StateName,
                StateId = StateId.Value,
                CityName = CityName,
                CityId = CityId.Value,
                Rating = Rating.Value,
                ExternalMappings = new List<ExternalMapping>()
                {
                    new ExternalMapping()
                    {
                        Source = Source.SportRadar,
                        SourceId = SportRadarId
                    }
                },
                ImageUrl = ImageUrl
            };

            return Option.Some(t);
        }

        private enum TeamCsvHeaders
        {
            Id = 0,
            Name = 1,
            Sport = 2,
            SportId = 3,
            StateName = 4,
            StateId = 5,
            CityName = 6,
            CityId = 7,
            Rating = 8,
            SportRadarId = 9,
            ImageUrl = 10
        }
    }
}
