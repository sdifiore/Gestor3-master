using AutoMapper;
using Gestor.ViewModels;

namespace Gestor.Models
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PlanejVenda, PlanejVendasViewModel>();
        }
    }
}