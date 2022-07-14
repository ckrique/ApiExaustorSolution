using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIWARE.OrionClient.IoTAgent
{
    public class RootDataCatcher
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("O2Saturation")]
        public O2Saturation o2Saturation { get; set; }

        [JsonProperty("TimeInstant")]
        public TimeInstant timeInstant { get; set; }

        [JsonProperty("Metadata")]
        public Metadata metadata { get; set; }
               
        public class Metadata
        {
            public TimeInstant TimeInstant { get; set; }
        }

        public class O2Saturation
        {
            public string type { get; set; }
            public string value { get; set; }
            public Metadata metadata { get; set; }
        }

        public class TimeInstant
        {
            public string type { get; set; }
            public DateTime value { get; set; }
            public Metadata metadata { get; set; }
        }

    }
}
