using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos_Detalle;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos_Detalle
{
    public class ObtenerAprobacionesCostosDetallePaginadoResponseViewModel  : IMapFrom<ObtenerAprobacionesCostosDetallePaginadoResponseDTO>
    {
        public int idAprobacionesDetalle { get; set; }

        public int idAprobaciones { get; set; }

        public int idPersona { get; set; }

        public string nombresApellidos { get; set; }

        //public int idCentroCostos { get; set; }
        //public string centroCostos { get; set; }
        //public string descripcionCentroCostos { get; set; }

        public string puestoTrabajo { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
        public int draw { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerAprobacionesCostosDetallePaginadoResponseDTO, ObtenerAprobacionesCostosDetallePaginadoResponseViewModel>();
        }
    }

    public class dtAprobacionesCostosDetallePaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerAprobacionesCostosDetallePaginadoResponseViewModel> data { get; set; }
    }

}
