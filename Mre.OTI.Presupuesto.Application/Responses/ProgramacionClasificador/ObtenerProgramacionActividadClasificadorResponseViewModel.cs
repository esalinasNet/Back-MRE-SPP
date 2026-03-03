using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador
{
    public class ObtenerProgramacionActividadClasificadorResponseViewModel : IMapFrom<ObtenerProgramacionActividadClasificadorResponseDTO>
    {
        public string codigoClasificador { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerProgramacionActividadClasificadorResponseDTO, ObtenerProgramacionActividadClasificadorResponseViewModel>();
        }
    }
}
