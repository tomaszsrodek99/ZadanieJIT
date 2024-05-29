using AutoMapper;
using Jit.Dtos;
using Jit.Models;

namespace Jit.Helpers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Visit, VisitDto>().ReverseMap();
        }
    }
}
