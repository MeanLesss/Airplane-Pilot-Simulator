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
            Hr = 7 * speed - condition;
            WriteLine("Recommend Altitude controller "+i +" = " + Hr);
        }

        public void DisplaySpeedAndAltitude(float speed,float height)
        {
            WriteLine();
            WriteLine("Current speed : " + speed);
            WriteLine("Current height : " + height);
            WriteLine();
        }

        public void Scoring(float speed,float height,Controller[]  controllers)
        {
             float heightCal;

            for (int i = 0; i < controllers.Length; i++)
            {
                if (height > controllers[i].getRecommendAltitude() ||
                   height < controllers[i].getRecommendAltitude())
                {
                    heightCal = 0;
                    heightCal = controllers[i].getRecommendAltitude() - height;

                    if (heightCal <= 0) { heightCal = -(heightCal); }

                    WriteLine("heigghtCal  = " + heightCal);
                    if (heightCal >= 300 && heightCal <= 600)
                    {
                        penaltyPoint += 25;
                    }
                    else if (heightCal >= 600 && heightCal <= 1000)
                    {
                        point += 50;
                    }
                    else if (speed > 1000)
                    {
                        penaltyPoint += 100;
                    }
                } 
            }
        }
        public void DisplayCurrentPoint()
        {
            WriteLine("Penalty points = " + penaltyPoint);
            WriteLine("Points = " + point);
        }
        public void DisplayEndedPoint()
        {
            int sum = 0;
            WriteLine("Penalty points = " + penaltyPoint);
            WriteLine("Points = " + point);
            sum = point - penaltyPoint;
            if(sum < 0) { sum = -(sum); }
            WriteLine("Total = " + sum);
        }
    }
}
