using System;

namespace CrystalFlights.Models
{
    public enum FeatureType : int
    {
        User = 1,
        Client = 2,
        Flight = 3,
        Widget = 4,
        Report = 5,
        Other = 6
    }

    public enum CommonStatus : int
    {
        Deactive = 0,
        Active = 1
    }

    public enum UserStatus : int
    {
        Deactive = 0,
        Active = 1,
        Block = 2
    }

    public enum PaymentStatus : int
    {
        Unpaid = 0,
        Paid = 1
    }

    public enum UserType : int
    {
        SuperAdmin = 1,
        Admin = 2,
        ClientAdmin = 3,
        Client = 4,
        Customer = 5
    }

    public enum AmountType : int
    {
        Percentage = 1,
        Fixed = 2
    }

    public enum ReviewType : int
    {
        Website = 1,
        Google = 2,
        Facebook = 3,
        TrustPilot = 4
    }

    public enum ProductType : int
    {
        Web = 1,
        Mobile = 2,
        Meta = 3
    }

    public enum ProviderType : int
    {
        Provider = 1,
        Vendor = 2,
        AtolProvider = 3
    }

    public enum FlightWay : int
    {
        None = 0,
        OneWay = 1,
        RoundTrip = 2
    }

    public enum FlightClass : int
    {
        None = 0,
        First = 1,
        Business = 2,
        EconomyPremium = 3,
        Economy = 4
    }

    public enum PassengerType : int
    {
        None = 0,
        Adult = 1,
        Child = 2,
        Infant = 3
    }

    public enum Gender : int
    {
        None = 0,
        Male = 1,
        Female = 2,
    }

    public enum FeatureName : int
    {
        Feature = 1,
        Role = 2,
        Admin = 3,

        Client = 4,
        ClientRole = 5,
        ClientEmployee = 6,
        Package = 7,
        Order = 8,
        Bill = 9,
        Coupon = 10,
        Enquiry = 11,
        Support = 12,

        Brand = 13,
        Vendor = 14,
        Provider = 15,
        AtolProvider = 16,
        ApiService = 17,

        City = 18,
        Country = 19,
        Airport = 20,
        Airline = 21,
        Settings = 22,
        CurrencyRate = 23,

        Leads = 24,
        FlightSearch = 25,
        PandaFlight = 26,
        PandaFlightFare = 27,
        PandaFlightSegment = 28,
        FlightMarkup = 29,
        FlightDeals = 30,

        FlightBooking = 41
    }

    public static class EnumUtils
    {
        public static bool Value(this CommonStatus value)
        {
            switch (value)
            {
                case CommonStatus.Active: return true;
                case CommonStatus.Deactive: return false;
                default: return false;
            }
        }

        public static int ToInt<T>(this T soure) where T : IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return (int)(IConvertible)soure;
        }

        public static string ToString<T>(this T soure) where T : IConvertible
        {
            return Enum.GetName(typeof(T), soure);
        }

        public static T ToEnum<T>(object value)
        {
            return (T)Enum.Parse(typeof(T), Enum.GetName(typeof(T), value));
        }
    }
}
