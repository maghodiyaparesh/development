using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalFlights.Setup
{
    public static class CurrencyRateData
    {
        public static void SetupCurrencyRate()
        {
            Console.WriteLine("\n--Currency Rate setup process started");

            Console.WriteLine("--Currency Rate table create start");
            CreateCurrencyRateTable();

            Console.WriteLine("--Currency Rate setup process finish");
        }

        private static void CreateCurrencyRateTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_CurrencyRate', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_CurrencyRate] ");

            query.Append("CREATE TABLE [dbo].[dr_CurrencyRate]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL,");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[CurrencyCode] [varchar](3) NULL,");
            query.Append("[ExchangeRate] [float] NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_CurrencyRate] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
