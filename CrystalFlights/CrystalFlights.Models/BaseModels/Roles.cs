using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Roles")]
    public class Roles : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "FeaturesList", FieldType = SqlDbType.VarChar)]
        public string FeatureTypeId
        {
            get { return string.Join(",", FeaturesList.Select(d => string.Concat(d.Id, ":", Convert.ToInt16(d.IsRead), Convert.ToInt16(d.IsInsert), Convert.ToInt16(d.IsUpdate), Convert.ToInt16(d.IsDelete)))); }
            private set { FeaturesList = FeatureTypeId.Split(",").Select(d =>
            {
                var featureInfo = d.Split(":");
                return new Features(long.Parse(featureInfo[0]), bool.Parse(featureInfo[1].Substring(0, 1)), bool.Parse(featureInfo[1].Substring(1, 1)), bool.Parse(featureInfo[1].Substring(2, 1)), bool.Parse(featureInfo[1].Substring(3, 1)));
            }).ToList(); }
        }

        [CustomProperty(IgnoreField = true)]
        public List<Features>? FeaturesList { get; set; }

        [CustomProperty(FieldName = "ClientId", FieldType = SqlDbType.BigInt)]
        public long ClientId { get; set; }

        public Roles() { }

        public Roles(long id, string name, string code, long clientId, List<Features> features, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.ClientId = clientId;
            this.FeaturesList = features;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
