using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Planillas_Detalle
{
    public class ObtenerPlanillasDetallePaginadoResponseDTO
    {
        public int idPlanillaDetalle { get; set; }

        public int idPlanillas { get; set; }

        public int idEspecifica { get; set; }

        public string Clasificador { get; set; }

        public string descripcionClasificador { get; set; }

        //public DateTime Periodo { get; set; }

        public decimal Importe { get; set; }

        public bool? activo { get; set; }
        public int draw { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

    }
}
