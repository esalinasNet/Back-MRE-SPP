using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
using Mre.OTI.Presupuesto.Application.Mapper;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Catalogo
{
    public class ObtenerCatalogoPaginadoResponseViewModel : IMapFrom<ObtenerCatalogoPaginadoResponseDTO>
    {

        public int idCatalogo { get; set; }
        public string nombreCatalogo { get; set; }
        public string codigoCatalogo { get; set; }
        public bool mantenible { get; set; }
        public int registro { get; set; }

        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCatalogoPaginadoResponseDTO, ObtenerCatalogoPaginadoResponseViewModel>();
        }
    }

    public class dtCatalogoPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerCatalogoPaginadoResponseViewModel> data { get; set; }
    }
}
