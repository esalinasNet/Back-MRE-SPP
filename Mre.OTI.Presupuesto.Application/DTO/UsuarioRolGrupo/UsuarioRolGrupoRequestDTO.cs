namespace Mre.OTIv1.Application.DTO.UsuarioRolGrupo
{
    public class UsuarioRolGrupoRequestDTO
    {
        public int idUsuarioRol { get; set; }
        public int idGrupoAtencion { get; set; }
        public bool  activo {get;set;}
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
