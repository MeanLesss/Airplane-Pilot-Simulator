using System;
using static System.Console;

namespace Airplane_pilot_simulator_KANG_sokvimean
{
    public delegate float ChangesSpeed(float speed);
    public delegate float ChangesAltitude(float height);
    class Program
    {
        

        static void Main(string[] args)
        {

            Random random = new Random();
            float condition;
            int noController;
            string name;

            string upDown = @"The altitude can be changed with the Up and Down arrow keys:

(Up: +250m, Down: -250m, Shift- Up: +500m, Shift- Down: -500m).
";
            string leftRight = @"The speed can be changed with the Left and Right arrow keys:

(Right: + 50km/h, Left: -50km/h, Shift- Right : +150km/h, Shift-Left: -150km/h).
";

            string logo = @"
               _   _            _                      ___ _ _       _     __ _                 _       _             
              /_\ (_)_ __ _ __ | | __ _ _ __   ___    / _ (_| | ___ | |_  / _(_)_ __ ___  _   _| | __ _| |_ ___  _ __ 
             //_\\| | '__| '_ \| |/ _` | '_ \ / _ \  / /_)| | |/ _ \| __| \ \| | '_ ` _ \| | | | |/ _` | __/ _ \| '__|
            /  _  | | |  | |_) | | (_| | | | |  __/ / ___/| | | (_) | |_  _\ | | | | | | | |_| | | (_| | || (_) | |   
            \_/ \_|_|_|  | .__/|_|\__,_|_| |_|\___| \/    |_|_|\___/ \__| \__|_|_| |_| |_|\__,_|_|\__,_|\__\___/|_|   
                         |_|                                                                                          
            ";


            Controller [] controllers;
            Airplane air = new Airplane();

            //the wheather condidton adjustment random number(-200 to +200 meters)
            do
            {
                Clear();
                WriteLine(logo);
                Write("How many controller do you want? (at least 2 controllers) : ");
                noController = int.Parse(ReadLine());
                controllers = new Controller[noController];

                if (noController < 2)
                {
                    WriteLine("Sorry input at least 2 controllers");
                    ReadKey();
                }

            } while (noController < 2);

            for (int i = 0; i < controllers.Length; i++)
            {
                Write("Enter the controller " + i + " name : ");
                name = ReadLine();
                if (i == 0)
                {
                    condition = random.Next(0, 201);
                }
                else if (i == 1)
                {
                    condition = random.Next(-200, 1);
                }
                else
                {
                    condition = random.Next(-200, 200);
                }
                controllers[i] = new Controller(name, condition);
            }

            int time = 0;

            do
            {
                Clear();
                for(int i = 0; i < controllers.Length ;i++)
                {
                    controllers[i].DisplayNameAndConditon(i);
                }
                WriteLine(leftRight);
                WriteLine(upDown);

                Controller controller = new Controller();
                air.ControlSpeedAndAltitude(controller.DisplayCurrentSpeed,controller.DisplayCurrentAltitude);

                //air.DisplayCurrentSpeedAndAltitude();
                ReadKey();

            } while (time != 18000);
            WriteLine("time up!!");
            ReadKey();


            ReadKey();
        }
    }
}
