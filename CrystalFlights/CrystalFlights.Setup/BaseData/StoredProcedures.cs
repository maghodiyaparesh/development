using System.Text;
using CrystalFlights.Models;

namespace CrystalFlights.Setup
{
    public static class StoredProcedures
    {
        public static void SetupStoredProcedures()
        {
            Console.WriteLine("\n--Stored Procedures setup process started");

            Console.WriteLine("--Feature table SPs create start");
            CreateFeatureSPs();

            Console.WriteLine("--Stored Procedures setup process finish");
        }

        private static void CreateFeatureSPs()
        {
            StringBuilder query = new StringBuilder("");

            query.Append("Save/Update Feature");
            query.Append("Delete Feature");
            query.Append("Get All By Filter Feature");
            query.Append("Get By Id Feature");

            //SqlHelper.CreateTable(query.ToString());
        }
    }
}