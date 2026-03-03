using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionActividad
{
    public class ObtenerProgramacionActividadPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }

        public string codigoProgramacion { get; set; }
        public int? idCentroCostos { get; set; }
        public string denominacion { get; set; }
        public string descripcion { get; set; }

        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
    }
}
