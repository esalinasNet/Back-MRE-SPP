using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class ProgramacionActividad : Auditoria
    {
        public int ID_PROGRAMACION_ACTIVIDAD { get; set; }
        public int ID_ANIO { get; set; }
        public int ANIO { get; set; }

        public string CODIGO_PROGRAMACION { get; set; }
        public string DENOMINACION { get; set; }
        public string DESCRIPCION { get; set; }
        public string OBJETIVO_PRIORITARIO { get; set; }
        public string LINEAMIENTO { get; set; }

        public int ID_POLITICAS { get; set; }
        public int ID_OBJETIVOS_ESTRATEGICOS { get; set; }
        public int ID_ACCIONES_ESTRATEGICOS { get; set; }
        public int ID_OBJETIVOS_INSTITUCIONALES { get; set; }
        public int ID_ACCIONES_INSTITUCIONALES { get; set; }
        public int ID_CATEGORIA_PRESUPUESTAL { get; set; }
        public int ID_PRODUCO_PROYECTO { get; set; }
        public int ID_FUNCION { get; set; }
        public int ID_DIVISION_FUNCIONAL { get; set; }
        public int ID_GRUPO_FUNCIONAL { get; set; }
        public int ID_ACTIVIDAD_PRESUPUESTAL { get; set; }
        public int ID_FINALIDAD { get; set; }
        public int ID_UNIDAD_MEDIDA { get; set; }

        public int TIPO_UBIGEO { get; set; }
        public string UBIGEO { get; set; }
        public string REGION { get; set; }
        public string PAIS { get; set; }
        public string OSE { get; set; }        
        public int ID_MONEDA { get; set; }

        public bool? ACTIVIDAD_OPERATIVA { get; set; }
        public bool? ACTIVIDAD_INVERSION { get; set; }
        public int ID_CENTRO_COSTOS { get; set; }

        public int META_FISICA { get; set; }
        public decimal META_FINANCIERA { get; set; }

        public string OBSERVACION { get; set; }

        public int ID_ESTADO { get; set; }
        
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
