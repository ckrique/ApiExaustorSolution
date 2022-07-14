using FIWARE.OrionClient.IoTAgent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FIWARE.OrionClient.REST
{
    public class RESTClient<T>
    {
        private string AuthHeaderKey;
        private string AuthToken;

        public RESTClient()
        {

        }

        /// <summary>
        /// Creates a new instance of the RESTClient with authentication information
        /// </summary>
        /// <param name="authHeaderKey"></param>
        /// <param name="authToken"></param>
        public RESTClient(string authHeaderKey, string authToken)
        {
            this.AuthHeaderKey = authHeaderKey;
            this.AuthToken = authToken;
        }

        /// <summary>
        /// Retrieves the date from the provided URI and returns it as an object of type T
        /// </summary>
        /// <param name="uri">The URL to retrieve</param>
        /// <returns></returns>
        public async Task<T> GetAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(AuthHeaderKey) && !string.IsNullOrWhiteSpace(AuthToken))
                    client.DefaultRequestHeaders.Add(AuthHeaderKey, AuthToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    T genericResponse = JsonConvert.DeserializeObject<T>(content);

                    return genericResponse;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
                       
        public async Task<string> FanEhxaustorProvisionToBrokerController()
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            RootDevices rootDevices = new RootDevices();
            Device fanEhxaustorDevice = new Device();
            fanEhxaustorDevice.device_id = "fanEhxaustor001";
            fanEhxaustorDevice.entity_name = "urn:ngsi-ld:fanEhxaustor:001";
            fanEhxaustorDevice.entity_type = "FanEhxaustor";
            fanEhxaustorDevice.protocol = "PDI-IoTA-UltraLight";
            fanEhxaustorDevice.transport = "HTTP";
            fanEhxaustorDevice.endpoint = "http://192.168.0.6:80/ExhaustorApi/api/Command";

            Command commandOn = new Command();
            commandOn.name = "on";
            commandOn.type = "command";
            fanEhxaustorDevice.commands.Add(commandOn);

            Command commandOff = new Command();
            commandOff.name = "off";
            commandOff.type = "command";
            fanEhxaustorDevice.commands.Add(commandOff);

            FIWARE.OrionClient.IoTAgent.Attribute attribute = new FIWARE.OrionClient.IoTAgent.Attribute();
            attribute.object_id = "s";
            attribute.name = "state";
            attribute.type = "Text";

            fanEhxaustorDevice.attributes.Add(attribute);

            rootDevices.devices.Add(fanEhxaustorDevice);

            using (var client = new HttpClient())
            {
                string body = JsonConvert.SerializeObject(rootDevices, jsonSettings);
                var data = new StringContent(body, Encoding.UTF8, "application/json");
                var url = "http://localhost:4041/iot/devices";
                
                client.DefaultRequestHeaders.Add("fiware-service", "openiot");
                client.DefaultRequestHeaders.Add("fiware-servicepath", "/");

                HttpResponseMessage clientResponse = await client.PostAsync(url, data);

                if (clientResponse.IsSuccessStatusCode)
                {
                    string result = clientResponse.StatusCode.ToString();//clientResponse.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    throw new Exception(clientResponse.ReasonPhrase);
                }
            }
        }

        public async Task SendExhaustorStateToBrokerAsync(string ExhaustorState)
        {
            using (var client = new HttpClient())
            {
                string body = "s|" + ExhaustorState.ToString();
                var data = new StringContent(body, Encoding.UTF8, "text/plain");
                string token = "4jggokgpepnvsb2uv4s40d59ov";
                string url = string.Format("http://localhost:7896/iot/d?k={0}&i=fanEhxaustor001", token);

                HttpResponseMessage clientResponse = await client.PostAsync(url, data);

                if (!clientResponse.IsSuccessStatusCode)
                    throw new Exception(clientResponse.ReasonPhrase);
            }
        }


        /// <summary>
        /// Puts the data to the provided URI and returns the response as an object of type T
        /// </summary>
        /// <param name="uri">The URI to put to</param>
        /// <param name="body">The body content</param>
        /// <returns></returns>
        public async Task<T> PutAsync(string uri, string body)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(AuthHeaderKey) && !string.IsNullOrWhiteSpace(AuthToken))
                    client.DefaultRequestHeaders.Add(AuthHeaderKey, AuthToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent postContent = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(uri, postContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    T genericResponse = JsonConvert.DeserializeObject<T>(content);

                    return genericResponse;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Deletes the date at the provided URI and returns the response as an object of type T
        /// </summary>
        /// <param name="uri">The URI to delete</param>
        /// <returns></returns>
        public async Task<T> DeleteAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(AuthHeaderKey) && !string.IsNullOrWhiteSpace(AuthToken))
                    client.DefaultRequestHeaders.Add(AuthHeaderKey, AuthToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    T genericResponse = JsonConvert.DeserializeObject<T>(content);

                    return genericResponse;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
