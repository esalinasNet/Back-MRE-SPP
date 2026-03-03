using Mre.OTI.Presupuesto.Application.DTO.ProgramacionActividad;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProgramacionActividadRepository
    {
        Task<IEnumerable<ObtenerProgramacionActividadPaginadoResponseDTO>> ObtenerProgramacionActividadPaginado(ObtenerProgramacionActividadPaginadoRequestDTO request);

        Task<ObtenerProgramacionActividadResponseDTO> ObtenerProgramacionActividad(ObtenerProgramacionActividadRequestDTO request);

        Task<int> Guardar(ProgramacionActividad parametro);

        Task<int> Actualizar(ProgramacionActividad parametro);

        Task<int> ActualizarObservado(ProgramacionActividad parametro);

        Task<int> ActualizarEstadosAprobados(ProgramacionActividad parametro);

        Task<int> Eliminar(ProgramacionActividad parametro);

        Task<IEnumerable<ObtenerListadoProgramacionActividadResponseDTO>> ObtenerListadoProgramacionActividad(ObtenerListadoProgramacionActividadRequestDTO request);

        Task<ObtenerCodigoProgramacionActividadResponseDTO> ObtenerCodigoProgramacionActividad(ObtenerCodigoProgramacionActividadRequestDTO request);

        Task<ObtenerProgramacionActividadAniosResponseDTO> ObtenerProgramacionActividadAnios(ObtenerProgramacionActividadAniosRequestDTO request);

        Task<IEnumerable<ObtenerProgramacionActividadCentroCostosResponseDTO>> ObtenerProgramacionActividadCentroCostos(ObtenerProgramacionActividadCentroCostosRequestDTO request);
    }
}
