using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAnios;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionAnios.Command;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAnios;
using System;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProgramacionAniosMap
    {
        // Mapeo de ViewModel a RequestDTO
        public static CopiarProgramacionAniosRequestDTO MaptoDTO(CopiarProgramacionAniosViewModel item)
        {
            return new CopiarProgramacionAniosRequestDTO()
            {
                anioOrigen = item.anioOrigen,
                aniosDestino = item.aniosDestino,
                actividades = item.actividades
            };
        }

        // Mapeo de ResponseDTO a ResponseViewModel
        public static CopiarProgramacionAniosResponseViewModel MaptoViewModel(CopiarProgramacionAniosResponseDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new CopiarProgramacionAniosResponseViewModel()
            {
                estado = dto.estado,
                mensaje = dto.mensaje,
                aniosDestinoProcesados = dto.aniosDestinoProcesados,
                actividadesCopiadas = dto.actividadesCopiadas
            };
        }
    }
}