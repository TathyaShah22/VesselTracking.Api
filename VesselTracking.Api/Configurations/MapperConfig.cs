using AutoMapper;
using VesselTracking.Api.Data;
using VesselTracking.Api.Models.Ports;
using VesselTracking.Api.Models.Vessel;

namespace VesselTracking.Api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Port, CreatePortDto>().ReverseMap(); 
            CreateMap<Port, GetPortDto>().ReverseMap();
            CreateMap<Port, PortDto>().ReverseMap();    
            CreateMap<Vessel, VesselDto>().ReverseMap();
            CreateMap<Port, UpdatedPortDto>().ReverseMap();
        }
    }
}
