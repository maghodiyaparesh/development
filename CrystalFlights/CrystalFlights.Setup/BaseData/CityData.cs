using CrystalFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalFlights.Setup
{
    public static class CityData
    {
        public static void SetupCity()
        {
            Console.WriteLine("\n--City setup process started");

            Console.WriteLine("--City table create start");
            CreateCityTable();

            Console.WriteLine("--City data insert start");
            SetupCityData();

            Console.WriteLine("--City setup process finish");
        }

        private static void CreateCityTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_City', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_City] ");

            query.Append("CREATE TABLE [dbo].[dr_City](");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL,");
            query.Append("[Name] [varchar](100) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
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
            query.Append("CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupCityData()
        {
            List<City> cities = new List<City>()
            {
                new City("Rajkot", "RAJ", "Gujarat", "GJ", "India", "IN", "Asia", (decimal)0.1231, (decimal)1.231, "Rajkot, Gujarat, India", CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            cities.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }
    }
}
