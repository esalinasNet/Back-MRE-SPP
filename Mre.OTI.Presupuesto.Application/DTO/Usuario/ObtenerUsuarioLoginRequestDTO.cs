namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class ObtenerUsuarioLoginRequestDTO
    {
        public string login { get; set; }
        public string pwd { get; set; }

        public string usuarioNT { get; set; }
        public string claveNT { get; set; }
        public string codigoSistema { get; set; }

        public int codigoPerfilCentroCosto { get; set; }
        /// <summary>
        /// SOLO USADO PARA LA DESENCRIPTACION EN BD DEL PERSONAL NT
        /// </summary>
        public string fraseEncriptacion { get; set; }

    }
}
