using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKLONG_NITECO_TEST
{
    public abstract class TrafficLight
    {
        protected ITrafficLightState currentState;

        public virtual void ChangeState() {
            currentState.ChangeState(this);
        }

        public virtual ITrafficLightState CurrentState()
        {
            return currentState;
        }

        public virtual void SetCurrentState(ITrafficLightState trafficLight)
        {
            currentState = trafficLight;
            Console.WriteLine($"Class => {this.GetType().Name}: Set Current State = {trafficLight.GetType().Name}");
        }


    }
}
