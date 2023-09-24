using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Users")]
    public class Users : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "RoleId", FieldType = SqlDbType.BigInt)]
        public long RoleId { get; set; }

        [CustomProperty(FieldName = "ClientCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? ClientCode { get; set; }

        [CustomProperty(FieldName = "FirstName", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? FirstName { get; set; }

        [CustomProperty(FieldName = "LastName", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? LastName { get; set; }

        [CustomProperty(FieldName = "DisplayName", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? DisplayName { get; set; }

        [CustomProperty(FieldName = "Email", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string Email { get; set; } = string.Empty;

        [CustomProperty(FieldName = "Password", FieldType = SqlDbType.VarChar)]
        public string Password { get; set; } = string.Empty;

        [CustomProperty(FieldName = "PasswordExpiry", FieldType = SqlDbType.DateTime)]
        public DateTime PasswordExpiry { get; set; }

        [CustomProperty(FieldName = "LoginAttempt", FieldType = SqlDbType.Int)]
        public int LoginAttempt { get; set; }

        [CustomProperty(FieldName = "Address", FieldType = SqlDbType.VarChar, FieldLength = 150)]
        public string? Address { get; set; }

        [CustomProperty(FieldName = "City", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? City { get; set; }

        [CustomProperty(FieldName = "State", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? State { get; set; }

        [CustomProperty(FieldName = "Country", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Country { get; set; }

        [CustomProperty(FieldName = "Phone", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Phone { get; set; }

        [CustomProperty(FieldName = "Mobile", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Mobile { get; set; }

        [CustomProperty(FieldName = "CreatedIp", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? CreatedIp { get; set; }

        [CustomProperty(FieldName = "Session", FieldType = SqlDbType.VarChar)]
        public string? Session { get; set; }

        [CustomProperty(FieldName = "KeySalt", FieldType = SqlDbType.VarChar, FieldLength = 255)]
        public string KeySalt { get; set; } = string.Empty;

        [CustomProperty(FieldName = "UserStatus", FieldType = SqlDbType.Int)]
        public int UserStatusId
        {
            get { return UserStatus != null ? (int)UserStatus : 0; }
            private set { UserStatus = (UserStatus)value; }
        }

        [CustomProperty(IgnoreField = true)]
        public UserStatus? UserStatus { get; set; }

        public Users() { }

        public Users(long roleId, string clientCode, string firstName, string lastName, string displayName, string email, string password, DateTime passwordExpiry, int loginAttempt, string address, string city, string state, string country, string phone, string mobile, string createdIp, string session, string keySalt, UserStatus userStatus, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.RoleId = roleId;
            this.ClientCode = clientCode;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DisplayName = displayName;
            this.Email = email;
            this.Password = password;
            this.PasswordExpiry = passwordExpiry;
            this.LoginAttempt = loginAttempt;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Phone = phone;
            this.Mobile = mobile;
            this.CreatedIp = createdIp;
            this.Session = session;
            this.KeySalt = keySalt;
            this.UserStatus= userStatus;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
