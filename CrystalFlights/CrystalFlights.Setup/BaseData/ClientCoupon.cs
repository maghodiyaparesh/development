using System.Text;
using CrystalFlights.Models;

namespace CrystalFlights.Setup
{
    public static class ClientCouponData
    {
        public static void SetupClientCoupon()
        {
            Console.WriteLine("\n--Client Coupon setup process started");

            Console.WriteLine("--Client Coupon table create start");
            CreateClientCouponTable();

            Console.WriteLine("--Client Coupon data insert start");
            SetupClientCouponData();

            Console.WriteLine("--Client Coupon setup process finish");
        }

        private static void CreateClientCouponTable()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("IF OBJECT_ID('dbo.dr_ClientCoupon', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_ClientCoupon] ");

            query.Append("CREATE TABLE [dbo].[dr_ClientCoupon]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append("[Name] [varchar](50) NULL,");
            query.Append("[Code] [varchar](20) NULL,");
            query.Append("[AmountType] [int] NULL,");
            query.Append("[Amount] [decimal](10,2) NULL,");
            query.Append("[UsersCount] [int] NULL,");
            query.Append("[IsActive] [bit] NOT NULL,");
            query.Append("[ModifiedDate] [datetime] NULL,");
            query.Append("[ModifiedBy] [bigint] NULL,");
            query.Append("[CreatedDate] [datetime] NULL,");
            query.Append("[CreatedBy] [bigint] NULL,");
            query.Append("CONSTRAINT [PK_ClientCoupon] PRIMARY KEY CLUSTERED([Id] ASC) )");

            SqlHelper.CreateTable(query.ToString());
        }

        private static void SetupClientCouponData()
        {
            List<ClientCoupon> clientCoupons = new List<ClientCoupon>()
            {
                new ClientCoupon("Welcome Bonuse", "WELCOME", AmountType.Percentage, 5, 10, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id),
                new ClientCoupon("First Welcome", "FIRST", AmountType.Fixed, 300, 10, CommonStatus.Active.Value(), DateTime.Now, UsersData.Default().Id, DateTime.Now, UsersData.Default().Id)
            };

            clientCoupons.ForEach(r =>
            {
                SqlHelper.Save(r);
            });
        }
    }
}
