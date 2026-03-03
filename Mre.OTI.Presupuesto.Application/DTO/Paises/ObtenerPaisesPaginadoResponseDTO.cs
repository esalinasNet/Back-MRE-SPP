using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Paises
{
    public class ObtenerPaisesPaginadoResponseDTO
    {
        public int idPaises { get; set; }
        public string codigo { get; set; }
        public string nombre_pais { get; set; }
        public string continente { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public int activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
