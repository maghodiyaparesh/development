using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Leads")]
    public class Leads : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "FlightSearchId", FieldType = SqlDbType.BigInt)]
        public long FlightSearchId { get; set; }

        public Leads() { }

        public Leads(long flightSearchId, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.FlightSearchId = flightSearchId;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
