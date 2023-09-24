using System.Text;

namespace CrystalFlights.Setup
{
    public static class ProviderData
    {
        public static void SetupProvider()
        {
            Console.WriteLine("\n--Provider setup process started");

            Console.WriteLine("--Provider table create start");
            CreateProviderTable();

            Console.WriteLine("--Provider setup process finish");
        }

        private static void CreateProviderTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Provider', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Provider] ");

            query.Append("CREATE TABLE [dbo].[dr_Provider]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[ProviderType] [int] NULL,");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
            query.Append("[CharCode] [varchar](5) NULL,");
            query.Append("[Address] [varchar](255) NULL,");
            query.Append("[Email] [varchar](50) NULL,");
            query.Append("[Phone] [varchar](20) NULL,");
            query.Append("[WebsiteUrl] [varchar](255) NULL,");
            query.Append("[IsWebApp] [bit] NOT NULL,");
            query.Append("[IsMobileApp] [bit] NOT NULL,");
            query.Append("[IsMetaSearch] [bit] NOT NULL,");
            query.Append("[MetaData] [varchar](max) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
