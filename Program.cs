using System;
using static System.Console;

namespace Airplane_pilot_simulator_KANG_sokvimean
{
    class Program
    {
        static void Main(string[] args)
        {
           string logo = @"
               _   _            _                      ___ _ _       _     __ _                 _       _             
              /_\ (_)_ __ _ __ | | __ _ _ __   ___    / _ (_| | ___ | |_  / _(_)_ __ ___  _   _| | __ _| |_ ___  _ __ 
             //_\\| | '__| '_ \| |/ _` | '_ \ / _ \  / /_)| | |/ _ \| __| \ \| | '_ ` _ \| | | | |/ _` | __/ _ \| '__|
            /  _  | | |  | |_) | | (_| | | | |  __/ / ___/| | | (_) | |_  _\ | | | | | | | |_| | | (_| | || (_) | |   
            \_/ \_|_|_|  | .__/|_|\__,_|_| |_|\___| \/    |_|_|\___/ \__| \__|_|_| |_| |_|\__,_|_|\__,_|\__\___/|_|   
                         |_|                                                                                          
            ";
            Write(logo);
            Airplane air = new Airplane();
            air.ControlSpeedAndAltitude();

            ReadKey();
        }
    }
}
