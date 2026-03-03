using Mre.OTIv1.Application.Base.DTO;
using System;

namespace Mre.OTIv1.Application.DTO.TipoClasificacionPais
{
    public class ObtenerTipoClasificacionPaisPaginadoResponseDTO
    {
        public int idTipoClasificacionPais { get; set; }
        public int idTipoClasificacion { get; set; }

        public int idOrganismo { get; set; }
        public string nombreOrganismo { get; set; }
        public string nombrePais { get; set; }
        public string nombreTipoEntidad { get; set; }
        public string descripcion { get; set; }
        public int usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }


        public int registro { get; set; }
        public int totalRegistro { get; set; }


    }
}
