using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HKLONG_NITECO_TEST
{
    public class TrafficSimulation
    {

        private const int GREENLIGHT_DURATION_CONST = 17;
        private const int YELLOWLIGHT_DURATION_CONST = 3;
        private int seconds = 0;

        private bool TimerStateBusy = false;
        private System.Threading.Timer timerTrafficSimulation;
        TimerCallback refreshTrafficSimulationCallBack;


        private TrafficLight northSouthTrafficLight, eastWestTrafficLight;

        public TrafficSimulation()
        {
            northSouthTrafficLight = new NorthSouthTrafficLight();
            eastWestTrafficLight = new EastWestTrafficLight();
        }


        public void Run()
        {

            Console.WriteLine(" >>>>>> Initialization >>>>>>>>>>>>>>>>>\n");
            Console.WriteLine(" >>>>>> NorthSouth = Green >>>>>>>>>>>>>>>>>\n");
            Console.WriteLine(" >>>>>> EastWest = Red >>>>>>>>>>>>>>>>>\n");
            northSouthTrafficLight.SetCurrentState(new GreenLightState());
            eastWestTrafficLight.SetCurrentState(new RedLightState());


            refreshTrafficSimulationCallBack = new TimerCallback(Simulation);
            TimeSpan refreshInterval = TimeSpan.FromSeconds(1);
            timerTrafficSimulation = new System.Threading.Timer(refreshTrafficSimulationCallBack, null, new TimeSpan(-1), refreshInterval);

        }

        private void Simulation(object state)
        {
            if (TimerStateBusy)
                return;

            seconds++;
            Console.WriteLine($"seconds {seconds}s");
            TimerStateBusy = true;

            
            if(seconds == GREENLIGHT_DURATION_CONST)
            {
                string strState = northSouthTrafficLight.CurrentState().GetType().Name;
                if(strState == "GreenLightState")
                {
                    northSouthTrafficLight.ChangeState();
                }
                else
                {
                    eastWestTrafficLight.ChangeState();
                }
            }

            if (seconds == GREENLIGHT_DURATION_CONST + YELLOWLIGHT_DURATION_CONST)
            {
                string strState = northSouthTrafficLight.CurrentState().GetType().Name;
                if (strState == "YellowLightState")
                {
                    northSouthTrafficLight.ChangeState();
                    eastWestTrafficLight.ChangeState();
                }
                else
                {
                    eastWestTrafficLight.ChangeState();
                    northSouthTrafficLight.ChangeState();
                }


            }

            if (seconds == (GREENLIGHT_DURATION_CONST + YELLOWLIGHT_DURATION_CONST))
                seconds = 0;

            TimerStateBusy = false;

        }

        public void Stop()
        {
            if (timerTrafficSimulation != null)
            {
                timerTrafficSimulation.Change(Timeout.Infinite, Timeout.Infinite);
                timerTrafficSimulation.Dispose();
                timerTrafficSimulation = null;
            }
        }

    }
}
