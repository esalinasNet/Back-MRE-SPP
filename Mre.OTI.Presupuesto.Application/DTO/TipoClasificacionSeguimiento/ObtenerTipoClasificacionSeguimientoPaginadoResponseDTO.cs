using Mre.OTIv1.Application.Base.DTO;
using System;

namespace Mre.OTIv1.Application.DTO.TipoClasificacionSeguimiento
{
    public class ObtenerTipoClasificacionSeguimientoPaginadoResponseDTO
    {
 
        public int idTipoClasificacionSeguimiento { get; set; }
        public int idTipoClasificacion { get; set; }

        public string numeroDocumento { get; set; }
        public DateTime fechaDocumento { get; set; }
        public string rutaDocumento { get; set; }
        public bool activo { get; set; }
        public int cantidad { get; set; }
        public int usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }


        public int registro { get; set; }
        public int totalRegistro { get; set; }



    }
}
