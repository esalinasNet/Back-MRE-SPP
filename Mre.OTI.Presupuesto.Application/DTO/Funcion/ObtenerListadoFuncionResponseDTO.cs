using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Funcion
{
    public class ObtenerListadoFuncionResponseDTO
    {
        public int idFuncion { get; set; }
        public int anio { get; set; }
        public string funcion { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    }
}
