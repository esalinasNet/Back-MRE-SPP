using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class BienesServicios: Auditoria
    {
        public int ID_BIENES_SERVICIOS { get; set; }
        public int ID_ANIO { get; set; }
        

        public string ITEM_BIEN { get; set; }
        public string DENOMINACION_ITEM { get; set; }
        public string TIPO_ITEMS { get; set; }

        public int ID_UNIDADMEDIDA { get; set; }

        public decimal PRECIO { get; set; }

        public int ID_CLASIFICADOR { get; set; }
        //public string CLASIFICADOR_GASTO { get; set; }
        //public string DENOMINACION_EEGG { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
