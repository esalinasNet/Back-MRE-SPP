using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProgramacionTareasRepository
    {
        Task<IEnumerable<ObtenerProgramacionTareasPaginadoResponseDTO>> ObtenerProgramacionTareasPaginado(ObtenerProgramacionTareasPaginadoRequestDTO request);

        Task<ObtenerProgramacionTareasResponseDTO> ObtenerProgramacionTareas(ObtenerProgramacionTareasRequestDTO request);

        Task<int> Guardar(ProgramacionTareas parametro);

        Task<int> Actualizar(ProgramacionTareas parametro);

        Task<int> Eliminar(ProgramacionTareas parametro);

        Task<IEnumerable<ObtenerListadoProgramacionTareasResponseDTO>> ObtenerListadoProgramacionTareas(ObtenerListadoProgramacionTareasRequestDTO request);

        Task<IEnumerable<ObtenerListadoProgramacionTareasPorActividadResponseDTO>> ObtenerListadoProgramacionTareasPorActividad(ObtenerListadoProgramacionTareasPorActividadRequestDTO request);

        Task<ObtenerCodigoProgramacionTareasResponseDTO> ObtenerCodigoProgramacionTareas(ObtenerCodigoProgramacionTareasRequestDTO request);

        Task<ObtenerProgramacionActividadTareasResponseDTO> ObtenerProgramacionActividadTareas(ObtenerProgramacionActividadTareasRequestDTO request);

        Task<ObtenerUnidadMedidaProgramacionTareasResponseDTO> ObtenerUnidadMedidaProgramacionTareas(ObtenerUnidadMedidaProgramacionTareasRequestDTO request);
    }
}
