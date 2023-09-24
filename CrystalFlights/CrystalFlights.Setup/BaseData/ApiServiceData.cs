using System.Text;

namespace CrystalFlights.Setup
{
    public static class ApiServiceData
    {
        public static void SetupApiService()
        {
            Console.WriteLine("\n--Api Service setup process started");

            Console.WriteLine("--Api Service table create start");
            CreateApiServiceTable();

            Console.WriteLine("--Api Service setup process finish");
        }

        private static void CreateApiServiceTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_ApiService', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_ApiService] ");

            query.Append("CREATE TABLE [dbo].[dr_ApiService]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[ClientCode] [varchar](20) NULL,");
            query.Append("[BrandId] [bigint] NULL,");
            query.Append("[BrandCode] [varchar](20) NULL,");
            query.Append("[IsWebApp] [bit] NOT NULL,");
            query.Append("[IsMobileApp] [bit] NOT NULL,");
            query.Append("[IsMetaSearch] [bit] NOT NULL,");
            query.Append("[ProviderId] [bigint] NULL,");
            query.Append("[ProviderCode] [varchar](20) NULL,");
            query.Append("[VendorId] [bigint] NULL,");
            query.Append("[VendorCode] [varchar](20) NULL,");
            query.Append("[ApiKey] [varchar](255) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_ApiService] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
