using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos_Detalle
{
    public class ObtenerAprobacionesCostosDetallePaginadoRequestDTO : Pagination
    {
        public int idAprobaciones { get; set; }
        public bool? activo { get; set; }
    }
}
