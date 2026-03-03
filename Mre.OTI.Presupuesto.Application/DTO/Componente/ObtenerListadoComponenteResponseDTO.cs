using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Componente
{
    public class ObtenerListadoComponenteResponseDTO
    {
        public int id_Componente { get; set; }
        public int anio { get; set; }
        public string componente { get; set; }
        public string tipoComponente { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    }
}
