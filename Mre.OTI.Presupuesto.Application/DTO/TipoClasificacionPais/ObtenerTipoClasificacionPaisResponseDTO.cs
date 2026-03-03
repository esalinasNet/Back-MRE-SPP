using Mre.OTIv1.Application.Base.DTO;
using System;

namespace Mre.OTIv1.Application.DTO.TipoClasificacionPais
{
    public class ObtenerTipoClasificacionPaisResponseDTO 
    {
        public int idPaisTipoClasificacion { get; set; }
        public string descripcion {  get; set; }
        public int idTipoClasificacion { get; set; }
        public int idTipoClasificacionSeg { get; set; }
        public int idOrganismo {  get; set; }
        public bool activo { get; set; }
 


    }
}
