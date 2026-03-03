using Mre.OTI.Presupuesto.Domain.Entities;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICmnDetalleRepository
    {
        Task<int> Guardar(CmnDetalle parametro);
    }
}