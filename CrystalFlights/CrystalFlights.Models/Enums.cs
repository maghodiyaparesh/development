namespace CrystalFlights.Models
{
    public enum FeatureType : int
    {
        Other = 0,
        User = 1,
        Client = 2,
        Flight = 3,
        Widget = 4,
        Report = 5
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

    public enum AmountType : int
    {
        Percentage = 0,
        Fixed = 1
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
}
