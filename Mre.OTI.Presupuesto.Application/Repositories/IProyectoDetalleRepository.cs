using Mre.OTI.Presupuesto.Domain.Entities;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProyectoDetalleRepository
    {
        Task<int> Guardar(ProyectoDetalle parametro);
    }
}