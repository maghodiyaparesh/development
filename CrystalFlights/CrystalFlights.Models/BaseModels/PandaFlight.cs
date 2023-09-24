using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_PandaFlight")]
    public class PandaFlight : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "Provider", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string Provider { get; set; }

        [CustomProperty(FieldName = "FlightRef", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string FlightRef { get; set; }

        [CustomProperty(FieldName = "FromAirport", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string FromAirportCode
        {
            get { return FromAirport != null ? FromAirport.Code : ""; }
            private set { FromAirport.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airport? FromAirport { get; set; }

        [CustomProperty(FieldName = "ToAirport", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string ToAirportCode
        {
            get { return ToAirport != null ? ToAirport.Code : ""; }
            private set { ToAirport.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airport? ToAirport { get; set; }

        [CustomProperty(FieldName = "FlightClass", FieldType = SqlDbType.Int)]
        public int FlightClassCode
        {
            get { return FlightClass != null ? (int)FlightClass : 0; }
            private set { FlightClass = (FlightClass)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public FlightClass FlightClass { get; set; }

        [CustomProperty(FieldName = "Airline", FieldType = SqlDbType.VarChar, FieldLength = 2)]
        public string AirlineCode
        {
            get { return Airline != null ? Airline.Code : ""; }
            private set { Airline.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airline Airline { get; set; }

        [CustomProperty(FieldName = "Currency", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string Currency { get; set; }

        [CustomProperty(FieldName = "IsDirect", FieldType = SqlDbType.Bit)]
        public bool IsDirect { get; set; }

        [CustomProperty(FieldName = "IsDeepLink", FieldType = SqlDbType.Bit)]
        public bool IsDeepLink { get; set; }

        [CustomProperty(FieldName = "IsFlexi", FieldType = SqlDbType.Bit)]
        public bool IsFlexi { get; set; }

        [CustomProperty(FieldName = "TotalTime", FieldType = SqlDbType.Int)]
        public int TotalTime { get; set; }

        [CustomProperty(FieldName = "TotalCost", FieldType = SqlDbType.Decimal)]
        public decimal TotalCost { get; set; }

        [CustomProperty(FieldName = "Stops", FieldType = SqlDbType.Int)]
        public int Stops { get; set; }

        [CustomProperty(FieldName = "FareRules", FieldType = SqlDbType.VarChar, FieldLength = 1000)]
        public string FareRules { get; set; }

        [CustomProperty(FieldName = "LastTicketingDate", FieldType = SqlDbType.Date)]
        public DateTime LastTicketingDate { get; set; }

        [CustomProperty(IgnoreField = true)]
        public PandaFlightFare FlightFare { get; set; }

        [CustomProperty(IgnoreField = true)]
        public List<PandaFlightSegment> Outbound { get; set; }

        [CustomProperty(IgnoreField = true)]
        public List<PandaFlightSegment> Inbound { get; set; }

        public PandaFlight() { }

        public PandaFlight(long clientId, string provider, string flightRef, Airport fromAirport, Airport toAirport, FlightClass flightClass, Airline airline, string currency, bool isDirect, bool isDeepLink, bool isFlexi, int totalTime, decimal totalCost, int stops, string fareRules, DateTime lastTicketingDate)
        {
            this.ClientId = clientId;
            this.Provider = provider;
            this.FlightRef = flightRef;
            this.FromAirport = fromAirport;
            this.ToAirport = toAirport;
            this.FlightClass = flightClass;
            this.Airline = airline;
            this.Currency = currency;
            this.IsDirect = isDirect;
            this.IsDeepLink = isDeepLink;
            this.IsFlexi = isFlexi;
            this.TotalTime = totalTime;
            this.TotalCost = totalCost;
            this.Stops = stops;
            this.FareRules = fareRules;
            this.LastTicketingDate = lastTicketingDate;
        }
    }
}
