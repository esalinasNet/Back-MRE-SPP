using Mre.OTI.Presupuesto.Domain.Entities;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IViaticosDetalleRepository
    {
        Task<int> Guardar(ViaticosDetalle parametro);
    }
}