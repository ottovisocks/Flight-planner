using AutoMapper;
using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Dto.Responses;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Web.Final.Mappings
{
    public class AutoMapperConfiguration
    {
        public static IMapper GetConfig()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FlightRequest, Flight>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<AirportRequest, Airport>()
                    .ForMember(dest => dest.AirportCode, opt => opt.MapFrom(item => item.Airport))
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                cfg.CreateMap<Flight, FlightResponse>();
                cfg.CreateMap<Airport, AirportResponse>()
                    .ForMember(dest => dest.Airport, opt => opt.MapFrom(item => item.AirportCode));
            });

            var mapper = configuration.CreateMapper();

            return mapper;
        }
    }
}
