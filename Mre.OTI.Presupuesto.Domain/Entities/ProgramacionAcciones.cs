using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class ProgramacionAcciones : Auditoria
    {
        public int ID_PROGRAMACION_ACCIONES { get; set; }
        public int ID_ANIO { get; set; }
        public int ID_PROGRAMACION_ACTIVIDAD { get; set; }
        public int ID_PROGRAMACION_TAREAS { get; set; }
        public string CODIGO_ACCIONES { get; set; }
        public string DESCRIPCION_ACCIONES { get; set; }
        public int ID_UNIDAD_MEDIDA { get; set; }
        public bool? REPRESENTATIVA { get; set; }
        public bool? ACUMULATIVA { get; set; }
        public int META_FISICA { get; set; }
        public int ENERO { get; set; }
        public int FEBRERO { get; set; }
        public int MARZO { get; set; }
        public int ABRIL { get; set; }
        public int MAYO { get; set; }
        public int JUNIO { get; set; }
        public int JULIO { get; set; }
        public int AGOSTO { get; set; }
        public int SETIEMBRE { get; set; }
        public int OCTUBRE { get; set; }
        public int NOVIEMBRE { get; set; }
        public int DICIEMBRE { get; set; }
        public int TOTAL_ANUAL { get; set; }
        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

    }
}
