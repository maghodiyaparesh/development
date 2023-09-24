using System.Text;

namespace CrystalFlights.Setup
{
    public static class ClientReviewData
    {
        public static void SetupClientReview()
        {
            Console.WriteLine("\n--Client Review setup process started");

            Console.WriteLine("--Client Review table create start");
            CreateClientReviewTable();

            Console.WriteLine("--Client Review setup process finish");
        }

        private static void CreateClientReviewTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_ClientReview', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_ClientReview] ");

            query.Append("CREATE TABLE [dbo].[dr_ClientReview]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[BrandId] [bigint] NULL,");
            query.Append("[ReviewType] [int] NULL,");
            query.Append("[Rating] [decimal](10,2) NULL,");
            query.Append("[Message] [varchar](1000) NULL,");
            query.Append("[ReviewerName] [varchar](100) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_ClientReview] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
