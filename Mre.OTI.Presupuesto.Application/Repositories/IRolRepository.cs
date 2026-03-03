using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IRolRepository
    {
        Task<int> Actualizar(Rol parametro);
        Task<int> Guardar(Rol parametro);
        Task<ObtenerRolResponseDTO> ObtenerRol(int idRol);
        Task<IEnumerable<ObtenerListaRolResponseDTO>> ObtenerListaRol(); // int idSistema);
        Task<IEnumerable<ObtenerRolPaginadoResponseDTO>> ObtenerRolPaginado(ObtenerRolPaginadoRequestDTO request);
        Task<IEnumerable<ObtenerListadoRolResponseDTO>> ObtenerListadoRol(ObtenerListadoRolRequestDTO request);

        Task<ObtenerRolValResponseDTO> ObtenerRolVal(ObtenerRolValRequestDTO request);
        Task<int> Eliminar(Rol parametro);


    }
}
