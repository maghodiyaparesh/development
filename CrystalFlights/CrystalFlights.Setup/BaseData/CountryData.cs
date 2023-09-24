using CrystalFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalFlights.Setup
{
    public static class CountryData
    {
        public static void SetupCountry()
        {
            Console.WriteLine("\n--Country setup process started");

            Console.WriteLine("--Country table create start");
            CreateCountryTable();

            Console.WriteLine("--Country data insert start");
            SetupCountryData();

            Console.WriteLine("--Country setup process finish");
        }

        private static void CreateCountryTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Country', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Country] ");

            query.Append("CREATE TABLE [dbo].[dr_Country]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[Name] [varchar](100) NULL,");
            query.Append("[Code] [varchar](2) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupCountryData()
        {
            List<Country> countries = new List<Country>()
            {
                new Country("India", "IN", CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            countries.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }
    }
}
