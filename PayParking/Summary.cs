using System;
using System.Collections.Generic;
using System.Text;

namespace PayParking
{
    public class Summary
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int TotalPayment { get; set; }
        public string LicensePlate { get; set; }
        public TimeSpan TotalTime { get; set; }
        public string PricePerH { get; set; }
    }
}
