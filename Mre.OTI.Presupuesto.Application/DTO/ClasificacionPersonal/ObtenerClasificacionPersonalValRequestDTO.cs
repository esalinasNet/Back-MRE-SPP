using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ClasificacionPersonal
{
    public class ObtenerClasificacionPersonalValRequestDTO
    {
        public string nombre {  get; set; }
        public int idClasificacionPersonal {  get; set; }
        public string sigla { get; set; }
    }
}
