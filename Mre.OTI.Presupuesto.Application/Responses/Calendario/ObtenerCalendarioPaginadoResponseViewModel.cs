using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Calendario
{
    public class ObtenerCalendarioPaginadoResponseViewModel : IMapFrom<ObtenerCalendarioPaginadoResponseDTO>
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

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCalendarioPaginadoResponseDTO, ObtenerCalendarioPaginadoResponseViewModel>();
        }
    }

    public class dtCalendarioPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerCalendarioPaginadoResponseViewModel> data { get; set; }
    }
}
