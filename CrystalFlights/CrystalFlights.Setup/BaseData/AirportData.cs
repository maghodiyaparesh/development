using CrystalFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalFlights.Setup
{
    public static class AirportData
    {
        public static void SetupAirport()
        {
            Console.WriteLine("\n--Airport setup process started");

            Console.WriteLine("--Airport table create start");
            CreateAirportTable();

            Console.WriteLine("--Airport data insert start");
            SetupAirportData();

            Console.WriteLine("--Airport setup process finish");
        }

        private static void CreateAirportTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Airport', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Airport] ");

            query.Append("CREATE TABLE [dbo].[dr_Airport]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Code] [varchar](3) NULL,");
            query.Append("[CityCode] [varchar](20) NULL,");
            query.Append("[CityName] [varchar](100) NULL,");
            query.Append("[StateCode] [varchar](20) NULL,");
            query.Append("[StateName] [varchar](100) NULL,");
            query.Append("[CountryCode] [varchar](2) NULL,");
            query.Append("[CountryName] [varchar](100) NULL,");
            query.Append("[Continent] [varchar](20) NULL,");
            query.Append("[Latitude] [float] NULL,");
            query.Append("[Longtitude] [float] NULL,");
            query.Append("[DisplayName] [varchar](100) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupAirportData()
        {
            List<Airport> airports = new List<Airport>()
            {
                new Airport("Rajkot Airport", "RAJ", "Rajkot", "RAJ", "Gujarat", "GJ", "India", "IN", "Asia", (decimal)0.1231, (decimal)1.231, "Rajkot Airport, Gujarat, India", CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            airports.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }
    }
}
