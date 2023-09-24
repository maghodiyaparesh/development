using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalFlights.Setup
{
    public static class SiteSettingData
    {
        public static void SetupSiteSetting()
        {
            Console.WriteLine("\n--Site Setting setup process started");

            Console.WriteLine("--Site Setting table create start");
            CreateSiteSettingTable();

            Console.WriteLine("--Site Setting setup process finish");
        }

        private static void CreateSiteSettingTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_SiteSetting', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_SiteSetting] ");

            query.Append("CREATE TABLE [dbo].[dr_SiteSetting]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Code] [varchar](50) NULL,");
            query.Append("[Description] [varchar](1000) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_SiteSetting] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
