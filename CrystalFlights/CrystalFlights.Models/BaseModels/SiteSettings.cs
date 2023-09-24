using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_SiteSettings")]
    public class SiteSettings : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }
        
        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "Description", FieldType = SqlDbType.VarChar, FieldLength = 1000)]
        public string? Description { get; set; }

        public SiteSettings() { }

        public SiteSettings(long clientId, string name, string code, string description, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.ClientId = clientId;
            this.Name = name;
            this.Code = code;
            this.Description = description;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
