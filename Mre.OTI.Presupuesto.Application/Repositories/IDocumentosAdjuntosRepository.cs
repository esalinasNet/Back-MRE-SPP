using System.Collections.Generic;
using System.Threading.Tasks;
using Mre.OTI.Presupuesto.Domain.Entities;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IDocumentosAdjuntosRepository
    {
        Task<int> Guardar(DocumentosAdjuntos parametro);
        Task<int> Eliminar(DocumentosAdjuntos parametro);
        Task<int> Actualizar(DocumentosAdjuntos parametro);
        Task<int> ActualizarEstado(DocumentosAdjuntos parametro);
    }
}
