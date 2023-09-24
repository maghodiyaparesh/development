using System.Text;
using CrystalFlights.Models;

namespace CrystalFlights.Setup
{
    public static class FeatureData
    {
        public static void SetupFeature()
        {
            Console.WriteLine("\n--Feature setup process started");

            Console.WriteLine("--Feature table create start");
            CreateFeatureTable();

            Console.WriteLine("--Feature data insert start");
            SetupFeatureData();

            Console.WriteLine("--Feature setup process finish");
        }

        private static void CreateFeatureTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_Features', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_Features] ");

            query.Append("CREATE TABLE [dbo].[dr_Features]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[Name] [varchar](20) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
            query.Append("[FeatureType] [int] NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupFeatureData()
        {
            List<Features> features = new List<Features>()
            {
                new Features("Feature", FeatureName.Feature.ToString(), FeatureType.User, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Role", FeatureName.Role.ToString(), FeatureType.User, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Admin", FeatureName.Admin.ToString(), FeatureType.User, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),

                new Features("Client", FeatureName.Client.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Client Role", FeatureName.ClientRole.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Client Employee", FeatureName.ClientEmployee.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Package", FeatureName.Package.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Order", FeatureName.Order.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Bill", FeatureName.Bill.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Coupon", FeatureName.Coupon.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Enquiry", FeatureName.Enquiry.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Support", FeatureName.Support.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),

                new Features("Brand", FeatureName.Brand.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Vendor", FeatureName.Vendor.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Provider", FeatureName.Provider.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("ATOL Provider", FeatureName.AtolProvider.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Api Service", FeatureName.ApiService.ToString(), FeatureType.Client, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),

                new Features("City", FeatureName.City.ToString(), FeatureType.Other, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Country", FeatureName.Country.ToString(), FeatureType.Other, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Airport", FeatureName.Airport.ToString(), FeatureType.Other, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Airline", FeatureName.Airline.ToString(), FeatureType.Other, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Settings", FeatureName.Settings.ToString(), FeatureType.Other, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Currency Rate", FeatureName.CurrencyRate.ToString(), FeatureType.Other, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),

                new Features("Leads", FeatureName.Leads.ToString(), FeatureType.Flight, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Flight Search", FeatureName.FlightSearch.ToString(), FeatureType.Flight, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Flight", FeatureName.PandaFlight.ToString(), FeatureType.Flight, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Flight Fare", FeatureName.PandaFlightFare.ToString(), FeatureType.Flight, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Flight Segment", FeatureName.PandaFlightSegment.ToString(), FeatureType.Flight, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Flight Markup", FeatureName.FlightMarkup.ToString(), FeatureType.Flight, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new Features("Flight Deals", FeatureName.FlightDeals.ToString(), FeatureType.Flight, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),

                new Features("Flight Booking", FeatureName.FlightBooking.ToString(), FeatureType.Other, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            
            //features.Add(new Features("Sales Widget", "SALESWIDGET", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("MySalesWidget", "MYSALESWIDGET", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("ProfitWidget", "PROFITWIDGET", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("MyProfitWidget", "MYPROFITWIDGET", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("IncentiveWidget", "INCENTIVEWIDGET", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("TaskBoard", "TASKBOARD", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("TicketBoard", "TICKETBOARD", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("ActivityBoard", "ACTIVITYBOARD", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));

            //features.Add(new Features("EmployeeReport", "EMPLOYEEREPORT", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("PassengerReport", "PASSENGERREPORT", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("FlightsReport", "FLIGHTSREPORT", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("PassengerPaymentReport", "PASSENGERPAYMENTREPORT", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("SupplierPaymentReport", "SUPPLIERPAYMENTREPORT", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));
            //features.Add(new Features("SalesReport", "SALESREPORT", CommonStatus.Active, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id, DateTime.Now));

            features.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }

        public static List<Features> GetDefaultCustomerFeature(string code)
        {
            if (string.IsNullOrEmpty(code))
                return new List<Features>();

            List<Features> featureList = new List<Features>();

            //switch (code)
            //{
            //    case "ADMIN":
            //        featureList = FeatureData.SetupFeature(new List<string>() {
            //            FeatureType.Client.ToString().ToUpper()
            //        });
            //        break;
            //}

            return featureList;
        }
    }
}
