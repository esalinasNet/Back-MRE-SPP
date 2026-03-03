using Mre.OTI.Presupuesto.Application.DTO.UsuarioRol;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IApiKeyRepository
    {
        Task<bool> ValidateApiKey(string apiKeyId, string apiKeyEncriptado);
    }
}
