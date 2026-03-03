using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Task<int> Actualizar(Usuario parametro);
        Task<int> Guardar(Usuario parametro);
        Task<ObtenerUsuarioResponseDTO> ObtenerUsuario(int idUsuario, string fraseEncriptacion);
        Task<IEnumerable<ObtenerUsuarioPaginadoResponseDTO>> ObtenerUsuarioPaginado(ObtenerUsuarioPaginadoRequestDTO request);
        Task<int> Eliminar(Usuario parametro);
        Task<IEnumerable<ObtenerUsuarioLoginResponseDTO>> ObtenerUsuarioLogin(ObtenerUsuarioLoginRequestDTO request);
        Task<IEnumerable<ObtenerListadoUsuarioResponseDTO>> ObtenerListadoUsuario(ObtenerListadoUsuarioRequestDTO request);
        Task<IEnumerable<ObtenerListadoUsuarioSelectResponseDTO>> ObtenerListadoUsuarioSelect();
        Task<ObtenerUsuarioLoginResponseDTO> ObtenerUsuarioRol(int idUsuarioRol, string fraseEncriptacion);

        Task<ObtenerUsuarioValResponseDTO> ObtenerUsuarioVal(ObtenerUsuarioValRequestDTO request);

        Task<ObtenerUsuarioLoginExteriorResponseDTO> ObtenerUsuarioLoginExterior(ObtenerUsuarioLoginRequestDTO request);

        Task<IEnumerable<ObtenerListarUsuariosResponseDTO>> ObtenerListarUsuarios();

        Task<int> tieneAccesoActivo(int idUsuario);
        Task<IEnumerable<string>> ObtenerCorreosCentroCosto(int codigoPerfilUsuario, int idCentroCosto);
        Task<IEnumerable<string>> ObtenerCorreosContabilidad(int codigoPerfilJefe, int codigoPerfilAux);
        Task<IEnumerable<string>> ObtenerCorreosFinanzas(int codigoPerfilJefe, int codigoPerfilAux);
    }
}
