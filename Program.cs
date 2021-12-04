using System;
using static System.Console;

namespace Airplane_pilot_simulator_KANG_sokvimean
{
    public delegate void DisplayController();
    public delegate void ChangesSpeedAndAltitude(float speed, float height);
    class Program
    {

        
        static void Main(string[] args)
        {
            Random random = new Random();

           

            string logo = @"
               _   _            _                      ___ _ _       _     __ _                 _       _             
              /_\ (_)_ __ _ __ | | __ _ _ __   ___    / _ (_| | ___ | |_  / _(_)_ __ ___  _   _| | __ _| |_ ___  _ __ 
             //_\\| | '__| '_ \| |/ _` | '_ \ / _ \  / /_)| | |/ _ \| __| \ \| | '_ ` _ \| | | | |/ _` | __/ _ \| '__|
            /  _  | | |  | |_) | | (_| | | | |  __/ / ___/| | | (_) | |_  _\ | | | | | | | |_| | | (_| | || (_) | |   
            \_/ \_|_|_|  | .__/|_|\__,_|_| |_|\___| \/    |_|_|\___/ \__| \__|_|_| |_| |_|\__,_|_|\__,_|\__\___/|_|   
                         |_|                                                                                          
            ";


            Airplane air = new Airplane();

            Clear();
            WriteLine(logo);
            int time = 0;
            Controller controller = new Controller();
            do
            {

                
                air.ControlSpeedAndAltitude(controller.DisplaySpeedAndAltitude);
                break;
            } while (time != 18000);
            WriteLine("The simulation eneded!");
            
            


            WriteLine("Press any key to continue...");
            ReadKey();
        }
    }
}
