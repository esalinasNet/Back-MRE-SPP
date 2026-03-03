using Mre.OTI.Passport.Application.DTO.Usuario;
using System.Threading.Tasks;

namespace Mre.OTI.Passport.Application.Repositories
{
    public interface IAutenticarRepository
    {
        Task<AutenticateResponse> ObtenerAutentication(AutenticateRequest request, string ipAddress);

        Task<AutenticateResponse> Register(RegisterRequest request, string origin);

    }
}
