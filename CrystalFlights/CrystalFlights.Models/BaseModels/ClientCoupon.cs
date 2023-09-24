using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_ClientCoupon")]
    public class ClientCoupon : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "AmountType", FieldType = SqlDbType.Int)]
        public int AmountTypeId
        {
            get { return (int)AmountType; }
            private set { AmountType = (AmountType)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public AmountType AmountType { get; set; }

        [CustomProperty(FieldName = "Amount", FieldType = SqlDbType.Float)]
        public double Amount { get; set; } = 0.00;

        [CustomProperty(FieldName = "UsersCount", FieldType = SqlDbType.Int)]
        public int UsersCount { get; set; } = 0;

        public ClientCoupon() { }

        public ClientCoupon(string name, string code, AmountType amountType, double amount, int usersCount, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.Name = name;
            this.Code = code;
            this.AmountType = amountType;
            this.Amount = amount;
            this.UsersCount = usersCount;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
