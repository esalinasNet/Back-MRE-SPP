using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos
{
    public class ObtenerAeiCentroCostosPaginadoRequestDTO : Pagination
    {
        public int idAnio { get; set; }
        public int idAcciones { get; set; }
        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }        
        public bool? activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
