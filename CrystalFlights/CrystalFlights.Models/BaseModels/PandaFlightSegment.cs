using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_PandaFlightSegment")]
    public class PandaFlightSegment : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "FlightId", FieldType = SqlDbType.BigInt)]
        public long FlightId { get; set; }

        [CustomProperty(FieldName = "SegmentRef", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string SegmentRef { get; set; }

        [CustomProperty(FieldName = "DepartureDate", FieldType = SqlDbType.DateTime)]
        public DateTime DepartureDate { get; set; }

        [CustomProperty(FieldName = "ArrivalDate", FieldType = SqlDbType.DateTime)]
        public DateTime ArrivalDate { get; set; }

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

        [CustomProperty(FieldName = "Airline", FieldType = SqlDbType.VarChar, FieldLength = 2)]
        public string AirlineCode
        {
            get { return Airline != null ? Airline.Code : ""; }
            private set { Airline.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airline Airline { get; set; }

        [CustomProperty(FieldName = "OperatingAirline", FieldType = SqlDbType.VarChar, FieldLength = 2)]
        public string OperatingAirlineCode
        {
            get { return OperatingAirline != null ? OperatingAirline.Code : ""; }
            private set { OperatingAirline.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airline OperatingAirline { get; set; }

        [CustomProperty(FieldName = "FromTerminal", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string FromTerminal { get; set; }

        [CustomProperty(FieldName = "ToTerminal", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string ToTerminal { get; set; }

        [CustomProperty(FieldName = "FlightNo", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string FlightNo { get; set; }

        [CustomProperty(FieldName = "EquipmentType", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string EquipmentType { get; set; }

        [CustomProperty(FieldName = "Distance", FieldType = SqlDbType.Int)]
        public int Distance { get; set; }

        [CustomProperty(FieldName = "ETicket", FieldType = SqlDbType.Bit)]
        public bool ETicket { get; set; }

        [CustomProperty(FieldName = "ChangePlane", FieldType = SqlDbType.Bit)]
        public bool ChangePlane { get; set; }

        [CustomProperty(FieldName = "BaggageAllowance", FieldType = SqlDbType.VarChar, FieldLength = 1000)]
        public string BaggageAllowance { get; set; }

        [CustomProperty(FieldName = "ElapsedTime", FieldType = SqlDbType.Int)]
        public int ElapsedTime { get; set; }

        [CustomProperty(FieldName = "TotalTime", FieldType = SqlDbType.Int)]
        public int TotalTime { get; set; }

        [CustomProperty(FieldName = "FlightClass", FieldType = SqlDbType.Int)]
        public int FlightClassCode
        {
            get { return FlightClass != null ? (int)FlightClass : 0; }
            private set { FlightClass = (FlightClass)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public FlightClass FlightClass { get; set; }

        [CustomProperty(FieldName = "Availability", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string Availability { get; set; }

        [CustomProperty(FieldName = "BookingCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string BookingCode { get; set; }

        [CustomProperty(FieldName = "IsReturn", FieldType = SqlDbType.Bit)]
        public bool IsReturn { get; set; }

        public PandaFlightSegment() { }

        public PandaFlightSegment(long flightId, string segmentRef, DateTime departureDate, DateTime arrivalDate, Airport fromAirport, Airport toAirport, Airline airline, Airline operatingAirline, string fromTerminal, string toTerminal, string flightNo, string equipmentType, int distance, bool eTicket, bool changePlane, string baggageAllowance, int elapsedTime, int totalTime, FlightClass flightClass, string availability, string bookingCode, bool isReturn)
        {
            this.FlightId = flightId;
            this.SegmentRef = segmentRef;
            this.DepartureDate = departureDate;
            this.ArrivalDate = arrivalDate;
            this.FromAirport = fromAirport;
            this.ToAirport = toAirport;
            this.Airline = airline;
            this.OperatingAirline = operatingAirline;
            this.FromTerminal = fromTerminal;
            this.ToTerminal = toTerminal;
            this.FlightNo = flightNo;
            this.EquipmentType = equipmentType;
            this.Distance = distance;
            this.ETicket = eTicket;
            this.ChangePlane = changePlane;
            this.BaggageAllowance = baggageAllowance;
            this.ElapsedTime = elapsedTime;
            this.TotalTime = totalTime;
            this.FlightClass = flightClass;
            this.Availability = availability;
            this.BookingCode = bookingCode;
            this.IsReturn = isReturn;
        }
    }
}
