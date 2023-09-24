using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Sockets;

namespace CrystalFlights.Models
{
    [Table("dr_ClientOrder")]
    public class ClientOrder : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "PackageId", FieldType = SqlDbType.BigInt)]
        public long PackageId { get; set; }

        [CustomProperty(FieldName = "PackageName", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? PackageName { get; set; }

        [CustomProperty(FieldName = "PackageCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? PackageCode { get; set; }

        [CustomProperty(FieldName = "Description", FieldType = SqlDbType.VarChar, FieldLength = 1000)]
        public string? Description { get; set; }

        [CustomProperty(FieldName = "PackageAmount", FieldType = SqlDbType.Float)]
        public double PackageAmount { get; set; } = 0.00;

        [CustomProperty(FieldName = "UserCount", FieldType = SqlDbType.Int)]
        public int UserCount { get; set; } = 0;

        [CustomProperty(FieldName = "DaysCount", FieldType = SqlDbType.Int)]
        public int DaysCount { get; set; } = 0;

        [CustomProperty(FieldName = "BidsCount", FieldType = SqlDbType.Int)]
        public int BidsCount { get; set; } = 0;

        [CustomProperty(FieldName = "PaymentStatus", FieldType = SqlDbType.Int)]
        public int PaymentStatusId
        {
            get { return (int)PaymentStatus; }
            private set { PaymentStatus = (PaymentStatus)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public PaymentStatus PaymentStatus { get; set; } = 0;

        [CustomProperty(FieldName = "DiscountCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? DiscountCode { get; set; }

        [CustomProperty(FieldName = "DiscountAmount", FieldType = SqlDbType.Float)]
        public double DiscountAmount { get; set; } = 0.00;

        [CustomProperty(FieldName = "FinalAmount", FieldType = SqlDbType.Float)]
        public double FinalAmount { get; set; } = 0.00;

        public ClientOrder() { }

        public ClientOrder(long clientId, long packageId, string packageName, string packageCode, string description, double packageAmount, int usersCount, int daysCount, int bidsCount, PaymentStatus paymentStatus, string discountCode, double discountAmount, double finalAmount, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.ClientId = clientId;
            this.PackageId = packageId;
            this.PackageName = packageName;
            this.PackageCode = packageCode;
            this.Description = description;
            this.PackageAmount = packageAmount;
            this.UserCount = usersCount;
            this.DaysCount = daysCount;
            this.BidsCount = bidsCount;
            this.PaymentStatus = paymentStatus;
            this.DiscountCode = discountCode;
            this.DiscountAmount = discountAmount;
            this.FinalAmount = finalAmount;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
