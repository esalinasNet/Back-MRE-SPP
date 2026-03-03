using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Anio
{
    public class ObtenerListadoAniosResponseDTO
    {
        public int id_Anio { get; set; }
        public int anio { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    }
}
