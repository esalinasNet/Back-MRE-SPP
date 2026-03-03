using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.FasesPoi
{
    public class ObtenerFasesPoiPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        public string codigoFases { get; set; }
        public string descripcionFases { get; set; }
        public int anioInicial { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
