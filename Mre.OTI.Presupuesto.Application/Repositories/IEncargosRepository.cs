using Mre.OTI.Presupuesto.Application.DTO.Encargos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IEncargosRepository
    {
        Task<IEnumerable<ObtenerListadoEncargosResponseDTO>> ObtenerListadoEncargos(ObtenerListadoEncargosRequestDTO request);
        Task<IEnumerable<ObtenerEncargosPaginadoResponseDTO>> ObtenerEncargosPaginado(ObtenerEncargosPaginadoRequestDTO request);
        Task<ObtenerEncargosPorIdResponseDTO> ObtenerEncargosPorId(int idProgramacionEncargos, string usuarioConsulta);
        Task<int> Guardar(Encargos parametro);
        Task<int> Actualizar(Encargos parametro);
        Task<int> Eliminar(Encargos parametro);
    }
}
