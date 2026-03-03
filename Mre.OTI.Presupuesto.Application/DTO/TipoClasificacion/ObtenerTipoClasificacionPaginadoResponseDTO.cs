using Mre.OTIv1.Application.Base.DTO;
using System;

namespace Mre.OTIv1.Application.DTO.TipoClasificacion
{
    public class ObtenerTipoClasificacionPaginadoResponseDTO 
    {
        public int idTipoClasificacion { get; set; }
        public string descripcion { get; set; }
        public int usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int situacion { get; set; }
        public int cantidadOrganismos { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }


    }
}
