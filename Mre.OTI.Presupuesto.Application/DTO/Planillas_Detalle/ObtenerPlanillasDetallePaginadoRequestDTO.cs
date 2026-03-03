using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Planillas_Detalle
{
    public class ObtenerPlanillasDetallePaginadoRequestDTO : Pagination
    {
        public int idPlanillas { get; set; }
        public bool? activo { get; set; }
    }
}
