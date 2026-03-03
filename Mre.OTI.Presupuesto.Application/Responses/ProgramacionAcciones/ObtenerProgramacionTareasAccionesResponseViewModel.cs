using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones
{
    public class ObtenerProgramacionTareasAccionesResponseViewModel : IMapFrom<ObtenerProgramacionTareasAccionesResponseDTO>
    {
        public string codigoAcciones { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerProgramacionTareasAccionesResponseDTO, ObtenerProgramacionTareasAccionesResponseViewModel>();
        }
    }
}
