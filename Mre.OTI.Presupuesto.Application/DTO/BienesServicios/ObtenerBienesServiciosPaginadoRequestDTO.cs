using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.BienesServicios
{
    public class ObtenerBienesServiciosPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        public string codigoBien { get; set; }     
        public string tipoItems { get; set; }
        public string nombreBien { get; set; }

        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
