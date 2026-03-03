using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Calendario
{
    public class ObtenerCalendarioPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }        
        public string mesDescripcion { get; set; }
        public string centroCostos { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
