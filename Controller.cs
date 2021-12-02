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

        public void DisplayNameAndConditon(int id)
        {
            WriteLine("Controller " + id);
            Write("Name : " + name);
            WriteLine("\tCondition : " + tempCondition);
        }

        public void DisplayRecommendAltitude()
        {
            WriteLine("Recommend altitude : " + Hr);
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

        /*public float DisplayCurrentSpeed(float speed)
        {
            WriteLine("Current speed : " + speed);
            WriteLine();
            return speed;
        }
        public float DisplayCurrentAltitude(float height)
        {
            WriteLine("Current height : " + height);
            WriteLine();
            return height;
        }*/
        public void DisplaySpeedAndAltitude(float speed,float height)
        {
            WriteLine();
            WriteLine("Current speed : " + speed);
            WriteLine("Current height : " + height);
            WriteLine();
        }
        public int Point()
        {
            return point;
        }
        public int PenaltyPoint()
        {
            return penaltyPoint;
        }
        public void DisplayPoint()
        {
            WriteLine("Point = " + point);
            WriteLine("Penalty point = " + penaltyPoint);
        }

    }
}
