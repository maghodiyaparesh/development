using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Country")]
    public class Country : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 100)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 2)]
        public string? Code { get; set; }

        public Country() { }

        public Country(string name, string code, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
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
