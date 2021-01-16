using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanning
{
    class Aircraft
    {

        private static int _aircraftType;
        public static int AircraftType 
        {
            get { return _aircraftType; }
        }

        public static string[,] aircraftDetails = new string[,]
            {
            {"Running cost per seat per 100km (£)", "Maximum flight range (km)", "Capacity if all seats are standard-class" , "Minimum number of first-class seats"},
            {"8" , "2650" , "180", "8"},
            {"7" , "5600" , "220", "10"},
            {"5" , "4050" , "406", "14"},
            };


        private int runningCost;
        private int flightRange;
        private int capacity;
        private int minFirst;
        private int maxStand;


        public void GetAircraftDetails()
        {
            Console.WriteLine("Please enter the type of aircraft:");
            Console.WriteLine("1) Medium Narrow Body");
            Console.WriteLine("2) Large Narrow Body");
            Console.WriteLine("3) Medium Wide Body");
            //Needs to be reworked!!!! 
            _aircraftType = int.Parse(Console.ReadLine());
            if (_aircraftType == 1)
            {
                _aircraftType = 1;
            }
            else if (_aircraftType == 2)
            {
                _aircraftType = 2;
            }
            else if (_aircraftType == 3)
            {
                _aircraftType = 3;
            }
            else
            {
                Console.WriteLine("This is not a valid answer");
                GetAircraftDetails();
            }
            outputAircraftDetails();
        }
        private void outputAircraftDetails()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("The {0} is {1}", Aircraft.aircraftDetails[0, i], Aircraft.aircraftDetails[_aircraftType, i]);
            }
        }
    }

  
}
