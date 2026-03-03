using static iTextSharp.text.pdf.AcroFields;

namespace Mre.OTI.Presupuesto.Application.DTO.UsuarioRol
{
    public class ObtenerUsuarioRolPaginadoResponseDTO
    {
        public int idUsuarioRol { get; set; }
        public int idRol { get; set; }
        public string rol { get; set; }

        public int idUsuario { get; set; }
        public string usuario { get; set; }
        
        public int idCentroCostos { get; set; }

        public int accesoPrivado { get; set; }

        public string nombreSistema { get; set; }
        public string nombreOSE { get; set; }

        public int activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
