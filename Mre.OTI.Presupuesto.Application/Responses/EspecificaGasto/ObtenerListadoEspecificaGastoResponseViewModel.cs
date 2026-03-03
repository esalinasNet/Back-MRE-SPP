using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using static Mre.OTI.Presupuesto.Application.Util.VariablesGlobales;

namespace Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto
{
    public class ObtenerListadoEspecificaGastoResponseViewModel //: IMapFrom<ObtenerEspecificaGastoResponseDTO>
    {
        public int idClasificador { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string clasificador { get; set; }
        public string descripcion { get; set; }
        public string descripcion_detallada { get; set; }
        public int idEstado { get; set; }
        public int  estado { get; set; }
        public string estadoDescripcion { get; set; }        
        public int idCategoriaGasto { get; set; }
        public string tipoClasificador { get; set; }
        public bool? activo { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<ObtenerEspecificaGastoResponseDTO, ObtenerListadoEspecificaGastoResponseViewModel>();
        //}
    }
}
