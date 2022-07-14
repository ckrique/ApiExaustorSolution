using FIWARE.OrionClient.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiExaustor.Controllers
{
    public class FanExhaustorProvisionToBrokerController : ApiController
    {
        // GET: api/FanExhaustorProvisionToBrokerController
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FanExhaustorProvisionToBrokerController/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FanExhaustorProvisionToBrokerController
        public async Task<IHttpActionResult> PostAsync()
        {
            RESTClient<string> restClient = new RESTClient<string>();
            Task<string> returnedTask = restClient.FanEhxaustorProvisionToBrokerController();
            string returnedValue = await returnedTask;
            //create Conflict return abd send it if necessary
            return Ok(returnedValue);
        }

        // PUT: api/FanExhaustorProvisionToBrokerController/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FanExhaustorProvisionToBrokerController/5
        public void Delete(int id)
        {
        }
    }
}
