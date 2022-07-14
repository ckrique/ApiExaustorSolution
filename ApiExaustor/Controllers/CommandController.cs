using ApiExaustor.SimulatedThings;
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
    public class CommandController : ApiController
    {
        // GET: api/Start
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Start/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Start
        public async Task<string> PostAsync([FromBody]string value)
        {
            string processamentoDoComando = string.Empty;
            string initialExhaustorState = ExhaustFan.Instance.getState();
            try
            {
                if (value.Contains("@on"))
                {
                    ExhaustFan.Instance.TurnOn();
                    processamentoDoComando = " on OK";
                }
                else if (value.Contains("@off"))
                {
                    ExhaustFan.Instance.TurnOff();
                    processamentoDoComando = " off OK";
                }
                else
                    throw new Exception("Invalid Parameter.");

                RESTClient<string> restClient = new RESTClient<string>();
                await restClient.SendExhaustorStateToBrokerAsync(ExhaustFan.Instance.getState());
            }
            catch
            {
                if (initialExhaustorState.ToUpper().Equals(ExhaustFan.STATE_ON))
                    ExhaustFan.Instance.TurnOn();
                else
                    ExhaustFan.Instance.TurnOff();

                return "ERROR";
            }

            value = value + processamentoDoComando;
            return value;
        }

        // Patch: api/Start
        public void Patch([FromBody]string value)
        {
        }
        
        // PUT: api/Start/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Start/5
        public void Delete(int id)
        {
        }
    }
}
