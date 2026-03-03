using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ClasificacionPersonal
{
    public class ObtenerClasificacionPersonalValResponseDTO
    {
        public int idClasificacionPersonal {  get; set; }
        public int idClasificacionPersonalPadre { get; set; }
        public string nombre {  get; set; }
        public string sigla { get; set; }
    }
}
