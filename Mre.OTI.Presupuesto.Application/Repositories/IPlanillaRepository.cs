using Mre.OTI.Presupuesto.Application.DTO.Planilla;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IPlanillaRepository
    {
        Task<IEnumerable<ObtenerListadoPlanillaResponseDTO>> ObtenerListadoPlanilla(ObtenerListadoPlanillaRequestDTO request);
        Task<IEnumerable<ObtenerPlanillaPaginadoResponseDTO>> ObtenerPlanillaPaginado(ObtenerPlanillaPaginadoRequestDTO request);
        Task<ObtenerPlanillaPorIdResponseDTO> ObtenerPlanillaPorId(int idProgramacionPlanilla, string usuarioConsulta);
        Task<int> Guardar(Planilla parametro);
        Task<int> Actualizar(Planilla parametro);
        Task<int> Eliminar(Planilla parametro);
    }
}