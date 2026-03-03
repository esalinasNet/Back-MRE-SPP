using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos
{    
    public class ObtenerAprobacionesCostosPaginadoResponseViewModel : IMapFrom<ObtenerAprobacionesCostosPaginadoResponseDTO>
    {
        public int idAprobaciones { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public int idProgramacionActividad { get; set; }
        public string codigoProgramacion { get; set; }

        public int idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string descripcionCentroCostos { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerAprobacionesCostosPaginadoResponseDTO, ObtenerAprobacionesCostosPaginadoResponseViewModel>();
        }
    }

    public class dtAprobacionesCostosPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerAprobacionesCostosPaginadoResponseViewModel> data { get; set; }
    }

}
