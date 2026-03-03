using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas
{
    public class ObtenerProgramacionActividadTareasResponseViewModel : IMapFrom<ObtenerProgramacionActividadTareasResponseDTO>
    {
        public string codigoTareas { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerProgramacionActividadTareasResponseDTO, ObtenerProgramacionActividadTareasResponseViewModel>();
        }
    }
}
