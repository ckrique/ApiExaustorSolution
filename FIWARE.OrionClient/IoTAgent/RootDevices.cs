using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIWARE.OrionClient.IoTAgent
{
    public class RootDevices
    {
        [JsonProperty("devices")]
        public List<Device> devices { get; set; }

        public RootDevices()
        {
            devices = new List<Device>();
        }
    }
}
