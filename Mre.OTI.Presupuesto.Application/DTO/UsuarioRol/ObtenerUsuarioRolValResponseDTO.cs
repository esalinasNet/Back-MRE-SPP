namespace Mre.OTI.Presupuesto.Application.DTO.UsuarioRol
{
    public class ObtenerUsuarioRolValResponseDTO
    {
        public int idUsuarioRol { get; set; }

        public int idRol { get; set; }

        public int idUsuario { get; set; }

        public int idCentroCostos { get; set; }

        public bool? accesoPrivado { get; set; }

    }
}
