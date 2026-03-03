using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.CentroCostos
{
    public class ObtenerCodigoCostosResponseViewModel : IMapFrom<ObtenerCentroCostosResponseDTO>
    {
        public int idCentroCostos { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public int idEjecutora { get; set; }
        public int ejecutora { get; set; }
        public string centroCostos { get; set; }
        public string descripcion { get; set; }
        public string centroCostosPadre { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCentroCostosResponseDTO, ObtenerCodigoCostosResponseViewModel>();
        }
    }
}
