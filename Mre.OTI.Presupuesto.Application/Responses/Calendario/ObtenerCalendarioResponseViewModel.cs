using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Calendario
{
    public class ObtenerCalendarioResponseViewModel : IMapFrom<ObtenerCalendarioResponseDTO>
    {
        public int idPeriodo { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public int idMes { get; set; }
        public int mes { get; set; }
        public string mesDescripcion { get; set; }
        public int idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string dependencia { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCalendarioResponseDTO, ObtenerCalendarioResponseViewModel>();
        }
    }
}
