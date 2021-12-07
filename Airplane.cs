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
        private string menu = @"1.add more controller
2.Remove controller
Enter your choice : ";


        private float speed;
        private float height;

        private int option;
        private int noController;
        private int countInput;
        private int countRec;
        private ConsoleKeyInfo[] allCommandUsed = new ConsoleKeyInfo[200];
        private float[] allRecommand = new float[300];

        //Controller[] controllers = new Controller[20];
        List<Controller> controllers = new List<Controller>();
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

               // controllers = new Controller[noController];

                if (noController < 2)
                {
                    WriteLine("Sorry input at least 2 controllers");
                }

            } while (noController < 2);

            for(int i = 0; i < noController; i++)
            {
                AddController(i);
            }
            
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

                //EXCEPTION
                ex.OverSpeed(speed);
                //exception if speed over limit
                if ((height - controllers[0].getRecommendAltitude()) > 1000)
                {
                    ex.PlaneCrash(height, controllers);
                    break;
                }
                
                //ex.PullUp(height, controllers);
                
                //exception if speed is greater than height
                if (speed > 100 && height == 0)
                {
                    ex.PlaneCrash(speed, height);
                    break;
                }

                WriteLine(leftRight);
                WriteLine(upDown);
                Write(menu);

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
                    if (key.Key == ConsoleKey.D1)
                    {
                        option = 1;
                        DuringFlightMenu(option);
                    }
                    if (key.Key == ConsoleKey.D2)
                    {
                        option = 2;
                        DuringFlightMenu(option);
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
                
                TreatControlCAsInput = false;

                Clear();
                
                //scoring
                controller.Scoring(speed, height, controllers, noController);
                
                //Display all controller and condition
                ArrDisplayNameAndConditon();

                // delegate to display current speed and height
                changesSpeedAndAltitude(speed, height);

                //show controller recommend altitude
                for (int i = 0; i < controllers.Count; i++)
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


            } while (speed >= 0 && height >= 0);

            //Display point after
            controller.DisplayEndedPoint();
            ArrDisplayCommand();
            ArrDisplayRecommand();
        }



        public void DuringFlightMenu(int option)
        {
            int newControllerNo;
            int removeId;
            switch (option)
            {
                case 1:

                    Clear();
                    TreatControlCAsInput = false;

                    Write("How many controller do you want? : ");
                    newControllerNo = int.Parse(ReadLine());
                    noController += newControllerNo;
                    for (int i = 0; i < newControllerNo; i++)
                    {
                        AddController();
                    }
                    break;

                case 2:

                    Clear();

                    ArrDisplayNameAndConditon();

                    if (noController > 2)
                    {
                        TreatControlCAsInput = false;
                        Write("Enter the controller id to remove : ");
                        removeId = int.Parse(ReadLine());
                        controllers.RemoveAt(removeId);
                        noController--;
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("Controller removed");
                        ResetColor();
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Sorry you can't remove any controller you need 2 controller to operate the flight");
                        ResetColor();
                    }

                    break;
                case 3:
                    break;
            }
        }

        public void AddController()
        {
            Random random = new Random();
            float condition;
            string name;
            Write("Enter the controller name : ");
            name = ReadLine();

            condition = random.Next(-200, 200);

            controllers.Add(new Controller(name, condition));
        }

        public void AddController(int i)
        {
            Random random = new Random();
            float condition;
            string name;

            Write("Enter the controller name : ");
            name = ReadLine();
                condition = random.Next(-200, 200);
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
            controllers.Add(new Controller(name, condition));
        }


        public void ArrDisplayNameAndConditon()
        {
            for (int i = 0; i < controllers.Count; i++)
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
