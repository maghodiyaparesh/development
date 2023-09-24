using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Brand")]
    public class Brand : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "CharCode", FieldType = SqlDbType.VarChar, FieldLength = 5)]
        public string? CharCode { get; set; }

        [CustomProperty(FieldName = "IsWebApp", FieldType = SqlDbType.Bit)]
        public bool IsWebApp { get; set; } = false;

        [CustomProperty(FieldName = "IsMobileApp", FieldType = SqlDbType.Bit)]
        public bool IsMobileApp { get; set; } = false;

        [CustomProperty(FieldName = "IsMetaSearch", FieldType = SqlDbType.Bit)]
        public bool IsMetaSearch { get; set; } = false;

        [CustomProperty(FieldName = "WebsiteUrl", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string? WebsiteUrl { get; set; }

        public Brand() { }

        public Brand(long clientId, string name, string code, string charCode, bool isWebApp, bool isMobileApp, bool isMetaSearch, string websiteUrl, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.ClientId = clientId;
            this.Name = name;
            this.Code = code;
            this.CharCode = charCode;
            this.IsWebApp = isWebApp;
            this.IsMobileApp = isMobileApp;
            this.IsMetaSearch = isMetaSearch;
            this.WebsiteUrl = websiteUrl;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
