using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Features")]
    public class Features : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "FeatureType", FieldType = SqlDbType.Int)]
        public int FeatureTypeId
        {
            get { return FeatureType != null ? (int)FeatureType : 0; }
            private set { FeatureType = (FeatureType)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public FeatureType? FeatureType { get; set; }

        [CustomProperty(IgnoreField = true)]
        public bool IsRead { get; set; } = false;

        [CustomProperty(IgnoreField = true)]
        public bool IsInsert { get; set; } = false;

        [CustomProperty(IgnoreField = true)]
        public bool IsUpdate { get; set; } = false;

        [CustomProperty(IgnoreField = true)]
        public bool IsDelete { get; set; } = false;

        public Features() { }

        public Features(long id, bool isRead = false, bool isInsert = false, bool isUpdate = false, bool isDelete = false)
        {
            this.Id = id;
            this.IsRead = isRead;
            this.IsInsert = isInsert;
            this.IsUpdate = isUpdate;
            this.IsDelete = isDelete;
        }

        public Features(string name, string code, FeatureType featureType, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.Name = name;
            this.Code = code;
            this.FeatureType = featureType;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
