using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_ApiService")]
    public class ApiService : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "ClientCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? ClientCode { get; set; }

        [CustomProperty(FieldName = "BrandId", FieldType = SqlDbType.BigInt)]
        public long BrandId { get; set; }

        [CustomProperty(FieldName = "BrandCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? BrandCode { get; set; }

        [CustomProperty(FieldName = "IsWebApp", FieldType = SqlDbType.Bit)]
        public bool IsWebApp { get; set; } = false;

        [CustomProperty(FieldName = "IsMobileApp", FieldType = SqlDbType.Bit)]
        public bool IsMobileApp { get; set; } = false;

        [CustomProperty(FieldName = "IsMetaSearch", FieldType = SqlDbType.Bit)]
        public bool IsMetaSearch { get; set; } = false;

        [CustomProperty(FieldName = "ProviderId", FieldType = SqlDbType.BigInt)]
        public long ProviderId { get; set; }

        [CustomProperty(FieldName = "ProviderCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? ProviderCode { get; set; }

        [CustomProperty(FieldName = "VendorId", FieldType = SqlDbType.BigInt)]
        public long VendorId { get; set; }

        [CustomProperty(FieldName = "VendorCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? VendorCode { get; set; }

        [CustomProperty(FieldName = "ApiKey", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string? ApiKey { get; set; }

        public ApiService() { }

        public ApiService(long clientId, string clientCode, long brandId, string brandCode, bool isWebApp, bool isMobileApp, bool isMetaSearch, long providerId, string providerCode, long vendorId, string vendorCode, string apiKey, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.ClientId = clientId;
            this.ClientCode = clientCode;
            this.BrandId = brandId;
            this.BrandCode = brandCode;
            this.IsWebApp = isWebApp;
            this.IsMobileApp = isMobileApp;
            this.IsMetaSearch = isMetaSearch;
            this.ProviderId = providerId;
            this.ProviderCode = providerCode;
            this.VendorId = vendorId;
            this.VendorCode = vendorCode;
            this.ApiKey = apiKey;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
