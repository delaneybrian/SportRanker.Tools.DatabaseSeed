using System.Runtime.Serialization;

namespace SportRanker.Tools.DatabaseSeed.Contracts
{
    [DataContract]
    public class State
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Abbreviation { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Capital { get; set; }
    }
}
