using System.Text;

namespace CrystalFlights.Setup
{
    public static class PandaFlightData
    {
        public static void SetupPandaFlight()
        {
            Console.WriteLine("\n--PandaFlight setup process started");

            Console.WriteLine("--PandaFlight table create start");
            CreatePandaFlightTable();

            Console.WriteLine("--PandaFlight setup process finish");
        }

        private static void CreatePandaFlightTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_PandaFlight', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_PandaFlight] ");

            query.Append("CREATE TABLE [dbo].[dr_PandaFlight]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[Provider] [varchar](20) NULL,");
            query.Append("[FlightRef] [varchar](255) NULL,");
            query.Append("[FromAirport] [varchar](3) NULL,");
            query.Append("[ToAirport] [varchar](3) NULL,");
            query.Append("[FlightClass] [int] NOT NULL,");
            query.Append("[Airline] [varchar](3) NULL,");
            query.Append("[Currency] [varchar](3) NULL,");
            query.Append("[IsDirect] [bit] NOT NULL,");
            query.Append("[IsDeepLink] [bit] NOT NULL,");
            query.Append("[IsFlexi] [bit] NOT NULL,");
            query.Append("[TotalTime] [int] NOT NULL,");
            query.Append("[TotalCost] [float] NOT NULL,");
            query.Append("[Stops] [int] NOT NULL,");
            query.Append("[FareRules] [varchar](1000) NULL,");
            query.Append("[LastTicketingDate] [datetime] NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_PandaFlight] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
