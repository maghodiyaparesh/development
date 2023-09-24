using System.Data;

namespace CrystalFlights.Models
{
    public class CustomProperty : Attribute
    {
        public string FieldName { get; set; }
        public SqlDbType FieldType { get; set; }
        public int FieldLength { get; set; }
        public bool JsonConvert { get; set; }
        public bool IgnoreField { get; set; }

        public CustomProperty()
        {
            FieldName = null;
            FieldType = SqlDbType.VarChar;
            FieldLength = 0;
            JsonConvert = false;
            IgnoreField = false;
        }
    }
}
