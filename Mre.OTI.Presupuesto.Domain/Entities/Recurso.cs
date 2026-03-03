using Mre.OTI.Presupuesto.Domain.Base;
using System;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Recurso : Auditoria
    {
        public int ID_PROGRAMACION_RECURSO { get; set; }
        public int ID_PROGRAMACION_ACTIVIDAD { get; set; }
        public int ID_PROGRAMACION_TAREAS { get; set; }
        public int? ID_ANIO { get; set; }
        public int? ID_UBIGEO { get; set; }
        public string CLASIFICADOR_GASTO { get; set; }
        public string DENOMINACION_RECURSO { get; set; }
        public int? ID_TIPO_GASTO { get; set; }
        public int? ID_TIPO_ITEM { get; set; }
        public decimal? MONTO_TOTAL { get; set; }
        public int? ID_FUENTE_FINANCIAMIENTO { get; set; }
        public int? ID_UNIDAD_MEDIDA { get; set; }
        public bool? REPRESENTATIVA { get; set; }
        public bool? GASTO_OBN { get; set; }
        public bool? GASTO_PROYECTO { get; set; }
        public bool? GASTO_VIATICOS { get; set; }
        public bool? GASTO_CAJA_CHICA { get; set; }
        public bool? GASTO_OTROS_GASTOS { get; set; }
        public bool? GASTO_ENCARGAS { get; set; }
        public bool? GASTO_PLANILLA { get; set; }
        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }
    }
}