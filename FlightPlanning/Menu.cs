using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanning
{
    class Menu
    {

        private int _menuOption;

        public int MenuOption 
        {
            get { return _menuOption; }
        }

        public void OutputMenu()
        {

            Console.WriteLine("1) Enter airport details");
            Console.WriteLine("2) Enter flight details");
            Console.WriteLine("3) Enter price plan and calculate profit");
            Console.WriteLine("4) Clear data");
            Console.WriteLine("5) Quit");
            GetMenuOption();
        }

        private void GetMenuOption()
        { 
            _menuOption = ValidateMenuOption();
        }

        private int ValidateMenuOption()
        {
            try
            {
                _menuOption = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid response");
                Console.WriteLine("Enter 1, 2, 3, 4, or 5");
                GetMenuOption();
            }
            if (_menuOption < 1 || _menuOption > 5)
            {
                Console.WriteLine("Please enter a valid response");
                Console.WriteLine("Enter 1, 2, 3, 4, or 5");
                GetMenuOption();
            }
            return _menuOption;
        }


    }
}
