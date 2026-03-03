using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto
{
    public class ObtenerEspecificaGastoPaginadoResponseViewModel : IMapFrom<ObtenerEspecificaGastoPaginadoResponseDTO>
    {
        public int idClasificador { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string clasificador { get; set; }
        public string descripcion { get; set; }
        public string descripcion_detallada { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public int id_Categoria_Gasto { get; set; }
        public string tipo_Clasificador { get; set; }
        public bool? activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerEspecificaGastoPaginadoResponseDTO, ObtenerEspecificaGastoPaginadoResponseViewModel>();
        }
    }
    public class dtEspecificaGastoPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerEspecificaGastoPaginadoResponseViewModel> data { get; set; }
    }
}
