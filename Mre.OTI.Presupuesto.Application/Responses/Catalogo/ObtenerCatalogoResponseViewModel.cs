using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
using Mre.OTI.Presupuesto.Application.Mapper;

namespace Mre.OTI.Presupuesto.Application.Responses.Catalogo
{
    public class ObtenerCatalogoResponseViewModel : IMapFrom<ObtenerCatalogoResponseDTO>
    {

        public int idCatalogo { get; set; }
        public string descripcionCatalogo { get; set; }
        public string codigoCatalogo { get; set; }
        public bool manteniblePorUsuario { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCatalogoResponseDTO, ObtenerCatalogoResponseViewModel>();
        }
    }
}
