using Mre.OTI.Presupuesto.Domain.Entities;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IOtrosGastosDetalleRepository
    {
        Task<int> Guardar(OtrosGastosDetalle parametro);
    }
}