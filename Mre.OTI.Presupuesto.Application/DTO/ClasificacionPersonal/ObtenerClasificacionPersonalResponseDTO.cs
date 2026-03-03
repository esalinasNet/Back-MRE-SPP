using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ClasificacionPersonal
{
    public class ObtenerClasificacionPersonalResponseDTO
    {
        public int idClasificacion {  get; set; }
        public int idClasificacionPadre { get; set; }
        public string nombre { get; set; }
        public string sigla { get; set; }
        public bool activo { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
