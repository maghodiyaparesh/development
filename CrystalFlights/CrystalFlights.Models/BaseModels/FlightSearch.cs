using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_FlightSearch")]
    public class FlightSearch : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "FlightFrom", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string SessionId { get; set; }

        [CustomProperty(FieldName = "FlightFrom", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string FlightFromCode
        {
            get { return FlightFrom != null ? FlightFrom.Code : ""; }
            private set { FlightFrom.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airport? FlightFrom { get; set; }

        [CustomProperty(FieldName = "FlightTo", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string FlightToCode
        {
            get { return FlightTo != null ? FlightTo.Code : ""; }
            private set { FlightTo.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airport? FlightTo { get; set; }

        [CustomProperty(FieldName = "DepDate", FieldType = SqlDbType.DateTime)]
        public DateTime DepDate { get; set; }

        [CustomProperty(FieldName = "RetDate", FieldType = SqlDbType.DateTime)]
        public DateTime RetDate { get; set; }

        [CustomProperty(FieldName = "Adult", FieldType = SqlDbType.Int)]
        public int Adult { get; set; }

        [CustomProperty(FieldName = "Child", FieldType = SqlDbType.Int)]
        public int Child { get; set; }

        [CustomProperty(FieldName = "Infant", FieldType = SqlDbType.Int)]
        public int Infant { get; set; }

        [CustomProperty(FieldName = "Airline", FieldType = SqlDbType.VarChar, FieldLength = 2)]
        public string AirlineCode
        {
            get { return Airline != null ? Airline.Code : ""; }
            private set { Airline.Code = value; }
        }

        [CustomProperty(IgnoreField = true)]
        public Airline Airline { get; set; }

        [CustomProperty(FieldName = "FlightWay", FieldType = SqlDbType.Int)]
        public int FlightWayCode
        {
            get { return FlightWay != null ? (int)FlightWay : 0; }
            private set { FlightWay = (FlightWay)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public FlightWay FlightWay { get; set; }

        [CustomProperty(FieldName = "FlightClass", FieldType = SqlDbType.Int)]
        public int FlightClassCode
        {
            get { return FlightClass != null ? (int)FlightClass : 0; }
            private set { FlightClass = (FlightClass)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public FlightClass FlightClass { get; set; }

        [CustomProperty(FieldName = "FlightSearchSource", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string FlightSearchSource { get; set; }

        [CustomProperty(FieldName = "SiteCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string SiteCode { get; set; }

        [CustomProperty(FieldName = "IsDirect", FieldType = SqlDbType.Bit)]
        public bool IsDirect { get; set; }

        [CustomProperty(FieldName = "IsFlexi", FieldType = SqlDbType.Bit)]
        public bool IsFlexi { get; set; }

        [CustomProperty(FieldName = "IsDeepLink", FieldType = SqlDbType.Bit)]
        public bool IsDeepLink { get; set; }

        [CustomProperty(FieldName = "Currency", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string Currency { get; set; }

        public FlightSearch() { }
    }
}
