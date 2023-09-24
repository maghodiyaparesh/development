using CrystalFlights.Setup;

Console.WriteLine("Are you sure you want to start new setup of DB? [yes, no]");
string yourAnswer = Console.ReadLine();

if (yourAnswer != null && yourAnswer.Equals("yes"))
{
    Console.WriteLine("Setup process started");

    // Create feature table and insert data
    //FeatureData.SetupFeature();

    // Create role table and insert data
    //RoleData.SetupRole();

    // Create user table and insert data
    //UsersData.SetupUser();


    // Create client package table and insert data
    //ClientPackageData.SetupClientPackage();

    // Create client coupon table and insert data
    //ClientCouponData.SetupClientCoupon();

    // Create client order table
    //ClientOrderData.SetupClientOrder();

    // Create client enquiry table
    //ClientEnquiryData.SetupClientEnquiry();

    // Create client review table
    //ClientReviewData.SetupClientReview();

    // Create brand table
    //BrandData.SetupBrand();

    // Create provider table
    //ProviderData.SetupProvider();

    // Create api service table
    //ApiServiceData.SetupApiService();


    // Create airline table and insert data
    //AirlineData.SetupAirline();

    // Create airport table and insert data
    //AirportData.SetupAirport();

    // Create city table and insert data
    //CityData.SetupCity();

    // Create country table and insert data
    //CountryData.SetupCountry();

    // Create site setting table
    //SiteSettingData.SetupSiteSetting();

    // Create currency rate table
    //CurrencyRateData.SetupCurrencyRate();

    // Create lead table
    //LeadData.SetupLead();

    // Create flight search table
    //FlightSearchData.SetupFlightSearch();


    // Create panda flight table and insert data
    //PandaFlightData.SetupPandaFlight();

    // Create panda flight fare table and insert data
    //PandaFlightFareData.SetupPandaFlightFare();

    // Create panda flight segment table and insert data
    //PandaFlightSegmentData.SetupPandaFlightSegment();


    // Create customer table and insert data
    //UsersData.SetupCustomers();

    //UsersData.SetupClients();

    Console.WriteLine("\nSetup process finish");
    Console.WriteLine("\nPress enter to exit...");
    Console.ReadLine();
}