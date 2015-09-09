using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentB;

namespace AssignmentB.Tests
{
    [TestClass]
    public class MarkupTests
    {
        [TestMethod]
        public void MarkUpisDeltaBetweenPublishedAndRateTest()
        {
            var calculator = new MarkupCalculator();
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;


            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;

            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);
            var markup = calculator.Getmarkup(published, netRate);

            Assert.AreEqual(50m, markup);
        }


        [TestMethod]
        [ExpectedException(typeof(FinanciallyUnviableRateException))]
        public void PublishedRateLessThanNetRateShouldThrowExceptionTest()
        {
            var calculator = new MarkupCalculator();
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 100m;

            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 150m;
            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);

            var markup = calculator.Getmarkup(published, netRate);


        }
       
        [TestMethod]
        public void MaxMarkupIsPublishedRateWithMinimumDiscountRateTest()
        {
            var calculator = new MarkupCalculator(10m,15m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;

            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);

            var markup = calculator.Getmarkup(published, netRate);
            Assert.AreEqual(35m, markup);
        }
        [TestMethod]
        [ExpectedException(typeof(FinanciallyUnviableRateException))]
        public void MaxMarkupShouldBeAlwaysGreaterthanDistributionCost()
        {

            var calculator = new MarkupCalculator(10m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 109m;

            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);

            var markup = calculator.Getmarkup(published, netRate);
            Assert.Fail("Did not throw any errors");
            
        }

        [TestMethod]
        public void MinimumMarginCanBeZeroTest()
        {

            var calculator = new MarkupCalculator();
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 110m;

            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);

            var markup = calculator.Getmarkup(published, netRate);
            var margin = markup - 10m;
            Assert.AreEqual(0m, margin);

        }

      

        [TestMethod]
        public void MarkupIsInverselyProportionalToNumberOfStops()
        {
            var calculator = new MarkupCalculator(20m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;
            published.NumberOfStops = 0;

            Itinerary netRate = new Itinerary();
            netRate.NumberOfStops = 0;
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);

            var markup = calculator.Getmarkup(published, netRate);

            Assert.AreEqual(50m, markup);

        }
        [TestMethod]
        public void MaximumStopsImplyMinimumMarkupTest()
        {
            var calculator = new MarkupCalculator(20m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;
            published.NumberOfStops = 5;

            Itinerary netRate = new Itinerary();
            netRate.NumberOfStops = 5;
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);

            var markup = calculator.Getmarkup(published, netRate);

            Assert.AreEqual(20m, markup);
        }

        [TestMethod]
        public void MaxMarkupShouldAlwaysExcludeDiscountTest()
        {
            var calculator = new MarkupCalculator(0m,15m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;
            

            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = new TimeSpan(1, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);
            

            var markup = calculator.Getmarkup(published, netRate);
            var result = markup+netRate.BaseFareInUSD;
            Assert.AreEqual(135, result);
 
        }
        [TestMethod]
        public void FlightTimeIsInverselyProportionalToMarkupTest()
        {
            var calculator = new MarkupCalculator(10m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;
            published.FlightTime = Itinerary.MinimumFlightTime;
            published.NumberOfStops = 0;


            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime =Itinerary.MinimumFlightTime;
            netRate.NumberOfStops = 0;
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);


            var markup = calculator.Getmarkup(published, netRate);

            Assert.AreEqual(50, markup);
 
        }
        [TestMethod]
        public void MaxFlightTimeMinimumMarkupTest()
        {
            var calculator = new MarkupCalculator(10m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;
            published.FlightTime = new TimeSpan(24, 0, 0);


            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = new TimeSpan(24, 0, 0);
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);


            var markup = calculator.Getmarkup(published, netRate);

            Assert.AreEqual(10m, markup);

        }
        [TestMethod]
        public void MinimumFlightLayOverTimeMaximumMarkupTest()
        {
            var calculator = new MarkupCalculator(10m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;
            published.TotalLayoverTime = new TimeSpan(0, 15, 0);


            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = Itinerary.MinimumFlightTime;
            netRate.TotalLayoverTime = new TimeSpan(0, 15, 0);


            var markup = calculator.Getmarkup(published, netRate);

            Assert.AreEqual(50m, markup);

        }
        [TestMethod]
        public void MaximumFlightLayOverTimeMinimumMarkupTest()
        {
            var calculator = new MarkupCalculator(10m);
            Itinerary published = new Itinerary();
            published.BaseFareInUSD = 150m;
            published.TotalLayoverTime = Itinerary.MaximumTotalLayoverTime;


            Itinerary netRate = new Itinerary();
            netRate.BaseFareInUSD = 100m;
            netRate.FlightTime = Itinerary.MinimumFlightTime;
            netRate.TotalLayoverTime = Itinerary.MaximumTotalLayoverTime;


            var markup = calculator.Getmarkup(published, netRate);

            Assert.AreEqual(10m, markup);

        }

    }
}
