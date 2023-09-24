using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_CurrencyRate")]
    public class CurrencyRate : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        [CustomProperty(FieldName = "CurrencyCode", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string? CurrencyCode { get; set; }

        [CustomProperty(FieldName = "ExchangeRate", FieldType = SqlDbType.Decimal)]
        public decimal ExchangeRate { get; set; }

        public CurrencyRate() { }

        public CurrencyRate(long clientId, string currencyCode, decimal exchangeRate, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.ClientId = clientId;
            this.CurrencyCode = currencyCode;
            this.ExchangeRate = exchangeRate;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
