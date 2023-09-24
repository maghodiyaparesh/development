using System.Text;

namespace CrystalFlights.Setup
{
    public static class LeadData
    {
        public static void SetupLead()
        {
            Console.WriteLine("\n--Lead setup process started");

            Console.WriteLine("--Lead table create start");
            CreateLeadTable();

            Console.WriteLine("--Lead setup process finish");
        }

        private static void CreateLeadTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Lead', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Lead] ");

            query.Append("CREATE TABLE [dbo].[dr_Lead]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
            query.Append("[CharCode] [varchar](5) NULL,");
            query.Append("[IsWebApp] [bit] NOT NULL,");
            query.Append("[IsMobileApp] [bit] NOT NULL,");
            query.Append("[IsMetaSearch] [bit] NOT NULL,");
            query.Append("[WebsiteUrl] [varchar](255) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Lead] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
