using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKLONG_NITECO_TEST
{
    public class YellowLightState: ITrafficLightState
    {
        public void ChangeState(TrafficLight trafficLight)
        {

            trafficLight.SetCurrentState(new RedLightState());

        }
    }
}
