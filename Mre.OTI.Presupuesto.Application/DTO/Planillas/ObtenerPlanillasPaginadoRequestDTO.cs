using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Planillas
{
    public  class ObtenerPlanillasPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        public string nroDocumento { get; set; }
        public string apellidosNombres { get; set; }        
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
