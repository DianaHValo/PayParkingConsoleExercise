using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayParking
{
    public class Parking
    {
        int _price1stHour;
        int _priceAfter1st;
        public List<ParkingLot> ParkingLots { get; private set; }
        
        public Parking(int noOfParkingLots, int price1stHour, int priceAfter1st)
        {
            _price1stHour = price1stHour;
            _priceAfter1st = priceAfter1st;
            ParkingLots = new List<ParkingLot>();
            for(int i=0; i < noOfParkingLots; i++)
            {
                ParkingLots.Add(new ParkingLot(i));
                
            }
        }

        public string OccupyFreeLot(string LicensePlate)
        {
            ParkingLot Lot = ParkingLots.FirstOrDefault(x => x.Occupied == false);

            if(Lot!= null)
            {
                Lot.OccupyLot(LicensePlate);
                return $"Please proceed to lot {Lot.LotNumber}";
            }
            return "No parking space available";
        }

        public Summary LeaveParkingLot(int lotNumber)
        {
            ParkingLot Lot = ParkingLots.FirstOrDefault(x => x.LotNumber == lotNumber && x.Occupied==true);
            if (Lot != null)
            {
                Summary summary = new Summary();
                summary.ArrivalTime = Lot.Arrival;
                summary.DepartureTime = DateTime.Now;
                summary.LicensePlate = Lot.LicensePlate;
                TimeSpan stationedTime = Lot.Departure();
                summary.TotalTime = stationedTime;
                summary.TotalPayment = CalculatePayment(stationedTime);
                summary.PricePerH = $"First hour price is {_price1stHour} RON, every other hour after is {_priceAfter1st} RON";

                return summary;
            }
            return null;
        }

        private int CalculatePayment(TimeSpan stationedTime)
        {
            
            if (stationedTime.TotalMinutes < 60)
            {
                return _price1stHour;
            }
            var minutesAfterFirstHour = stationedTime.TotalMinutes- 60;
            var hoursAfterFirstHour = minutesAfterFirstHour / 60;
            int hours = (int)Math.Ceiling(hoursAfterFirstHour);
            int payment = (hours * _priceAfter1st) + _price1stHour;
            return payment;
        }

        public List<string> OccupiedLots()
        {
            var occupiedLots = ParkingLots.Where(lot => lot.Occupied == true);

            List<string> carList = new List<string>();

            foreach(var lot in occupiedLots)
            {
                string entry = $"On lot number {lot.LotNumber} is parked {lot.LicensePlate}.";
                carList.Add(entry);
            }

            return carList;
        }

        public int FreeParkingLots()
        {
            var occupiedLots = ParkingLots.Where(lot => lot.Occupied == true).ToList().Count;
            var totalLots = ParkingLots.Count;

            return totalLots - occupiedLots;
        }
    }
}
