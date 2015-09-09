using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AssignmentC;
using AssignmentC.Rules;

namespace AssignmentC.Tests
{
    [TestClass]
    public class FlightSortTestCases
    {
        [TestMethod]
        public void TestSouthWestAirlineNegotiation()
        {
            List<Itinerary> demoList = new List<Itinerary>();
            List<Itinerary> expectedList = new List<Itinerary>();

            SearchEngine testSearchEngine = new SearchEngine();

            Itinerary itineraryObject = new Itinerary();
            Itinerary itineraryObject1 = new Itinerary();
            Itinerary itineraryObject2 = new Itinerary();


            itineraryObject.OriginAirportCode = "Dallas";
            itineraryObject.DestinationAirportCode = "JFK";
            itineraryObject.FlightTime = TimeSpan.Zero;
            itineraryObject.NumberOfStops = 5;
            itineraryObject.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject.Airline = "American Airlines";
            itineraryObject.ClassOfService = "Business Class";
            itineraryObject.UtcDepartureTime = new DateTime(2008, 6, 19);
            itineraryObject.UtcArrivalTime = new DateTime(2008, 6, 20);
            itineraryObject.BaseFareInUSD = 190;
            itineraryObject.MarkupInUSD = 10;

            itineraryObject1.OriginAirportCode = "Washington";
            itineraryObject1.DestinationAirportCode = "DeltaAirways";
            itineraryObject1.FlightTime = TimeSpan.Zero;
            itineraryObject1.NumberOfStops = 5;
            itineraryObject.ClassOfService = "Business Class";
            itineraryObject1.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject1.Airline = "SouthWest Airlines";
            itineraryObject1.UtcDepartureTime = new DateTime(2008, 6, 19);
            itineraryObject1.UtcArrivalTime = new DateTime(2008, 6, 20);
            itineraryObject1.BaseFareInUSD = 180;
            itineraryObject1.MarkupInUSD = 36;

            itineraryObject2.OriginAirportCode = "Dallas";
            itineraryObject2.DestinationAirportCode = "DeltaAirways";
            itineraryObject2.FlightTime = TimeSpan.Zero;
            itineraryObject2.NumberOfStops = 5;
            itineraryObject2.ClassOfService = "Business Class";
            itineraryObject2.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject2.Airline = "SouthWest Airlines";
            itineraryObject2.UtcDepartureTime = new DateTime(2008, 6, 19, 7, 0, 0);
            itineraryObject2.UtcArrivalTime = new DateTime(2008, 6, 20, 7, 0, 0);
            itineraryObject2.BaseFareInUSD = 180;
            itineraryObject2.MarkupInUSD = 36;


            demoList.Add(itineraryObject1);
            demoList.Add(itineraryObject);
            demoList.Add(itineraryObject2);

            expectedList.Add(itineraryObject2);
            expectedList.Add(itineraryObject1);


            var actualResultList = testSearchEngine.Process(demoList);
            CollectionAssert.AreEqual(actualResultList, expectedList);
        }
        [TestMethod]
        public void TestSpiritAirlineNegotiation()
        {
            List<Itinerary> demoList = new List<Itinerary>();
            List<Itinerary> expectedList = new List<Itinerary>();

            SearchEngine testSearchEngine = new SearchEngine();

            Itinerary itineraryObject = new Itinerary();
            Itinerary itineraryObject1 = new Itinerary();
            Itinerary itineraryObject2 = new Itinerary();

            itineraryObject.OriginAirportCode = "Vegas";
            itineraryObject.DestinationAirportCode = "JFK";
            itineraryObject.FlightTime = TimeSpan.Zero;
            itineraryObject.NumberOfStops = 2;
            itineraryObject.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject.Airline = "American Airlines";
            itineraryObject.UtcDepartureTime = new DateTime(2015, 9, 19);
            itineraryObject.UtcArrivalTime = new DateTime(2015, 9, 20);
            itineraryObject.BaseFareInUSD = 190;
            itineraryObject.MarkupInUSD = 10;

            itineraryObject1.OriginAirportCode = "Washington";
            itineraryObject1.DestinationAirportCode = "DeltaAirways";
            itineraryObject1.FlightTime = TimeSpan.Zero;
            itineraryObject1.NumberOfStops = 5;
            itineraryObject1.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject1.Airline = "SouthWest Airlines";
            itineraryObject1.UtcDepartureTime = new DateTime(2015, 9, 9);
            itineraryObject1.UtcArrivalTime = new DateTime(2015, 6, 9);
            itineraryObject1.BaseFareInUSD = 180;
            itineraryObject1.MarkupInUSD = 36;

            itineraryObject2.OriginAirportCode = "Newyork";
            itineraryObject2.DestinationAirportCode = "DC";
            itineraryObject2.FlightTime = TimeSpan.Zero;
            itineraryObject2.NumberOfStops = 5;
            itineraryObject2.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject2.Airline = "Spirit Airlines";
            itineraryObject2.UtcDepartureTime = new DateTime(2015, 9, 15);
            itineraryObject2.UtcArrivalTime = new DateTime(2015, 9, 16);
            itineraryObject2.BaseFareInUSD = 180;
            itineraryObject2.MarkupInUSD = 36;


            demoList.Add(itineraryObject1);
            demoList.Add(itineraryObject2);
            demoList.Add(itineraryObject);

            expectedList.Add(itineraryObject2);
            expectedList.Add(itineraryObject);
            expectedList.Add(itineraryObject1);

            var actualResultList = testSearchEngine.Process(demoList);


            CollectionAssert.AreEqual(actualResultList, expectedList);

        }
        [TestMethod]
        public void ImpressionCampaignNegotiationTest()
        {
            List<Itinerary> demoList = new List<Itinerary>();
            List<Itinerary> expectedList = new List<Itinerary>();

            SearchEngine testSearchEngine = new SearchEngine();

            Itinerary itineraryObject = new Itinerary();
            Itinerary itineraryObject1 = new Itinerary();
            Itinerary itineraryObject2 = new Itinerary();

            itineraryObject.OriginAirportCode = "Vegas";
            itineraryObject.DestinationAirportCode = "JFK";
            itineraryObject.FlightTime = TimeSpan.Zero;
            itineraryObject.NumberOfStops = 2;
            itineraryObject.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject.Airline = "American Airlines";
            itineraryObject.UtcDepartureTime = new DateTime(2015, 9, 19);
            itineraryObject.UtcArrivalTime = new DateTime(2015, 9, 20);
            itineraryObject.BaseFareInUSD = 190;
            itineraryObject.MarkupInUSD = 10;

            itineraryObject1.OriginAirportCode = "Washington";
            itineraryObject1.DestinationAirportCode = "DeltaAirways";
            itineraryObject1.FlightTime = TimeSpan.Zero;
            itineraryObject1.NumberOfStops = 5;
            itineraryObject1.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject1.Airline = "Indigo Airlines";
            itineraryObject1.UtcDepartureTime = new DateTime(2015, 9, 9);
            itineraryObject1.UtcArrivalTime = new DateTime(2015, 6, 9);
            itineraryObject1.BaseFareInUSD = 180;
            itineraryObject1.MarkupInUSD = 36;

            itineraryObject2.OriginAirportCode = "Newyork";
            itineraryObject2.DestinationAirportCode = "DC";
            itineraryObject2.FlightTime = TimeSpan.Zero;
            itineraryObject2.NumberOfStops = 5;
            itineraryObject2.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject2.Airline = "SpiceJet Airlines";
            itineraryObject2.UtcDepartureTime = new DateTime(2015, 9, 15);
            itineraryObject2.UtcArrivalTime = new DateTime(2015, 9, 16);
            itineraryObject2.BaseFareInUSD = 180;
            itineraryObject2.MarkupInUSD = 36;


            demoList.Add(itineraryObject1);
            demoList.Add(itineraryObject2);
            demoList.Add(itineraryObject);

            expectedList.Add(itineraryObject);
            expectedList.Add(itineraryObject1);
            expectedList.Add(itineraryObject2);

            var actualResultList = testSearchEngine.Process(demoList);


            CollectionAssert.AreEqual(actualResultList, expectedList);
 
        }
        [TestMethod]
        public void AmericaAirlineNegotiationTest()
        {
            List<Itinerary> demoList = new List<Itinerary>();
            List<Itinerary> expectedList = new List<Itinerary>();

            SearchEngine testSearchEngine = new SearchEngine();

            Itinerary itineraryObject = new Itinerary();
            Itinerary itineraryObject1 = new Itinerary();
            Itinerary itineraryObject2 = new Itinerary();

            itineraryObject.OriginAirportCode = "Vegas";
            itineraryObject.DestinationAirportCode = "JFK";
            itineraryObject.FlightTime = TimeSpan.Zero;
            itineraryObject.NumberOfStops = 2;
            itineraryObject.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject.Airline = "American Airlines";
            itineraryObject.UtcDepartureTime = new DateTime(2015, 12, 1);
            itineraryObject.UtcArrivalTime = new DateTime(2015, 12, 2);
            itineraryObject.BaseFareInUSD = 190;
            itineraryObject.MarkupInUSD = 10;
            itineraryObject.RoundtripReturnTime = new DateTime(2015, 12, 15);

            itineraryObject1.OriginAirportCode = "Washington";
            itineraryObject1.DestinationAirportCode = "DeltaAirways";
            itineraryObject1.FlightTime = TimeSpan.Zero;
            itineraryObject1.NumberOfStops = 5;
            itineraryObject1.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject1.Airline = "Indigo Airlines";
            itineraryObject1.UtcDepartureTime = new DateTime(2015, 9, 9);
            itineraryObject1.UtcArrivalTime = new DateTime(2015, 6, 9);
            itineraryObject1.BaseFareInUSD = 180;
            itineraryObject1.MarkupInUSD = 36;

            itineraryObject2.OriginAirportCode = "Newyork";
            itineraryObject2.DestinationAirportCode = "DC";
            itineraryObject2.FlightTime = TimeSpan.Zero;
            itineraryObject2.NumberOfStops = 5;
            itineraryObject2.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject2.Airline = "SpiceJet Airlines";
            itineraryObject2.UtcDepartureTime = new DateTime(2015, 9, 15);
            itineraryObject2.UtcArrivalTime = new DateTime(2015, 9, 16);
            itineraryObject2.BaseFareInUSD = 180;
            itineraryObject2.MarkupInUSD = 36;


            demoList.Add(itineraryObject1);
            demoList.Add(itineraryObject2);
            demoList.Add(itineraryObject);

            expectedList.Add(itineraryObject);
            expectedList.Add(itineraryObject1);
            expectedList.Add(itineraryObject2);

            var actualResultList = testSearchEngine.Process(demoList);


            CollectionAssert.AreEqual(actualResultList, expectedList);

        }
        [TestMethod]
        public void SortingResultsOverMarkUpTest()
        {
            List<Itinerary> demoList = new List<Itinerary>();
            List<Itinerary> expectedList = new List<Itinerary>();

            SearchEngine testSearchEngine = new SearchEngine();

            Itinerary itineraryObject = new Itinerary();
            Itinerary itineraryObject1 = new Itinerary();
            Itinerary itineraryObject2 = new Itinerary();

            itineraryObject.OriginAirportCode = "Vegas";
            itineraryObject.DestinationAirportCode = "JFK";
            itineraryObject.FlightTime = TimeSpan.Zero;
            itineraryObject.NumberOfStops = 2;
            itineraryObject.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject.Airline ="kk Airlines";
            itineraryObject.UtcDepartureTime = new DateTime(2015, 1, 1);
            itineraryObject.UtcArrivalTime = new DateTime(2015, 1, 2);
            itineraryObject.BaseFareInUSD = 190;
            itineraryObject.MarkupInUSD = 10;
            itineraryObject.RoundtripReturnTime = new DateTime(2015, 1, 15);

            itineraryObject1.OriginAirportCode = "Washington";
            itineraryObject1.DestinationAirportCode = "DeltaAirways";
            itineraryObject1.FlightTime = TimeSpan.Zero;
            itineraryObject1.NumberOfStops = 5;
            itineraryObject1.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject1.Airline = "Indigo Airlines";
            itineraryObject1.UtcDepartureTime = new DateTime(2015, 9, 9);
            itineraryObject1.UtcArrivalTime = new DateTime(2015, 6, 9);
            itineraryObject1.BaseFareInUSD = 180;
            itineraryObject1.MarkupInUSD = 36;

            itineraryObject2.OriginAirportCode = "Newyork";
            itineraryObject2.DestinationAirportCode = "DC";
            itineraryObject2.FlightTime = TimeSpan.Zero;
            itineraryObject2.NumberOfStops = 5;
            itineraryObject2.TotalLayoverTime = TimeSpan.Zero;
            itineraryObject2.Airline = "SpiceJet Airlines";
            itineraryObject2.UtcDepartureTime = new DateTime(2015, 9, 15);
            itineraryObject2.UtcArrivalTime = new DateTime(2015, 9, 16);
            itineraryObject2.BaseFareInUSD = 180;
            itineraryObject2.MarkupInUSD = 36;


            demoList.Add(itineraryObject2);
            demoList.Add(itineraryObject1);
            demoList.Add(itineraryObject);

            expectedList.Add(itineraryObject);
            expectedList.Add(itineraryObject2);
            expectedList.Add(itineraryObject1);

            var actualResultList = testSearchEngine.Process(demoList);


            CollectionAssert.AreEqual(actualResultList, expectedList);

        }

    }
}
