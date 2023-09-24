using System.Text;

namespace CrystalFlights.Setup
{
    public static class ClientOrderData
    {
        public static void SetupClientOrder()
        {
            Console.WriteLine("\n--Client Order setup process started");

            Console.WriteLine("--Client Order table create start");
            CreateClientOrderTable();

            Console.WriteLine("--Client Order setup process finish");
        }

        private static void CreateClientOrderTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_ClientOrder', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_ClientOrder] ");

            query.Append("CREATE TABLE [dbo].[dr_ClientOrder]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[ClientPackageId] [bigint] NULL,");
            query.Append("[PackageName] [varchar](50) NULL,");
            query.Append("[PackageCode] [varchar](20) NULL,");
            query.Append("[Description] [varchar](1000) NULL,");
            query.Append("[PackageAmount] [decimal](10,2) NULL,");
            query.Append("[UsersCount] [int] NULL,");
            query.Append("[DaysCount] [int] NULL,");
            query.Append("[BidsCount] [int] NULL,");
            query.Append("[PaymentStatus] [int] NULL,");
            query.Append("[DiscountCode] [varchar](20) NULL,");
            query.Append("[DiscountAmount] [decimal](10,2) NULL,");
            query.Append("[FinalAmount] [decimal](10,2) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_ClientOrder] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
