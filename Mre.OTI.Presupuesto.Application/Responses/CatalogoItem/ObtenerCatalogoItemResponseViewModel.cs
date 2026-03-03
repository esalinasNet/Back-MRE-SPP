using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Mapper;

namespace Mre.OTI.Presupuesto.Application.Responses.CatalogoItem
{
    public class ObtenerCatalogoItemResponseViewModel : IMapFrom<ObtenerCatalogoItemResponseDTO>
    {
        public int idCatalogo { get; set; }
        public int idCatalogoItem { get; set; }
        public int codigoCatalogoItem { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string abreviaturaCatalogoItem { get; set; }
        public string detalleCatalogoItem { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCatalogoItemResponseDTO, ObtenerCatalogoItemResponseViewModel>();
        }
    }
}
