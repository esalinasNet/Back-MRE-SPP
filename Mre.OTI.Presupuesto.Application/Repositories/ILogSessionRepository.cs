
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ILogSessionRepository
    {
        Task<int> Guardar(LogSession parametro);
    }
}
