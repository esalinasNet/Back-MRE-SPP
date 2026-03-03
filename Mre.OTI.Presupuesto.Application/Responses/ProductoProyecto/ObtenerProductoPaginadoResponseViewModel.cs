using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.ProductoProyecto;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto
{
    public class ObtenerProductoPaginadoResponseViewModel : IMapFrom<ObtenerProductoPaginadoResponseDTO>
    {
        public int idProducto { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string producto { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerProductoPaginadoResponseDTO, ObtenerProductoPaginadoResponseViewModel>();
        }
    }

    public class dtProductoPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerProductoPaginadoResponseViewModel> data { get; set; }
    }
}
