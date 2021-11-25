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

            //input = ReadKey(true);


            do
            {
                key = ReadKey(true);

                if (key.Modifiers != 0)
                {
                    WriteLine("up key....");

                }
                if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        WriteLine("shift key up key....");
                    }
                }

               /* if (key == ConsoleKey.DownArrow)
                {
                    WriteLine("down key....");

                }
                else if ((key == ConsoleKey.DownArrow) & ConsoleModifiers.Shift != 0)
                {
                    WriteLine("shift key down key....");
                }

                if (key == ConsoleKey.LeftArrow)
                {
                    WriteLine("left key....");

                }
                else if ((key == ConsoleKey.LeftArrow) & ConsoleModifiers.Shift != 0)
                {
                    WriteLine("shift key left key....");
                }

                if (key == ConsoleKey.RightArrow)
                {
                    WriteLine("right key....");

                }
                else if ((key == ConsoleKey.RightArrow) & ConsoleModifiers.Shift != 0)
                {
                    WriteLine("shift key right key....");
                }*/

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
