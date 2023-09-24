using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_ClientPackage")]
    public class ClientPackage : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "Description", FieldType = SqlDbType.VarChar, FieldLength = 1000)]
        public string? Description { get; set; }

        [CustomProperty(FieldName = "Amount", FieldType = SqlDbType.Float)]
        public double Amount { get; set; } = 0.00;

        [CustomProperty(FieldName = "UsersCount", FieldType = SqlDbType.Int)]
        public int UsersCount { get; set; } = 0;

        [CustomProperty(FieldName = "DaysCount", FieldType = SqlDbType.Int)]
        public int DaysCount { get; set; } = 0;

        [CustomProperty(FieldName = "BidsCount", FieldType = SqlDbType.Int)]
        public int BidsCount { get; set; } = 0;

        public ClientPackage() { }

        public ClientPackage(string name, string code, string description, double amount, int usersCount, int daysCount, int bidsCount, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.Name = name;
            this.Code = code;
            this.Description = description;
            this.Amount = amount;
            this.UsersCount = usersCount;
            this.DaysCount = daysCount;
            this.BidsCount = bidsCount;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
