using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIWARE.OrionClient.IoTAgent
{
    public class Service
    {
        [JsonProperty("apikey")]
        public string apikey { get; set; }

        [JsonProperty("cbroker")]
        public string cbroker { get; set; }

        [JsonProperty("entity_type")]
        public string entity_type { get; set; }

        [JsonProperty("resource")]
        public string resource { get; set; }
    }
}
