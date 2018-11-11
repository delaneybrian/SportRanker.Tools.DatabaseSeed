using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SportRanker.Tools.DatabaseSeed.Contracts
{
    [DataContract]
    public class Fixture
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long HomeTeamId { get; set; }

        [DataMember]
        public long HomeTeamScore{ get; set; }

        [DataMember]
        public string HomeTeamName { get; set; }

        [DataMember]
        public string HomeTeamImageUrl { get; set; }

        [DataMember]
        public long AwayTeamId { get; set; }

        [DataMember]
        public long AwayTeamScore{ get; set; }

        [DataMember]
        public string AwayTeamName { get; set; }

        [DataMember]
        public string AwayTeamImageUrl { get; set; }

        [DataMember]
        public long SportId { get; set; }

        [DataMember]
        public string SportName { get; set; }

        [DataMember]
        public string SportImageUrl { get; set; }

        [DataMember]
        public DateTime KickOffTimeUtc { get; set; }

        [DataMember]
        public ICollection<ExternalMapping> ExternalMappings { get; set; }
    }
}
