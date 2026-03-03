namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class ObtenerUsuarioValRequestDTO
    {
        public int idPersona { get; set; }
        public string numeroDocumento { get; set; }
        /// <summary>
        /// SOLO USADO PARA LA DESENCRIPTACION EN BD DEL PERSONAL NT
        /// </summary>
        public string fraseEncriptacion { get; set; }
        public string correo { get; set; }
        public string usuarioNT { get; set; }
    }
}
