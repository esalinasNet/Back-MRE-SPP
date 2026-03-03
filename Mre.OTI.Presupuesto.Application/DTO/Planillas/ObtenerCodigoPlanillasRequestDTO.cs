using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Planillas
{
    public class ObtenerCodigoPlanillasRequestDTO
    {
        public int anio { get; set; }
        public int Mes { get; set; }
        public string nroDocumento { get; set; }
    }
}
