using AutoMapper;

namespace CrystalFlights.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Airport, AirportView>().ReverseMap();
            CreateMap<Airline, AirlineView>().ReverseMap();

            //CreateMap<Account, AccountModel>().ReverseMap()
            //    .ForMember(src => src.Owner, dest => dest.Ignore());
            //CreateMap<Owner, OwnerModel>().ReverseMap();
        }
    }
}
