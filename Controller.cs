using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Airplane_pilot_simulator_KANG_sokvimean
{
    class Controller
    {
        
        Random random = new Random();
        private string name;
        private float condition ;
        private float tempCondition;
        private float Hr;

        private int point;
        private int penaltyPoint;


        public Controller() 
        {
            this.name = "unknown";
        }
        public Controller(string name,float condition)
        {
            this.name = name;
            this.condition = condition;
            this.tempCondition = condition;
        }


        public float getRecommendAltitude()
        {
            return Hr;
        }

        public void DisplayNameAndConditon(int id)
        {
            WriteLine("Controller " + id);
            Write("Name : " + name);
            WriteLine("\tCondition : " + tempCondition);
            WriteLine();
        }

        //take random N while being create- is
        //meter to kilo meter = meter/1000
        //

        //delegate mean it a return type take from parameter and return to defined value


        //when the loes the speed of 50km/h  the controller keep monitoring the 
        //airplane but have no possession of the plane anymore

        //take noticfiacation from the airplane speed and alt changes use delegate

        //method RecommendAltitude()
        //formula Hr = 7 * Speed(km/h)-N
        public void RecommendAltitude(float speed,int i)
        {
            condition = tempCondition;
            condition /= 1000;
            Hr = (7 * speed) - condition;
            Write("Recommend Altitude controller " + i + " = ");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine( Hr);
            ResetColor();
        }

        public void DisplaySpeedAndAltitude(float speed,float height)
        {
            WriteLine();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Current speed : " + speed);
            WriteLine("Current height : " + height);
            ResetColor();
            WriteLine();
        }

        public void Scoring(float speed,float height,List<Controller> controllers,int noController)
        {
             float heightCal;

            for (int i = 0; i < controllers.Count; i++)
            {
                heightCal = 0;
                heightCal = controllers[i].getRecommendAltitude() - height;
                //height > controllers[i].getRecommendAltitude() ||
                if (height < controllers[i].getRecommendAltitude() || speed > 1000)
                {
                    if (heightCal <= 0) { heightCal = -(heightCal); }

                    //WriteLine("heigghtCal  = " + heightCal);

                    if (heightCal >= 300 && heightCal <= 600)
                    {
                        penaltyPoint += 25;
                    }
                    else if (speed > 1000)
                    {
                        penaltyPoint += 100;
                    }
                }
                if (height > controllers[i].getRecommendAltitude())
                {
                   /* heightCal = controllers[i].getRecommendAltitude() - height;*/

                    if (heightCal <= 0) { heightCal = -(heightCal); }

                    if (heightCal >= 600 && heightCal <= 1000)
                    {
                        point += 50;
                    }
                }
            }
        }
        public void DisplayCurrentPoint()
        {
            
            WriteLine();
            Write("Penalty points = ");
            ForegroundColor = ConsoleColor.Red;
            WriteLine(penaltyPoint);
            ResetColor();

            Write("Points = ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine(point);
            ResetColor();
        }
        public void DisplayEndedPoint()
        {
            int sum = 0;
            WriteLine();
            Write("Penalty points = ");
            ForegroundColor = ConsoleColor.Red;
            WriteLine(penaltyPoint);
            ResetColor();
            sum = point - penaltyPoint;
            
            WriteLine("Total = " + sum);
            
            if(sum < 0) 
            {
                WriteLine("You fail successfully please read the command next time");
            }
            else if(sum == 0)
            {
                WriteLine("You fail successfully try again next time!");
            }
            else
            {
                WriteLine("Congratualation you pass!");
            }
            
        }
    }
}
