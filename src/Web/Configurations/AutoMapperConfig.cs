using AutoMapper;
using Business.Models;
using Web.Models;

namespace Web.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
            CreateMap<Projeto, ProjetoViewModel>().ReverseMap();
            CreateMap<Caixa, CaixaViewModel>().ReverseMap();
            CreateMap<Permissao, PermissaoViewModel>().ReverseMap();
        }
    }
}