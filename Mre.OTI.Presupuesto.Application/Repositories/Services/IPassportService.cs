
using Mre.OTI.Presupuesto.Application.DTO.Services.Passport;
using Mre.OTI.Presupuesto.Application.Features.Autenticacion.Command;
using Mre.OTI.Presupuesto.Application.Responses.Autentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories.Services
{
    public interface IPassportService
    {
        Task<AutenticationViewModel> Autenticar(AutenticarUsuarioViewModel request);
    }
}
