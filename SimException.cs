using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Airplane_pilot_simulator_KANG_sokvimean
{
    class SimException
    {
        public void OverSpeed(float speed)
        {
            try
            {
                if (speed >= 1000)
                {
                    throw new Exception();
                }
            }
            catch 
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Slow down and prepare to land !");
                WriteLine();
                ResetColor();
            }
        }

        public void UnfitToFly(Controller controller)
        {
            try
            {
                if(controller.getPentalyPoint() >= 1000)
                {
                    throw new Exception();
                }
            }
            catch
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("You have reached 1000 penaly point. You have failed automatically.");
                ResetColor();
            }
        }

        public void PullUp(float height, List<Controller> controllers)
        {
            try
            {
                float heightCal;
                for (int i = 0; i < controllers.Count; i++)
                {
                    if (height < controllers[i].getRecommendAltitude())
                    {
                        heightCal = 0;
                        heightCal = controllers[i].getRecommendAltitude() - height;

                        if (heightCal <= 0) { heightCal = -(heightCal); }
                        if (heightCal < 300)
                        {
                            throw new Exception();
                        }
                    }
                }

            }
            catch
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Pull up it dangerous altitude!");
                ResetColor();
            }
        }

        public void PlaneCrash(float height, List<Controller> controllers)
        {
            try
            {
                float heightCal;
                for (int i = 0; i < controllers.Count; i++)
                {
                    if (height > controllers[i].getRecommendAltitude())
                    {
                        heightCal = 0;
                        heightCal = controllers[i].getRecommendAltitude() - height;

                        if (heightCal <= 0) { heightCal = -(heightCal); }
                        if (heightCal > 1000)
                        {
                            throw new Exception();
                        }
                    }
                }
                
            }
            catch
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The plane crashed");
                ResetColor();
            }
        }
        public void PlaneCrash(float speed,float height)
        {

            try
            {

                if (speed > 100 && height == 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The plane crashed");
                ResetColor();
            }
        }
    }
}
