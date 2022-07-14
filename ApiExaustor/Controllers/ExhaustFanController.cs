using ApiExaustor.SimulatedThings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiExaustor.Controllers
{
    public class ExhaustFanController : ApiController
    {
        // GET: api/ExhaustFan
        //Method used just to make easy the debug it is not used in on O2SaT
        public string Get()
        {
            return ExhaustFan.Instance.getState();
        }

        // GET: api/ExhaustFan/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ExhaustFan
        public void Post([FromBody]string value)
        {
            IEnumerable<KeyValuePair<string, string>> parChaveValor = Request.GetQueryNameValuePairs();
            string exaustorFanCommand = "";

            foreach (KeyValuePair<string, string> kvp in parChaveValor)
            {
                if (kvp.Key.ToString().Equals("command"))
                    exaustorFanCommand = kvp.Value.ToString();
            }

            if (exaustorFanCommand.ToUpper().Equals(ExhaustFan.STATE_ON.ToUpper()))
            {
                WebApiConfig.exhaustFan.TurnOn();
            }
            else if (exaustorFanCommand.ToUpper().Equals(ExhaustFan.STATE_OFF.ToUpper()))
            {
                WebApiConfig.exhaustFan.TurnOff();
            }
        }

        // PUT: api/ExhaustFan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExhaustFan/5
        public void Delete(int id)
        {
        }
    }
}
