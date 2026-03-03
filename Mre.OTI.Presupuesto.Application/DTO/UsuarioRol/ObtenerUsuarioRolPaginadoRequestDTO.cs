using Mre.OTI.Presupuesto.Application.Base.DTO;

namespace Mre.OTI.Presupuesto.Application.DTO.UsuarioRol
{
    public class ObtenerUsuarioRolPaginadoRequestDTO : Pagination
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public int idSistema { get; set; }
    }
}
