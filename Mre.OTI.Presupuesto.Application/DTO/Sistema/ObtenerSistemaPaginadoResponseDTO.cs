using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Sistema
{
    public class ObtenerSistemaPaginadoResponseDTO
    {
        public int idSistema { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codigo_sistema { get; set; }
        public bool? activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
