using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Airline")]
    public class Airline : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 2)]
        public string? Code { get; set; }

        public Airline() { }

        public Airline(string name, string code, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.Name = name;
            this.Code = code;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
