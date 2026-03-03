using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.SubPrograma
{
    public class ObtenerListadoSubProgramaResponseViewModel
    {
        public int idsubprograma { get; set; }
        public int idanio { get; set; }
        public int anio { get; set; }
        public string subprograma { get; set; }
        public string descripcion { get; set; }
        public int idestado { get; set; }
        public int estado { get; set; }
        public string edescripcion { get; set; }
    }
}
