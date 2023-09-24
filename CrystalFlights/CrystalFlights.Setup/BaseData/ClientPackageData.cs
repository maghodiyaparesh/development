using System.Text;
using CrystalFlights.Models;

namespace CrystalFlights.Setup
{
    public static class ClientPackageData
    {
        public static void SetupClientPackage()
        {
            Console.WriteLine("\n--Client Package setup process started");

            Console.WriteLine("--Client Package table create start");
            CreateClientPackageTable();

            Console.WriteLine("--Client Package data insert start");
            SetupClientPackageData();

            Console.WriteLine("--Client Package setup process finish");
        }

        private static void CreateClientPackageTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_ClientPackage', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_ClientPackage] ");

            query.Append("CREATE TABLE [dbo].[dr_ClientPackage]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
            query.Append("[Description] [varchar](1000) NULL,");
            query.Append("[Amount] [decimal](10,2) NULL,");
            query.Append("[UsersCount] [int] NULL,");
            query.Append("[DaysCount] [int] NULL,");
            query.Append("[BidsCount] [int] NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_ClientPackage] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupClientPackageData()
        {
            List<ClientPackage> clientPackages = new List<ClientPackage>()
            {
                new ClientPackage("Silver", "SILVER", "Silver Package", 5000, 10, 10, 10, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new ClientPackage("Gold", "GOLD", "Gold Package", 8000, 10, 10, 10, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new ClientPackage("Platinum", "PLATINUM", "Platinum Package", 10000, 10, 10, 10, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            clientPackages.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }
    }
}
