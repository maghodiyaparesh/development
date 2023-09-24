using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_PandaFlightFare")]
    public class PandaFlightFare : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "FlightId", FieldType = SqlDbType.BigInt)]
        public long FlightId { get; set; }

        [CustomProperty(FieldName = "StartDate", FieldType = SqlDbType.DateTime)]
        public DateTime StartDate { get; set; }

        [CustomProperty(FieldName = "EndDate", FieldType = SqlDbType.DateTime)]
        public DateTime EndDate { get; set; }

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

        [CustomProperty(FieldName = "AdultFare", FieldType = SqlDbType.Decimal)]
        public decimal AdultFare { get; set; }

        [CustomProperty(FieldName = "ChildFare", FieldType = SqlDbType.Decimal)]
        public decimal ChildFare { get; set; }

        [CustomProperty(FieldName = "InfantFare", FieldType = SqlDbType.Decimal)]
        public decimal InfantFare { get; set; }

        [CustomProperty(FieldName = "AdultTax", FieldType = SqlDbType.Decimal)]
        public decimal AdultTax { get; set; }

        [CustomProperty(FieldName = "ChildTax", FieldType = SqlDbType.Decimal)]
        public decimal ChildTax { get; set; }

        [CustomProperty(FieldName = "InfantTax", FieldType = SqlDbType.Decimal)]
        public decimal InfantTax { get; set; }

        [CustomProperty(FieldName = "AdultMarkup", FieldType = SqlDbType.Decimal)]
        public decimal AdultMarkup { get; set; }

        [CustomProperty(FieldName = "ChildMarkup", FieldType = SqlDbType.Decimal)]
        public decimal ChildMarkup { get; set; }

        [CustomProperty(FieldName = "InfantMarkup", FieldType = SqlDbType.Decimal)]
        public decimal InfantMarkup { get; set; }

        public PandaFlightFare() { }

        public PandaFlightFare(long flightId, Airport fromAirport, Airport toAirport, DateTime startDate, DateTime endDate, decimal adultFare, decimal childFare, decimal infantFare, decimal adultTax, decimal childTax, decimal infantTax, decimal adultMarkup, decimal childMarkup, decimal infantMarkup)
        {
            this.FlightId = flightId;
            this.FromAirport = fromAirport;
            this.ToAirport = toAirport;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AdultFare = adultFare;
            this.ChildFare = childFare;
            this.InfantFare = infantFare;
            this.AdultTax = adultTax;
            this.ChildTax = childTax;
            this.InfantTax = infantTax;
            this.AdultMarkup = adultMarkup;
            this.ChildMarkup = childMarkup;
            this.InfantMarkup = infantMarkup;
        }
    }
}
