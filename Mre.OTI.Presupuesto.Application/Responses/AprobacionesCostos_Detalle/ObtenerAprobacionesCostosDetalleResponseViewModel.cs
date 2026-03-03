using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos_Detalle;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos_Detalle
{
    public class ObtenerAprobacionesCostosDetalleResponseViewModel : IMapFrom<ObtenerAprobacionesCostosDetalleResponseDTO>
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
            profile.CreateMap<ObtenerAprobacionesCostosDetalleResponseDTO, ObtenerAprobacionesCostosDetalleResponseViewModel>();
        }
    }
}
