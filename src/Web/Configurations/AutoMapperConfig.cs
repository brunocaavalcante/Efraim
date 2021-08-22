using AutoMapper;
using Business.Models;
using Web.Models;

namespace Web.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Membro, MembroViewModel>().ReverseMap();
            CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
        }
    }
}