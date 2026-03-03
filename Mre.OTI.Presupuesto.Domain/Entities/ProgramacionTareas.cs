using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class ProgramacionTareas : Auditoria
    {
        public int ID_PROGRAMACION_TAREAS { get; set; }
        public int ID_ANIO { get; set; }
        public int ID_PROGRAMACION_ACTIVIDAD { get; set; }
        //public int ID_PROGRAMACION_CLASIFICADOR { get; set; }
        public string CODIGO_TAREAS { get; set; }
        public string DESCRIPCION_TAREAS { get; set; }
        public string UBIGEO { get; set; }
        public int ID_UNIDAD_MEDIDA { get; set; }
        public bool? REPRESENTATIVA { get; set; }
        public int ID_FUENTE_FINANCIAMIENTO { get; set; }
        public int META_FISICA { get; set; }
        public decimal META_FINANCIERA { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
