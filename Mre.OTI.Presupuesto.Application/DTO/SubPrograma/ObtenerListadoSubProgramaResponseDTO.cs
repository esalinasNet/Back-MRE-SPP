using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.SubPrograma
{
    public class ObtenerListadoSubProgramaResponseDTO
    {
        public int idSubPrograma { get; set; }
        public int anio { get; set; }
        public string subprograma { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    }
}
