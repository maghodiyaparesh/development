using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_ClinetEnquiry")]
    public class ClientEnquiry : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Email", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Email { get; set; }

        [CustomProperty(FieldName = "Phone", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Phone { get; set; }

        [CustomProperty(FieldName = "Company", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Company { get; set; }

        [CustomProperty(FieldName = "WebsiteUrl", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string? WebsiteUrl { get; set; }

        [CustomProperty(FieldName = "Country", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Country { get; set; }

        [CustomProperty(FieldName = "Message", FieldType = SqlDbType.VarChar, FieldLength = 1000)]
        public string? Message { get; set; }

        public ClientEnquiry() { }

        public ClientEnquiry(string name, string email, string phone, string company, string websiteUrl, string country, string message, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Company = company;
            this.WebsiteUrl = websiteUrl;
            this.Country = country;
            this.Message = message;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
