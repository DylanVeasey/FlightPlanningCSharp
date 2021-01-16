using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanning
{
    class Flight
    {
        private int _runningCost;
        private int _flightRange;
        private int _capactiy;
        private int _minFirst;
        private int _maxStand;
        private int _numStand;
        private int _numFirst;
        private bool _firstSeatsEntered = false;
        private float _costPerSeat;
        private int _costPerFirst;
        private int _costPerStand;
        private float _flightCost;
        private float _flightIncome;
        private float _flightProfit;

        



        public void inputFilghtDetail()
        {
            Console.WriteLine("Please enter the price of a standard-class seat");
            _costPerStand = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the price of a first-class seat");
            _costPerFirst = int.Parse(Console.ReadLine());

            calculateCostPerSeat();
        }

        public void checkAirportCodes()
        {
            if(Airport.DomesticAirportCode != null && Airport.InternationalAirportCode != null)
            {
                if(Aircraft.AircraftType == 1 || Aircraft.AircraftType == 2 || Aircraft.AircraftType == 3)
                {
                    if (_firstSeatsEntered == true )
                    {
                        
                        if(int.Parse(Aircraft.aircraftDetails[Aircraft.AircraftType, 1 ]) >= Airport.getFlightDistance())
                        {
                            inputFilghtDetail();
                            calculateFlightCost();
                            calculateFlightIncome();
                            calcualteFlightProfit();
                            ouptputFlightDetails();
                        }
                        else
                        {
                            Console.WriteLine("Please make sure the type of aircraft is suitable for the distance.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please make sure the number of first class seats has been entered");
                    }
                }
                else
                {
                    Console.WriteLine("Please make sure the aircraft type has been entered.");
                }
            }
            else
            {
                Console.WriteLine("Please make sure both the domestic and international airport codes have been entered!");
            }
        }

        private void calculateStandCapacity()
        {
            _numStand = int.Parse(Aircraft.aircraftDetails[Aircraft.AircraftType, 2]) - (_numFirst * 2);
            Console.WriteLine(_numStand);
        }

        private void calculateCostPerSeat()
        {
            _costPerSeat = (float.Parse(Aircraft.aircraftDetails[Aircraft.AircraftType, 0]) * Airport.getFlightDistance()) / 100;
            Console.WriteLine("The cost per seat is {0}", _costPerSeat);
        }

        private void calculateFlightCost()
        {
            _flightCost = _costPerSeat * (_numStand + _numFirst);
        }

        private void calculateFlightIncome()
        {
            _flightIncome = (_numFirst * _costPerFirst) + (_numStand * _costPerStand);
        }

        private void calcualteFlightProfit()
        {
            _flightProfit = _flightIncome - _flightCost;
        }
        
        public void ouptputFlightDetails()
        {
            Console.WriteLine("The flight income is {0}", _flightIncome);
            Console.WriteLine("The flight cost is {0}", _flightCost);
            Console.WriteLine("The flight profit is {0}", _flightProfit);
        }
        public void getNumFirstClass()
        {
            Console.WriteLine("Please enter the number of first-class seats");
            _numFirst = int.Parse(Console.ReadLine());

            if(_numFirst < int.Parse(Aircraft.aircraftDetails[Aircraft.AircraftType, 3]))
            {
                Console.WriteLine("This is not an acceptable number of seats");
                getNumFirstClass();
            }else if(_numFirst > (int.Parse(Aircraft.aircraftDetails[Aircraft.AircraftType, 2])) / 2)
            {
                Console.WriteLine("This is not an acceptable number of seats");
                getNumFirstClass();
            }
            _firstSeatsEntered = true;
            calculateStandCapacity();
        }
    }
}
