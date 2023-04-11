using AutoMapper;
using Opea.Api.ViewModels;
using Opea.Domain.Models;

namespace TesteApi.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
