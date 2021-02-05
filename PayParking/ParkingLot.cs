using System;
using System.Collections.Generic;
using System.Text;

namespace PayParking
{
    public class ParkingLot
    {
        public bool Occupied { get; private set; }
        public string LicensePlate { get; private set; }
        public int LotNumber { get; private set; }
        public DateTime Arrival { get; private set; }


        public ParkingLot(int lotNumber)
        {
            LotNumber = lotNumber;
        }
         
        public void OccupyLot(string licensePlate)
        {
            Occupied = true;
            LicensePlate = licensePlate;
            Arrival = DateTime.Now;

        }

        public TimeSpan Departure()
        {
            DateTime departureTime = DateTime.Now;
            var stationedTime = departureTime - Arrival;
            Occupied = false;
            LicensePlate = String.Empty;
            return stationedTime;

        }

    }
}
