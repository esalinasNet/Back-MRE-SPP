using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Objetivos : Auditoria
    {
        public int ID_OBJETIVOS { get; set; }
        public int ID_ANIO { get; set; }

        public string CODIGO_OBJETIVOS { get; set; }

        public string DESCRIPCION_OBJETIVOS { get; set; }

        public int ID_POLITICAS { get; set; }
        //blic string CODIGO_PRIORITARIOS { get; set; }
        //blic string DESCRIPCION_PRIORITARIOS { get; set; }


        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
