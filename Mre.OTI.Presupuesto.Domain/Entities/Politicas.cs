using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Politicas : Auditoria
    {
        public int ID_POLITICAS { get; set; }
        public int ID_ANIO { get; set; }        
        public string CODIGO_POLITICAS { get; set; }
        public string DESCRIPCION_POLITICAS { get; set; }
        public string CODIGO_OBJETIVO { get; set; }
        public string DESCRIPCION_OBJETIVO { get; set; }
        public string CODIGO_LINEAMIENTO { get; set; }
        public string DESCRIPCION_LINEAMIENTO { get; set; }
        public string CODIGO_SERVICIO { get; set; }
        public string DESCRIPCION_SERVICIO { get; set; }
        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
