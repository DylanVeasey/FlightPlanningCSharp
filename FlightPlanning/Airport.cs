using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanning
{
    class Airport
    {
       
        private static string _domesticAirportCode;
        public static string DomesticAirportCode 
        {
            get { return _domesticAirportCode; }
        }

        private static string _internationalAirportCode;

        public static string InternationalAirportCode
        {
            get { return _internationalAirportCode; }
        }

        private string _airportName;
        private int _distanceLPL;
        private int _distanceBOH;

        public static string[,] airportDetails = new string[5, 4];
        private string[] airport;
        private static int _airportIndex;


        public Airport()
        {
            readDetailsFromFile();
        }

        public void readDetailsFromFile()
            {
                using (var sr = new StreamReader("C:/Airports.txt"))
                {
                    
                    for (int i = 0; i < 5; i++)
                    {
                        string line = sr.ReadLine();
                        airport = line.Split(',');
                        for (int j = 0; j < 4; j++)
                            {
                                airportDetails[i, j] = airport[j];
                            }
                    }
                }
            }

        public static int getFlightDistance()
        {
            int _distance = 0;

            if(_domesticAirportCode == "BOH")
            {
                _distance = int.Parse(airportDetails[_airportIndex, 3]);
            }
            else
            {
                _distance = int.Parse(airportDetails[_airportIndex, 2]);
            }
            return _distance;
        }

        public void getAirportName()
        {
            getDomesticCode();
            getInternationalCode();
        }

        public void getDomesticCode()
        {
            Console.WriteLine("Please enter the airport code for the UK airport");
            _domesticAirportCode = validateDomesticCode();
        }
        public string validateDomesticCode()
        {
            _domesticAirportCode = Console.ReadLine();
            if (_domesticAirportCode == "LPL" || _domesticAirportCode == "BOH")
            {
                Console.WriteLine("Code has been inputted");
            }
            else
            {
                Console.WriteLine("This domestic code does not exist!");
                Console.ReadLine();
            }
            return _domesticAirportCode;
        }
        public void getInternationalCode()
        {
            Console.WriteLine("Please enter the airport code for the international airport");
            _internationalAirportCode = validateInernationalCode();
        }

        public string validateInernationalCode()
        {
            _internationalAirportCode = Console.ReadLine();
            bool validInternationalCode = false;
            for(int i = 0; i < 5; i++)
            {
                if(airportDetails[i,0] == _internationalAirportCode)
                {
                    validInternationalCode = true;
                    _airportIndex = i;
                    Console.WriteLine("Code has been inputted");
                    OutputAirportName();
                }
            }
            if(validInternationalCode == false)
            {
                Console.WriteLine("This code does not exist, please try again");
                getInternationalCode();
            }

            return _internationalAirportCode;
        }

        public void OutputAirportName()
        {
            Console.WriteLine("The airport name is: {0}", airportDetails[_airportIndex, 1]);
        }

        
    }
}
