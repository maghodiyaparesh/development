using System.Text;

namespace CrystalFlights.Setup
{
    public static class PandaFlightFareData
    {
        public static void SetupPandaFlightFare()
        {
            Console.WriteLine("\n--PandaFlightFare setup process started");

            Console.WriteLine("--PandaFlightFare table create start");
            CreatePandaFlightFareTable();

            Console.WriteLine("--PandaFlightFare setup process finish");
        }

        private static void CreatePandaFlightFareTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_PandaFlightFare', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_PandaFlightFare] ");

            query.Append("CREATE TABLE [dbo].[dr_PandaFlightFare]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[FlightId] [bigint] NULL,");
            query.Append("[StartDate] [datetime] NULL,");
            query.Append("[EndDate] [datetime] NULL,");
            query.Append("[FromAirport] [varchar](3) NULL,");
            query.Append("[ToAirport] [varchar](3) NULL,");
            query.Append("[AdultFare] [float] NULL,");
            query.Append("[ChildFare] [float] NULL,");
            query.Append("[InfantFare] [float] NULL,");
            query.Append("[AdultTax] [float] NULL,");
            query.Append("[ChildTax] [float] NULL,");
            query.Append("[InfantTax] [float] NULL,");
            query.Append("[AdultMarkup] [float] NULL,");
            query.Append("[ChildMarkup] [float] NULL,");
            query.Append("[InfantMarkup] [float] NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_PandaFlightFare] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
