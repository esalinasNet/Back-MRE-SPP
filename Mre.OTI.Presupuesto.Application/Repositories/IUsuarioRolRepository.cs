using Mre.OTI.Presupuesto.Application.DTO.UsuarioRol;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IUsuarioRolRepository
    {
        Task<int> Actualizar(UsuarioRol parametro);
        Task<int> Guardar(UsuarioRol parametro);
        Task<ObtenerUsuarioRolResponseDTO> ObtenerUsuarioRol(int idUsuarioRol, string fraseEncriptacion);
        Task<ObtenerUsuarioRolValResponseDTO> ObtenerUsuarioRolVal(ObtenerUsuarioRolValRequestDTO request);
        Task<IEnumerable<ObtenerUsuarioRolPaginadoResponseDTO>> ObtenerUsuarioRolPaginado(ObtenerUsuarioRolPaginadoRequestDTO request);
        Task<int> Eliminar(UsuarioRol parametro);

        Task<ObtenerUsuarioRolExteriorResponseDTO> ObtenerUsuarioRolExterior(int idUsuarioRol);
    }
}
