using Mre.OTI.Presupuesto.Application.DTO.Reporte;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IReporteRepository
    {
        Task<ObtenerReporteActividadResponseDTO> ObtenerReporteActividad(int idProgramacionActividad);
    }
}