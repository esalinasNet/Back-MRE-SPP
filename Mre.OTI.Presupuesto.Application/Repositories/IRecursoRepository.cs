using Mre.OTI.Presupuesto.Application.DTO.Recurso;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IRecursoRepository
    {
        Task<IEnumerable<ObtenerListadoRecursoResponseDTO>> ObtenerListadoRecurso(ObtenerListadoRecursoRequestDTO request);
        Task<IEnumerable<ObtenerRecursoPaginadoResponseDTO>> ObtenerRecursoPaginado(ObtenerRecursoPaginadoRequestDTO request);
        Task<ObtenerRecursoPorIdResponseDTO> ObtenerRecursoPorId(int idProgramacionRecurso, string usuarioConsulta); // ✅ NUEVO
        Task<int> Guardar(Recurso parametro);
        Task<int> Actualizar(Recurso parametro);
        Task<int> Eliminar(Recurso parametro);
    }
}
