using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiExaustor.SimulatedThings
{
    public sealed class ExhaustFan
    {
        private static ExhaustFan instance = null;
        private static readonly object padlock = new object();

        public const string STATE_ON = "ON";
        public const string STATE_OFF = "OFF";

        public string name { get; set; }
        private string state;

        ExhaustFan()
        {
            name = "Exhaust Fan";
            this.TurnOff();
        }

        public static ExhaustFan Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ExhaustFan();
                    }
                    return instance;
                }
            }
        }

        public string getState()
        {
            return state;
        }
        
        public void TurnOn()
        {
            state = STATE_ON;
        }

        public void TurnOff()
        {
            state = STATE_OFF;
        }

    }
}