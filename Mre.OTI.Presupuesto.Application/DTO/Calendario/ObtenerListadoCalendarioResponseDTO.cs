using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Calendario
{
    public class ObtenerListadoCalendarioResponseDTO
    {
        public int idPeriodo { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public int idMes { get; set; }
        public int mes { get; set; }
        public string mesDescripcion { get; set; }
        public int idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string dependencia { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
