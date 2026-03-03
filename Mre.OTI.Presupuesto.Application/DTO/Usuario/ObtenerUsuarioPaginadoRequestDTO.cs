using Mre.OTI.Presupuesto.Application.Base.DTO;

namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class ObtenerUsuarioPaginadoRequestDTO : Pagination
    {

        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string correo { get; set; }
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        /// <summary>
        /// SOLO USADO PARA LA DESENCRIPTACION EN BD DEL PERSONAL NT
        /// </summary>
        public string fraseEncriptacion { get; set; }
    }
}
