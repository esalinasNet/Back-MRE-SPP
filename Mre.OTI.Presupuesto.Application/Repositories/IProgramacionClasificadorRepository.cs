using Mre.OTI.Presupuesto.Application.DTO.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProgramacionClasificadorRepository
    {
        Task<IEnumerable<ObtenerProgramacionClasificadorPaginadoResponseDTO>> ObtenerProgramacionClasificadorPaginado(ObtenerProgramacionClasificadorPaginadoRequestDTO request);

        Task<ObtenerProgramacionClasificadorResponseDTO> ObtenerProgramacionClasificador(ObtenerProgramacionClasificadorRequestDTO request);

        Task<int> Guardar(ProgramacionClasificador parametro);

        Task<int> Actualizar(ProgramacionClasificador parametro);

        Task<int> Eliminar(ProgramacionClasificador parametro);

        Task<IEnumerable<ObtenerListadoProgramacionClasificadorResponseDTO>> ObtenerListadoProgramacionClasificador(ObtenerListadoProgramacionClasificadorRequestDTO request);

        Task<IEnumerable<ObtenerListadoProgramacionClasificadorPorActividadResponseDTO>> ObtenerListadoProgramacionClasificadorPorActividad(ObtenerListadoProgramacionClasificadorPorActividadRequestDTO request);

        Task<ObtenerCodigoProgramacionClasificadorResponseDTO> ObtenerCodigoProgramacionClasificador(ObtenerCodigoProgramacionClasificadorRequestDTO request);

        Task<ObtenerProgramacionActividadClasificadorResponseDTO> ObtenerProgramacionActividadClasificador(ObtenerProgramacionActividadClasificadorRequestDTO request);
    }
}
