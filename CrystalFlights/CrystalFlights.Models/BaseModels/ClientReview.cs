using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_ClientReview")]
    public class ClientReview : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "BrandId", FieldType = SqlDbType.BigInt)]
        public long BrandId { get; set; }

        [CustomProperty(FieldName = "ReviewType", FieldType = SqlDbType.Int)]
        public int ReviewTypeId
        {
            get { return (int)ReviewType; }
            private set { ReviewType = (ReviewType)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public ReviewType ReviewType { get; set; }

        [CustomProperty(FieldName = "Rating", FieldType = SqlDbType.Float)]
        public double? Rating { get; set; } = 0.00;

        [CustomProperty(FieldName = "Message", FieldType = SqlDbType.VarChar, FieldLength = 1000)]
        public string? Message { get; set; }

        [CustomProperty(FieldName = "ReviewerName", FieldType = SqlDbType.VarChar, FieldLength = 100)]
        public string? ReviewerName { get; set; }

        public ClientReview() { }

        public ClientReview(long clientId, long brandId, ReviewType reviewType, double rating, string message, string reviewerName, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.ClientId = clientId;
            this.BrandId = brandId;
            this.ReviewType = reviewType;
            this.Rating = rating;
            this.Message = message;
            this.ReviewerName = reviewerName;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
