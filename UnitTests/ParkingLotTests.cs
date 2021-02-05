using PayParking;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class ParkingLotTests
    {
        [Fact]
        public void OccupyLotTest()
        {
            //arange
            ParkingLot lot = new ParkingLot(2);
            
            //act
            lot.OccupyLot("license plate");
            
            //assert
            Assert.True(lot.Occupied);
        }
    }
}
