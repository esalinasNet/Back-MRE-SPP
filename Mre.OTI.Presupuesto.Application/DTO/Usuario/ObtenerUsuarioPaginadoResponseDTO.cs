namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class ObtenerUsuarioPaginadoResponseDTO
    {

        public int idUsuario { get; set; }

        public string nombres { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        public string correo { get; set; }

        public int activo { get; set; }

        public int registro { get; set; }

        public int totalRegistro { get; set; }

        public string usuarioNT { get; set; }
        public string numeroDocumento { get; set; }
        public int idTipoDocumento { get; set; }

        public string tipoDocumento { get; set; }

    }
}
