using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            MainProgram();
           
        }
        public static void MainProgram()
        {
            Menu mainMenu = new Menu();

            Airport airport1 = new Airport();

            Flight flight1 = new Flight();

            Aircraft aircraft1 = new Aircraft();

            while (true)
            {
                mainMenu.OutputMenu();
                switch (mainMenu.MenuOption)
                {
                    case 1:
                        Console.WriteLine("Enter airport details");
                        airport1.getAirportName();
                        break;
                    case 2:
                        Console.WriteLine("Enter flight details");
                        aircraft1.GetAircraftDetails();
                        flight1.getNumFirstClass();
                        break;
                    case 3:
                        Console.WriteLine("Enter price plan and calculate profit");
                        flight1.checkAirportCodes();
                        break;
                    case 4:
                        Console.WriteLine("Clear data");
                        mainMenu = null;
                        aircraft1 = null;
                        flight1 = null;
                        aircraft1 = null;
                        Program.MainProgram();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                }
            }
        }




    }
   

  
}

