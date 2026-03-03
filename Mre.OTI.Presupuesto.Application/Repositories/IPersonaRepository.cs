using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<ObtenerPersonaPaginadoResponseDTO>> ObtenerPersonaPaginado(ObtenerPersonaPaginadoRequestDTO request);
        Task<int> tieneUsuarioActivo(int idPersona);
        Task<int> Actualizar(Persona parametro);
        Task<int> Guardar(Persona parametro);
        Task<ObtenerPersonaResponseDTO> ObtenerPersona(int idPersona);
        Task<IEnumerable<ObtenerListadoPersonaResponseDTO>> ObtenerListadoPersona();
        Task<ObtenerPersonaValResponseDTO> ObtenerPersonaVal(ObtenerPersonaValRequestDTO request);
        Task<int> Eliminar(Persona parametro);
    }
}
