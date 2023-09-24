using CrystalFlights.Models;
using System.Text;

namespace CrystalFlights.Setup
{
    public static class UsersData
    {
        public static void SetupUser()
        {
            Console.WriteLine("\n--User setup process started");

            Console.WriteLine("--User table create start");
            CreateUserTable();

            Console.WriteLine("--User data insert start");
            SetupUserData();

            Console.WriteLine("--User setup process finish");
        }

        private static void CreateUserTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Users', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Users] ");

            query.Append("CREATE TABLE [dbo].[dr_Users]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[RoleId] [bigint] NOT NULL,");
            query.Append("[ClientCode] [varchar](20) NULL,");
            query.Append("[FirstName] [varchar](50) NULL,");
            query.Append("[LastName] [varchar](50) NULL,");
            query.Append("[DisplayName] [varchar](50) NULL,");
            query.Append("[Email] [varchar](50) NULL,");
            query.Append("[Password] [varchar](max) NULL,");
            query.Append("[PasswordExpiry] [datetime] NULL,");
            query.Append("[LoginAttempt] [int] NULL,");
            query.Append("[Address] [varchar](150) NULL,");
            query.Append("[City] [varchar](20) NULL,");
            query.Append("[State] [varchar](20) NULL,");
            query.Append("[Country] [varchar](20) NULL,");
            query.Append("[Phone] [varchar](20) NULL,");
            query.Append("[Mobile] [varchar](20) NULL,");
            query.Append("[CreatedIp] [varchar](20) NULL,");
            query.Append("[Session] [text] NULL,");
            query.Append("[KeySalt] [varchar](255) NULL,");
            query.Append("[UserStatus] [int] NOT NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupUserData()
        {
            List<Users> users = new List<Users>()
            {
                new Users(UserType.SuperAdmin.ToInt(), UserType.SuperAdmin.ToString(), "Paresh", "Maghodiya", "Paresh Maghodiya", "paresh@flightscorp.com", Functions.EncryptString("!System007"), DateTime.Now.AddDays(90), 0, "", "", "", "IN", "", "+918511126126", "1.1.1.1", Functions.EncryptString(DateTime.Now.ToString("YYYY-MM-DD")), Functions.GenerateRandomString(), UserStatus.Active, true, DateTime.Now, Default().Id, DateTime.Now, Default().Id),
                new Users(UserType.Admin.ToInt(), UserType.Admin.ToString(), "Rajesh", "Maghodiya", "Rajesh Maghodiya", "rajesh@flightscorp.com", Functions.EncryptString("!System007"), DateTime.Now.AddDays(90), 0, "", "", "", "IN", "", "+919624891750", "1.1.1.1", Functions.EncryptString(DateTime.Now.ToString("YYYY-MM-DD")), Functions.GenerateRandomString(), UserStatus.Active, true, DateTime.Now, Default().Id, DateTime.Now, Default().Id),
                new Users(UserType.ClientAdmin.ToInt(), UserType.ClientAdmin.ToString(), "Mahesh", "Nakum", "Mahesh Nakum", "mahesh@flightscorp.com", Functions.EncryptString("!System007"), DateTime.Now.AddDays(90), 0, "", "", "", "IN", "", "+919924022166", "1.1.1.1", Functions.EncryptString(DateTime.Now.ToString("YYYY-MM-DD")), Functions.GenerateRandomString(), UserStatus.Active, true, DateTime.Now, Default().Id, DateTime.Now, Default().Id),
                new Users(UserType.Customer.ToInt(), UserType.Customer.ToString(), "Ramesh", "Parmar", "Ramesh Parmar", "ramesh@flightscorp.com", Functions.EncryptString("!System007"), DateTime.Now.AddDays(90), 0, "", "", "", "IN", "", "+919924022122", "1.1.1.1", Functions.EncryptString(DateTime.Now.ToString("YYYY-MM-DD")), Functions.GenerateRandomString(), UserStatus.Active, true, DateTime.Now, Default().Id, DateTime.Now, Default().Id)
            };

            users.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }

        public static Users Default()
        {
            Users u = new Users();

            u.Id = 1;
            u.RoleId = 1;
            u.FirstName = "Paresh";
            u.LastName = "Maghodiya";
            u.DisplayName = u.FirstName + " " + u.LastName;
            u.ClientCode = "PARESH";
            u.Email = "paresh@flightscorp.com";
            u.Password = Functions.EncryptString("!System007");
            u.PasswordExpiry = DateTime.Now.AddDays(365);
            u.UserStatus = UserStatus.Active;
            u.Session = Functions.EncryptString(DateTime.Now.ToString("YYYY-MM-DD"));
            u.CreatedIp = "1.1.1.1";

            return u;
        }

        public static void SetupClients()
        {
            Console.WriteLine("\n--Client setup process started");

            Console.WriteLine("--Client data insert start");
            SetupClientData();

            Console.WriteLine("--Client setup process finish");
        }

        private static void SetupClientData()
        {
            // setup client role

            // setup client user

            // setup client brand

            // setup client provider, vendor, atol provider

            // setup api service

            // setup inhouse data
        }

        public static void SetupCustomers()
        {
            Console.WriteLine("\n--Customer setup process started");

            Console.WriteLine("--Customer data insert start");
            //SetupClientData();

            Console.WriteLine("--Customer setup process finish");
        }
    }
}
