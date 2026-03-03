using Mre.OTI.Presupuesto.Application.DTO.Services;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories.Services
{
    public interface IReniecService
    {
        Task<ResponseReniecDTO> ConsultarDNI(string numeroDocumento);
    }
}
