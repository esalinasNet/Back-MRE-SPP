using Mre.OTIv1.Application.Base.DTO;
using Mre.OTIv1.Application.DTO.TipoClasificacionPais;
using System;
using System.Collections.Generic;

namespace Mre.OTIv1.Application.DTO.TipoClasificacion
{
    public class ObtenerTipoClasificacionResponseDTO 
    {
        public int idTipoClasificacion { get; set; }
        public string descripcion { get; set; }
        public int usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        //public int situacion { get; set; }
       // public int cantidadOrganismos { get; set; }
        public IEnumerable<ObtenerTipoClasificacionPaisPaginadoResponseDTO> organismos { get; set; }



    }
}
