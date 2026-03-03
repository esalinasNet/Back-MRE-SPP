using Mre.OTI.Presupuesto.Application.DTO.Services;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories.Services
{
    public interface IMigracionService
    {
        Task<ResponseMigracionDataDTO> ConsultarCarnetExtrajeria(string numeroDocumento);
    }
}
