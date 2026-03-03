using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.CentroCostos
{
    public class ObtenerCentroCostosPaginadoRequestDTO : Pagination
    {        
        public int anio { get; set; }
        
        public string centroCostos { get; set; }
        public string descripcion { get; set; }
        public string centroCostosPadre { get; set; }
                      
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
