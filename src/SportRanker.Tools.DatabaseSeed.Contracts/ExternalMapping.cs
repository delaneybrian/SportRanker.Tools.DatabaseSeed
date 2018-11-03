using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SportRanker.Tools.DatabaseSeed.Contracts
{
    [DataContract]
    public class ExternalMapping
    {
        [DataMember]
        public Source Source { get; set; }

        [DataMember]
        public string SourceId { get; set; }
    }
}
