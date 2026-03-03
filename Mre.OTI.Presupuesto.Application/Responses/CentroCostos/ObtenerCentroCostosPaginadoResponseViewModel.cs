using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.CentroCostos
{
    public class ObtenerCentroCostosPaginadoResponseViewModel : IMapFrom<ObtenerCentroCostosPaginadoResponseDTO>
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

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCentroCostosPaginadoResponseDTO, ObtenerCentroCostosPaginadoResponseViewModel>();
        }
    }

    public class dtCentroCostosPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerCentroCostosPaginadoResponseViewModel> data { get; set; }
    }
}
