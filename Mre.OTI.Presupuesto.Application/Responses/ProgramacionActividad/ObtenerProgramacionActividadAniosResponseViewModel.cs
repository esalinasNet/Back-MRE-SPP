using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionActividad;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad
{
    public class ObtenerProgramacionActividadAniosResponseViewModel : IMapFrom<ObtenerProgramacionActividadAniosResponseDTO>
    {
        public string codigoProgramacion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerProgramacionActividadAniosResponseDTO, ObtenerProgramacionActividadAniosResponseViewModel>();
        }
    }
}
