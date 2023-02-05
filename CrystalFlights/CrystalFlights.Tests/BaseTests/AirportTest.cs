using CrystalFlights.BO;
using CrystalFlights.Models;

namespace CrystalFlights.Tests.BaseTests
{
    public class AirportTest : TestingContext<IAirportRepository>
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        [Test]
        public void Airport_FindAll_Test()
        {
            int airportId = 1;
            string airportName = "DEL - New Delhi";

            GetMockFor<IAirportRepository>().Setup(x => x.FindAll()).Returns(new List<Airport> { new Airport() { AirportId = airportId, AirportName = airportName } }.AsQueryable());

            var result = ClassUnderTest.FindAll().ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result.First().AirportName, Is.EqualTo(airportName));
        }

        [Test]
        public void Airport_Create()
        {
            Airport airport = new Airport() { AirportName = "BOM - Bombay, Mumbai, Maharashtra" };
            GetMockFor<IAirportRepository>().Setup(x => x.FindAll()).Returns(new List<Airport> { new Airport() { AirportId = 1, AirportName = "DEL" } }.AsQueryable());

            var result = ClassUnderTest.SaveAirport(airport);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsCompleted, Is.True);
        }
    }
}
