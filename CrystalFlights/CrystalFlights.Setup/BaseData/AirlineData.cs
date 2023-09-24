using CrystalFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalFlights.Setup
{
    public static class AirlineData
    {
        public static void SetupAirline()
        {
            Console.WriteLine("\n--Airline setup process started");

            Console.WriteLine("--Airline table create start");
            CreateAirlineTable();

            Console.WriteLine("--Airline data insert start");
            SetupAirlineData();

            Console.WriteLine("--Airline setup process finish");
        }

        private static void CreateAirlineTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Airline', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Airline] ");

            query.Append("CREATE TABLE [dbo].[dr_Airline]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Airline] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupAirlineData()
        {
            List<Airline> airlines = new List<Airline>()
            {
                new Airline("Air India", "AI", CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            airlines.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }
    }
}
