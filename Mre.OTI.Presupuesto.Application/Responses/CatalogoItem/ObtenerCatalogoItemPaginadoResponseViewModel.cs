using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Mapper;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.CatalogoItem
{
    public class ObtenerCatalogoItemPaginadoResponseViewModel : IMapFrom<ObtenerCatalogoItemPaginadoResponseDTO>
    {

        public int idCatalogo { get; set; }
        public int idCatalogoItem { get; set; }

        public int codigoCatalogoItem { get; set; }

        public string detalleCatalogoItem { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string AbreviaturaCatalogoItem { get; set; }
        public int registro { get; set; }
        public bool eliminado { get; set; }
        public int orden { get; set; }

        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCatalogoItemPaginadoResponseDTO, ObtenerCatalogoItemPaginadoResponseViewModel>();
        }
    }

    public class dtCatalogoItemPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerCatalogoItemPaginadoResponseViewModel> data { get; set; }
    }
}
