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

        //the speed contorl by left right arrow key
        //Right: +50 km/h ,shift + right: +150km/h
        //left : -50 km/h ,shift + left: -150km/h
        //height control by up down arrow key
        //up: +250m , shift + up : +500m
        //down : -250m , shift + down : -500m
        public static float ChangeSpeed(float speed)
        {
            return speed;
        }
        public static float ChangeAltitude(float height)
        {
            return height;
        }
        public void ControlSpeedAndAltitude(ChangesSpeed changesSpeed, ChangesAltitude changesAltitude)
        {
            ConsoleKeyInfo key;

            TreatControlCAsInput = true;
            speed = 0;
            height = 0;

            do
            {

                key = ReadKey(true);

                if (!((key.Modifiers & ConsoleModifiers.Shift) != 0))
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        height += 250;//meter
                                      //WriteLine("up arrow.....");
                        changesAltitude(height);

                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (height > 0)
                        {
                            height -= 250;// meter
                        }
                        // WriteLine("down arrow.....");
                        changesAltitude(height);

                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        speed -= 50; // km/h
                                     // WriteLine("left arrow.....");
                        changesSpeed(speed);

                    }
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        speed += 50; // km/h
                        changesSpeed(speed);

                        //("right arrow.....");
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        height += 500; // meter
                                       //WriteLine("shift up arrow....");
                        changesAltitude(height);

                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        height -= 500; // meter
                                       //WriteLine("shift down arrow.....");
                        changesAltitude(height);

                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        speed -= 150; // km/h

                        //WriteLine("shift left arrow.....");
                        changesSpeed(speed);

                    }
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        speed += 150; // km/h

                        //WriteLine("shift right arrow.....");
                        changesSpeed(speed);

                    }
                }
                if (speed == 1000)
                {
                    WriteLine("You have reach the speed limit. Prepare to land !");

                }
                else if (speed > 1000)
                {
                    WriteLine("You went over the speed limit, reduce the speed immediately");

                }
                else if (speed > 0 && height == 0)
                {
                    WriteLine("You have crash the plane !!!!");
                    break;
                }
                else if (speed <= 0 && height != 0)
                {
                    speed = 0;
                    WriteLine("Turn the engine back on or you will crash !!!!");
                    changesSpeed(speed);
                    break;
                }

            } while (key.Key != ConsoleKey.Escape);

        }



        //control by at least 2 air traffic controllers

        //max speed is 1000km/h

        //meter to kilo meter = meter/1000
    }
}
