using Mre.OTI.Passport.Application.DTO.Usuario;
using System.Threading.Tasks;


namespace Mre.OTI.Passport.Application.Repositories.Services
{
    public interface IAutenticarLDAPService
    {


        Task<AutenticateLDAPResponse> ValidarAcceso(string usuario, string pwd);

    }
}
