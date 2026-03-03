using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Seguridad
{
    public class ObtenerOpcionResponseDTO
    {
        public int ID_OPCION { get; set; }
        public int? ID_OPCION_PADRE { get; set; }
        public string NOMBRE { get; set; }
        public string URL { get; set; }
    }

}
