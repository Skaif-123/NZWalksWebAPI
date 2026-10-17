using AutoMapper;
using NZWalksWebAPI.Dtos.Vessel;
using NZWalksWebAPI.Models.Vessels;

namespace NZWalksWebAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Vessel,GetVesselsRequestDto>().ReverseMap();
            CreateMap<Vessel, CreateVesselDto>().ReverseMap();
        }
    }
}
