using System;
using System.Runtime.Serialization;

namespace SportRanker.Tools.DatabaseSeed.Contracts
{
    [DataContract]
    public class City
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long Rating { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }
}
