using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador
{
    public class ObtenerListadoProgramacionClasificadorResponseViewModel
    {
        public int idProgramacionClasificador { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public int idProgramacionActividad { get; set; }
        public string codigoProgramacion { get; set; }

        public int idFuenteFinanciamiento { get; set; }
        public string codigoFuente { get; set; }
        public string descripcionFuente { get; set; }

        public int idClasificador { get; set; }
        public string codigoEspecifica { get; set; }
        public string descripcionEspecifica { get; set; }

        public string codigoClasificador { get; set; }
        public string descripcionClasificador { get; set; }

        public decimal metaFinanciera { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
    }
}
