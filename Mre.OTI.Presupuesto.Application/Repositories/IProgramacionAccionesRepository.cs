using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProgramacionAccionesRepository
    {
        Task<IEnumerable<ObtenerProgramacionAccionesPaginadoResponseDTO>> ObtenerProgramacionAccionesPaginado(ObtenerProgramacionAccionesPaginadoRequestDTO request);

        Task<ObtenerProgramacionAccionesResponseDTO> ObtenerProgramacionAcciones(ObtenerProgramacionAccionesRequestDTO request);

        Task<int> Guardar(ProgramacionAcciones parametro);

        Task<int> Actualizar(ProgramacionAcciones parametro);

        Task<int> Eliminar(ProgramacionAcciones parametro);

        Task<IEnumerable<ObtenerListadoProgramacionAccionesResponseDTO>> ObtenerListadoProgramacionAcciones(ObtenerListadoProgramacionAccionesRequestDTO request);

        Task<IEnumerable<ObtenerListadoProgramacionAccionesPorTareasResponseDTO>> ObtenerListadoProgramacionAccionesPorTareas(ObtenerListadoProgramacionAccionesPorTareasRequestDTO request);

        Task<ObtenerCodigoProgramacionAccionesResponseDTO> ObtenerCodigoProgramacionAcciones(ObtenerCodigoProgramacionAccionesRequestDTO request);

        Task<ObtenerProgramacionTareasAccionesResponseDTO> ObtenerProgramacionTareasAcciones(ObtenerProgramacionTareasAccionesRequestDTO request);

        Task<ObtenerUnidadMedidaProgramacionAccionesResponseDTO> ObtenerUnidadMedidaProgramacionAcciones(ObtenerUnidadMedidaProgramacionAccionesRequestDTO request);
    }
}
