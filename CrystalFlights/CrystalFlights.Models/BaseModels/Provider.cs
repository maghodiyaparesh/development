using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Provider")]
    public class Provider : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "ProviderType", FieldType = SqlDbType.Int)]
        public int ProviderTypeId
        {
            get { return ProviderType != null ? (int)ProviderType : 0; }
            private set { ProviderType = (ProviderType)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public ProviderType? ProviderType { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "CharCode", FieldType = SqlDbType.VarChar, FieldLength = 5)]
        public string? CharCode { get; set; }

        [CustomProperty(FieldName = "Address", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string? Address { get; set; }
        
        [CustomProperty(FieldName = "Email", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Email { get; set; }

        [CustomProperty(FieldName = "Phone", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Phone { get; set; }

        [CustomProperty(FieldName = "WebsiteUrl", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string? WebsiteUrl { get; set; }

        [CustomProperty(FieldName = "IsWebApp", FieldType = SqlDbType.Bit)]
        public bool IsWebApp { get; set; } = false;

        [CustomProperty(FieldName = "IsMobileApp", FieldType = SqlDbType.Bit)]
        public bool IsMobileApp { get; set; } = false;

        [CustomProperty(FieldName = "IsMetaSearch", FieldType = SqlDbType.Bit)]
        public bool IsMetaSearch { get; set; } = false;

        [CustomProperty(FieldName = "MetaData", FieldType = SqlDbType.Text)]
        public string? MetaData { get; set; }

        public Provider() { }

        public Provider(long clientId, ProviderType providerType, string name, string code, string charCode, string address, string email, string phone, string websiteUrl, bool isWebApp, bool isMobileApp, bool isMetaSearch, string metaData, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.ClientId = clientId;
            this.ProviderType = providerType;
            this.Name = name;
            this.Code = code;
            this.CharCode = charCode;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.WebsiteUrl = websiteUrl;
            this.IsWebApp = isWebApp;
            this.IsMobileApp = isMobileApp;
            this.IsMetaSearch = isMetaSearch;
            this.MetaData = metaData;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
