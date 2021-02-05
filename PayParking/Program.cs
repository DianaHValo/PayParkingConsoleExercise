using System;
using System.Collections.Generic;

namespace PayParking
{
    class Program
    {
        static Parking parkingLot;

        static void Main(string[] args)
        {
            parkingLot = new Parking(10, 10, 5);
            Console.WriteLine("Welcome to Parking 2000!! the best parking software");
            Help();

            string input = "";

            while(input != "0")
            {
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CheckFreeSlots();
                        break;
                    case "2":
                        CheckOccupiedLots();
                        break;
                    case "3":
                        Checkin();
                        break;
                    case "4":
                        Checkout();
                        break;
                    case "5":
                        Help();
                        break;
                }
            }
        }

        private static void Help()
        {
            Console.WriteLine("to exit the application enter 0");
            Console.WriteLine("to check if there are any free lots enter 1");
            Console.WriteLine("to check the occupied lots enter 2");
            Console.WriteLine("to checkin enter 3");
            Console.WriteLine("to checkout enter 4");
            Console.WriteLine("for help press 5 and pray someone comes to you");
            Console.WriteLine("to hire me call me at 0769 238 397 :) ");
        }

        private static void CheckFreeSlots()
        {
            int freeLots = parkingLot.FreeParkingLots();

            Console.WriteLine($"Currently there are {freeLots} free lots");
        }

        private static void CheckOccupiedLots()
        {
            List<string> occupiedLots = parkingLot.OccupiedLots(); 

            foreach(var entry in occupiedLots)
            {
                Console.WriteLine(entry);
            }
        }

        private static void Checkin()
        {
            Console.WriteLine("Please enter your license plate");

            string licensePlate = Console.ReadLine();

            string actionResult = parkingLot.OccupyFreeLot(licensePlate);

            Console.WriteLine(actionResult);
        }

        private static void Checkout()
        {
            Console.WriteLine("Please enter your lot number");

            string lotNumber = Console.ReadLine();

            int lotNumberAsInt = Convert.ToInt32(lotNumber);

            Summary summary = parkingLot.LeaveParkingLot(lotNumberAsInt);

            if(summary != null)
            {
                Console.WriteLine($"Arrival time: {summary.ArrivalTime} ");
                Console.WriteLine($"Departure Time: {summary.DepartureTime} ");
                Console.WriteLine($"License plate number: {summary.LicensePlate} ");
                Console.WriteLine($"Total Time: {summary.TotalTime} ");
                Console.WriteLine(summary.PricePerH);
                Console.WriteLine($"Total Payment: {summary.TotalPayment} RON");   
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }
        }
    }
}
