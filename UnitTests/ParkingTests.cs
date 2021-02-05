using PayParking;
using System;
using Xunit;

namespace UnitTests
{
    public class ParkingTests
    {
        [Fact]
        public void ParkingLotsShouldBeInitializedOnConstructor()
        {
            //arange
            //act
            var systemUnderTest = new Parking(5,10,5);

            //assert
            Assert.Equal(5, systemUnderTest.ParkingLots.Count);
        }

        [Fact]
        public void ShouldReturnNoSpaceWhenParkingFull()
        {
            //arange
            Parking park = new Parking(2,10,5);
            park.OccupyFreeLot("license1");
            park.OccupyFreeLot("license2");
            //act
            string answer = park.OccupyFreeLot("lic3");

            //assert
            Assert.Equal("No parking space available", answer);
        }

        [Fact]
        public void ShouldReturnLotNumberWhenParkingAvailable()
        {
            //arange
            Parking park = new Parking(2,10,5);
            park.OccupyFreeLot("license1");
            //act
            string answer = park.OccupyFreeLot("lic2");

            //assert
            Assert.Equal("Please proceed to lot 1", answer);
        }
    }
}
