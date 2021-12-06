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
        private string upDown = @"Altitude Up and Down arrow keys:

(Up: +250m, Down: -250m, Shift- Up: +500m, Shift- Down: -500m).

Press ESC to stop the emulation.
";
         private string leftRight = @"
Speed Left and Right arrow keys:

(Right: + 50km/h, Left: -50km/h, Shift- Right : +150km/h, Shift-Left: -150km/h).
";
        private float speed;
        private float height;

        private int noController;
        private int countInput;
        private int countRec;
        private ConsoleKeyInfo[] allCommandUsed = new ConsoleKeyInfo[200];
        private float[] allRecommand = new float[200];

        Controller[] controllers = new Controller[20];
        SimException ex = new SimException();


        public Airplane() { }
        public Airplane(float speed, float height)
        {
            this.speed = speed;
            this.height = height;
        }
        public float Speed
        {
            get => speed;
            //set speed; 
        }
        public float Height { get; set; }

        //the speed contorl by left right arrow key
        //Right: +50 km/h ,shift + right: +150km/h
        //left : -50 km/h ,shift + left: -150km/h
        //height control by up down arrow key
        //up: +250m , shift + up : +500m
        //down : -250m , shift + down : -500m

        public void ControlSpeedAndAltitude(ChangesSpeedAndAltitude changesSpeedAndAltitude)
        {
            do
            {
                Write("How many controller do you want? (at least 2 controllers) : ");
                noController = int.Parse(ReadLine());
                controllers = new Controller[noController];

                if (noController < 2)
                {
                    WriteLine("Sorry input at least 2 controllers");
                }

            } while (noController < 2);
            AddController();
            ArrDisplayNameAndConditon();

            ConsoleKeyInfo key;
            
            Controller controller = new Controller();

            speed = 0;
            height = 0;
            countInput = 0;
            countRec = 0;

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Let's begin the simulaion. Press right arrow key to START!");
            ResetColor();

            do
            {
                TreatControlCAsInput = true;
                WriteLine(leftRight);
                WriteLine(upDown);
                key = ReadKey(true);
                allCommandUsed[countInput++] = key;


                if (!((key.Modifiers & ConsoleModifiers.Shift) != 0))
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        height += 250;//meter
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (height > 0)
                        {
                            height -= 250;// meter
                        }
                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        speed -= 50; // km/h
                    }
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        speed += 50; // km/h
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        height += 500; // meter
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        height -= 500; // meter
                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        speed -= 150; // km/h
                    }
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        speed += 150; // km/h
                    }
                }
                //conditon here
                Clear();

                //scoring 
                //controller.Scoring(speed, height, controllers,noController);


                //set recommend al to arr
                

                //exception if speed over limit
                ex.OverSpeed(speed);
                for (int i = 0; i < noController; i++)
                {
                    if ((height - controllers[i].getRecommendAltitude()) > 1000)
                    {
                        ex.PlaneCrash(height, controllers);
                        break;
                    }
                }
                
                //exception if speed is greater than height

                if (speed > 100 && height == 0)
                {
                    ex.PlaneCrash(speed, height);
                    break;
                }

                //Display all controller and condition
                ArrDisplayNameAndConditon();

                // delegate to display current speed and height
                changesSpeedAndAltitude(speed, height);

                //show controller recommend altitude
                for (int i = 0; i < controllers.Length; i++)
                {
                    controllers[i].RecommendAltitude(speed, i);
                    allRecommand[countRec++] = controllers[i].getRecommendAltitude();
                }

                controller.DisplayCurrentPoint();
                key.ToString();
                //to stopp the simulation when speed and height is 0 mean landded
                if (speed <= 0 && height <= 0)
                {
                    WriteLine("The plane landed successfully!!");
                    break;
                }

                TreatControlCAsInput = false;
                int option;
                int newControllerNo = 0;
                Random random = new Random();
                float condition;
                string name;
                Write(@"1.add more controller
2.Remove controller
3.Continue flight
Enter your choice : ");
                option = int.Parse(ReadLine());
                switch (option)
                {
                    case 1:
                        Write("How many controller do you want? : ");
                        newControllerNo = int.Parse(ReadLine());
                        noController += newControllerNo;
                        for (int i = noController - newControllerNo; i < noController; i++)
                        {
                            Write("Enter the controller " + i + " name : ");
                            name = ReadLine();

                            condition = random.Next(-200, 200);

                            controllers[i - 1] = new Controller(name, condition);
                        }
                        break;

                    case 2:

                        break;
                    case 3:
                        break;
                }


            } while (speed >= 0 && height >= 0);

            //Display point after
            controller.DisplayEndedPoint();
            ArrDisplayCommand();
            ArrDisplayRecommand();
        }



        public void DuringFlightMenu()
        {
            
        }

        public void AddController(int noController)
        {
            Random random = new Random();
            float condition;
            string name;

            Write("Enter the controller " + noController + " name : ");
            name = ReadLine();

            condition = random.Next(-200, 200);

            controllers[noController] = new Controller(name, condition);
        }

        public void AddController()
        {
            Random random = new Random();
            float condition;
            string name;
            

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
        }


        public void ArrDisplayNameAndConditon()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                controllers[i].DisplayNameAndConditon(i);
            }
            
        }

        public void ArrDisplayCommand()
        {
            WriteLine("All command during the flight : ");
            for (int i = 0; i < countInput; i++)
            {
                WriteLine(allCommandUsed[i].Key);
            }

        }
        
        public void ArrDisplayRecommand()
        {
            WriteLine("All recommand during the flight : ");
            for (int i = 0; i < countRec; i++)
            {
                WriteLine(allRecommand[i]);
            }

        }

        //control by at least 2 air traffic controllers

        //max speed is 1000km/h

        //meter to kilo meter = meter/1000
    }
}
