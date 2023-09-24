using CrystalFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static CrystalFlights.Models.Features;

namespace CrystalFlights.Setup
{
    public static class RoleData
    {
        public static void SetupRole()
        {
            Console.WriteLine("\n--Role setup process started");

            Console.WriteLine("--Role table insert start");
            CreateRoleTable();

            Console.WriteLine("--Role data insert start");
            SetupRoleData();

            Console.WriteLine("--Role setup process finish");
        }

        private static void CreateRoleTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Roles', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Roles] ");

            query.Append("CREATE TABLE [dbo].[dr_Roles]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[ClientId] [bigint] NULL,");
            query.Append("[Name] [varchar](20) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
            query.Append("[FeaturesList] [varchar](max) NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupRoleData()
        {
            List<Roles> roles = new List<Roles>()
            {
                new Roles(UserType.SuperAdmin.ToInt(), "Super Admin", "SUPERADMIN", UsersData.Default().Id, GetDefaultRolePermission("SUPERADMIN"), CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Roles(UserType.Admin.ToInt(), "Admin", "ADMIN", UsersData.Default().Id, GetDefaultRolePermission("ADMIN"), CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Roles(UserType.ClientAdmin.ToInt(), "Client Admin", "CLIENTADMIN", UsersData.Default().Id, GetDefaultRolePermission("CLIENTADMIN"), CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Roles(UserType.Customer.ToInt(), "Customer", "CUSTOMER", UsersData.Default().Id, GetDefaultRolePermission("CUSTOMER"), CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            roles.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }

        private static List<Features> GetDefaultRolePermission(string code)
        {
            List<Features> features = new List<Features>();

            if (string.IsNullOrEmpty(code))
                return features;

            switch (code)
            {
                case "SUPERADMIN":
                    features = new List<Features>()
                    {
                        new Features(FeatureName.Feature.ToInt(), true, true, true, true),
                        new Features(FeatureName.Role.ToInt(), true, true, true, true),
                        new Features(FeatureName.Admin.ToInt(), true, true, true, true),

                        new Features(FeatureName.Client.ToInt(), true, true, true, true),
                        new Features(FeatureName.ClientRole.ToInt(), true, true, true, true),
                        new Features(FeatureName.ClientEmployee.ToInt(), true, true, true, true),
                        new Features(FeatureName.Package.ToInt(), true, true, true, true),
                        new Features(FeatureName.Order.ToInt(), true, true, true, true),
                        new Features(FeatureName.Bill.ToInt(), true, true, true, true),
                        new Features(FeatureName.Coupon.ToInt(), true, true, true, true),
                        new Features(FeatureName.Enquiry.ToInt(), true, true, true, true),
                        new Features(FeatureName.Support.ToInt(), true, true, true, true),

                        new Features(FeatureName.Brand.ToInt(), true, true, true, true),
                        new Features(FeatureName.Vendor.ToInt(), true, true, true, true),
                        new Features(FeatureName.Provider.ToInt(), true, true, true, true),
                        new Features(FeatureName.AtolProvider.ToInt(), true, true, true, true),
                        new Features(FeatureName.ApiService.ToInt(), true, true, true, true),

                        new Features(FeatureName.City.ToInt(), true, true, true, true),
                        new Features(FeatureName.Country.ToInt(), true, true, true, true),
                        new Features(FeatureName.Airport.ToInt(), true, true, true, true),
                        new Features(FeatureName.Airline.ToInt(), true, true, true, true),
                        new Features(FeatureName.Settings.ToInt(), true, true, true, true),
                        new Features(FeatureName.CurrencyRate.ToInt(), true, true, true, true),

                        new Features(FeatureName.Leads.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightSearch.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlight.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlightFare.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlightSegment.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightMarkup.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightDeals.ToInt(), true, true, true, true)
                    };
                    break;
                case "ADMIN":
                    features = new List<Features>()
                    {
                        new Features(FeatureName.Client.ToInt(), true, true, true, true),
                        new Features(FeatureName.ClientRole.ToInt(), true, true, true, true),
                        new Features(FeatureName.ClientEmployee.ToInt(), true, true, true, true),
                        new Features(FeatureName.Package.ToInt(), true, true, true, true),
                        new Features(FeatureName.Order.ToInt(), true, true, true, true),
                        new Features(FeatureName.Bill.ToInt(), true, true, true, true),
                        new Features(FeatureName.Coupon.ToInt(), true, true, true, true),
                        new Features(FeatureName.Enquiry.ToInt(), true, true, true, true),
                        new Features(FeatureName.Support.ToInt(), true, true, true, true),

                        new Features(FeatureName.Brand.ToInt(), true, true, true, true),
                        new Features(FeatureName.Vendor.ToInt(), true, true, true, true),
                        new Features(FeatureName.Provider.ToInt(), true, true, true, true),
                        new Features(FeatureName.AtolProvider.ToInt(), true, true, true, true),
                        new Features(FeatureName.ApiService.ToInt(), true, true, true, true),

                        new Features(FeatureName.City.ToInt(), true, true, true, true),
                        new Features(FeatureName.Country.ToInt(), true, true, true, true),
                        new Features(FeatureName.Airport.ToInt(), true, true, true, true),
                        new Features(FeatureName.Airline.ToInt(), true, true, true, true),
                        new Features(FeatureName.Settings.ToInt(), true, true, true, true),
                        new Features(FeatureName.CurrencyRate.ToInt(), true, true, true, true),

                        new Features(FeatureName.Leads.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightSearch.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlight.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlightFare.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlightSegment.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightMarkup.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightDeals.ToInt(), true, true, true, true)
                    };
                    break;
                case "CLIENTADMIN":
                    features = new List<Features>()
                    {
                        new Features(FeatureName.ClientRole.ToInt(), true, true, true, true),
                        new Features(FeatureName.ClientEmployee.ToInt(), true, true, true, true),
                        new Features(FeatureName.Bill.ToInt(), true, true, true, true),
                        new Features(FeatureName.Enquiry.ToInt(), true, true, true, true),
                        new Features(FeatureName.Support.ToInt(), true, true, true, true),

                        new Features(FeatureName.City.ToInt(), true, true, true, true),
                        new Features(FeatureName.Country.ToInt(), true, true, true, true),
                        new Features(FeatureName.Airport.ToInt(), true, true, true, true),
                        new Features(FeatureName.Airline.ToInt(), true, true, true, true),
                        new Features(FeatureName.Settings.ToInt(), true, true, true, true),
                        new Features(FeatureName.CurrencyRate.ToInt(), true, true, true, true),

                        new Features(FeatureName.Leads.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightSearch.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlight.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlightFare.ToInt(), true, true, true, true),
                        new Features(FeatureName.PandaFlightSegment.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightMarkup.ToInt(), true, true, true, true),
                        new Features(FeatureName.FlightDeals.ToInt(), true, true, true, true)
                    };
                    break;
                case "CUSTOMER":
                    features = new List<Features>()
                    {
                        new Features(FeatureName.FlightBooking.ToInt(), true, true, true, true)
                    };
                    break;
            }

            return features;
        }
    }
}
