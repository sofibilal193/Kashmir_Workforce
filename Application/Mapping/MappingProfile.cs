using AutoMapper;
using KC.API.Model;
using KC.API.DTO;

namespace KC.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Labour to LabourDto
            CreateMap<Labour, LabourDto>();
        }
    }
}
