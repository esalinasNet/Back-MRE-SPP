using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Objetivos
{
    public class ObtenerCodigoObjetivosResponseViewModel : IMapFrom<ObtenerCodigoObjetivosResponseDTO>
    {
        public int idObjetivos { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }
        public string codigoPrioritarios { get; set; }
        public string descripcionPrioritarios { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCodigoObjetivosResponseDTO, ObtenerCodigoObjetivosResponseViewModel>();
        }
    }
}
