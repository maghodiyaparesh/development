using System.Text;

namespace CrystalFlights.Setup
{
    public static class ClientEnquiryData
    {
        public static void SetupClientEnquiry()
        {
            Console.WriteLine("\n--Client Enquiry setup process started");

            Console.WriteLine("--Client Enquiry table create start");
            CreateClientEnquiryTable();

            Console.WriteLine("--Client Enquiry setup process finish");
        }

        private static void CreateClientEnquiryTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_ClientEnquiry', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_ClientEnquiry] ");

            query.Append("CREATE TABLE [dbo].[dr_ClientEnquiry]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Email] [varchar](50) NULL,");
            query.Append("[Phone] [varchar](20) NULL,");
            query.Append("[Company] [varchar](50) NULL,");
            query.Append("[WebsiteUrl] [varchar](255) NULL,");
            query.Append("[Country] [varchar](50) NULL,");
            query.Append("[Message] [varchar](1000) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_ClientEnquiry] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
