using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio
{
    public class ObtenerTipoDeCambioMonedaResponseDTO
    {
        public int idMoneda { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoIso { get; set; }
        public string nombre { get; set; }
        public decimal valor { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool activo { get; set; }
    }
}
