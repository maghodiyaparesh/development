using System.Text;

namespace CrystalFlights.Setup
{
    public static class PandaFlightSegmentData
    {
        public static void SetupPandaFlightSegment()
        {
            Console.WriteLine("\n--Panda Flight Segment setup process started");

            Console.WriteLine("--Panda Flight Segment table create start");
            CreatePandaFlightSegmentTable();

            Console.WriteLine("--Panda Flight Segment setup process finish");
        }

        private static void CreatePandaFlightSegmentTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_PandaFlightSegment', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_PandaFlightSegment] ");

            query.Append("CREATE TABLE [dbo].[dr_PandaFlightSegment]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[FlightId] [bigint] NULL,");
            query.Append("[SegmentRef] [varchar](255) NULL,");
            query.Append("[DepartureDate] [datetime] NULL,");
            query.Append("[ArrivalDate] [datetime] NULL,");
            query.Append("[FromAirport] [varchar](3) NULL,");
            query.Append("[ToAirport] [varchar](3) NULL,");
            query.Append("[Airline] [varchar](2) NULL,");
            query.Append("[OperatingAirline] [varchar](2) NULL,");
            query.Append("[FromTerminal] [varchar](20) NULL,");
            query.Append("[ToTerminal] [varchar](20) NULL,");
            query.Append("[FlightNo] [varchar](20) NULL,");
            query.Append("[EquipmentType] [varchar](20) NULL,");
            query.Append("[Distance] [int] NULL,");
            query.Append("[ETicket] [bit] NOT NULL,");
            query.Append("[ChangePlane] [bit] NOT NULL,");
            query.Append("[BaggageAllowance] [varchar](1000) NULL,");
            query.Append("[ElapsedTime] [int] NULL,");
            query.Append("[TotalTime] [int] NULL,");
            query.Append("[FlightClass] [int] NULL,");
            query.Append("[Availability] [varchar](20) NULL,");
            query.Append("[BookingCode] [varchar](20) NULL,");
            query.Append("[IsReturn] [bit] NOT NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_PandaFlightSegment] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }
    }
}
