using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Airplane_pilot_simulator_KANG_sokvimean
{
    class Airplane
    {
        public delegate float ChangesSpeed(float speed);
        public delegate float ChangesAltitude(float height);
        private float speed;
        private float height;

        public Airplane() { }
        public Airplane(float speed, float height)
        {
            this.speed = speed;
            this.height = height;
        }
        public float Speed {get; set; }
        public float Height { get; set; }

        public void ControlSpeedAndAltitude()
        {
            ConsoleKeyInfo key;

            TreatControlCAsInput = true;



            do
            {
                key = ReadKey(true);

                /*if(!(key.Modifiers != 0))
                {*/
                if(!((key.Modifiers & ConsoleModifiers.Shift) != 0))
                { 
                    if(key.Key == ConsoleKey.UpArrow)
                    {
                        WriteLine("up arrow.....");
                    }
                    if(key.Key == ConsoleKey.DownArrow)
                    {
                        WriteLine("down arrow.....");
                    }
                    if(key.Key == ConsoleKey.LeftArrow)
                    {
                        WriteLine("left arrow.....");
                    }
                    if (key.Key == ConsoleKey.RightArrow) 
                    {
                        WriteLine("right arrow.....");
                    }

                }
                else
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        WriteLine("shift up arrow....");
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        WriteLine("shift down arrow.....");
                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        WriteLine("shift left arrow.....");
                    }
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        WriteLine("shift right arrow.....");
                    }
                }

            } while (key.Key != ConsoleKey.Escape);
            
            
           

        }
       

        //the speed contorl by left right arrow key
        //Right: +50 km/h ,shift + right: +150km/h
        //left : -50 km/h ,shift + left: -150km/h

        //height control by up down arrow key
        //up: +250m , shift + up : +500m
        //down : -250m , shift + down : -500m

        //control by at least 2 air traffic controllers

        //max speed is 1000km/h

        //meter to kilo meter = meter/1000
    }
}
