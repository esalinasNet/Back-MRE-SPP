using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.DTO.ObjetivosInstitucionales;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales
{
    public class ObtenerObjetivosInstitucionalesResponseViewModel : IMapFrom<ObtenerObjetivosInstitucionalesResponseDTO>
    {
        public int idObjetivos { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }
        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerObjetivosInstitucionalesResponseDTO, ObtenerObjetivosInstitucionalesResponseViewModel>();
        }
    }
}
