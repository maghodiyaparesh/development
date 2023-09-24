using System.Data;

namespace CrystalFlights.Models
{
    public class BaseModel
    {
        [CustomProperty(FieldName = "IsActive", FieldType = SqlDbType.Bit)]
        public bool IsActive { get; set; } = true;
                
        [CustomProperty(FieldName = "ModifiedDate", FieldType = SqlDbType.DateTime)]
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        [CustomProperty(FieldName = "ModifiedBy", FieldType = SqlDbType.BigInt)]
        public long ModifiedBy { get; set; }

        [CustomProperty(FieldName = "CreatedDate", FieldType = SqlDbType.DateTime)]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [CustomProperty(FieldName = "CreatedBy", FieldType = SqlDbType.BigInt)]
        public long CreatedBy { get; set; }

        public object this[string propertyName]
        {
            get { return GetType().GetProperty(propertyName).GetValue(this, null); }
            set { GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }
    }
}
