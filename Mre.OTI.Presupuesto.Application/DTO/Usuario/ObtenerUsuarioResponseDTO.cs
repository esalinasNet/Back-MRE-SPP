namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class ObtenerUsuarioResponseDTO
    {
        public int idUsuario { get; set; }

        public string nombres { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        public string correo { get; set; }
        public string correoPersonal { get; set; }
        public bool activo { get; set; }
        public string usuarioNT { get; set; }
        public string numeroDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public string claveNT { get; set; }
        public string tipoDocumento { get; set; }


        public int idPersona { get; set; }

        public string clave { get; set; }

        public string login { get; set; }

    }
}
