using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Planillas : Auditoria
    {
        public int ID_PLANILLA { get; set; }
        public int ID_ANIO { get; set; }

        public int ID_MES { get; set; }

        public int ID_PROGRAMA { get; set; }

        public int ID_PRODUCTO { get; set; }

        public int ID_ACTIVIDAD { get; set; }

        public int META { get; set; }

        public int ID_FINALIDAD { get; set; }

        public int ID_CENTRO_COSTOS { get; set; }

        public int TIPO_DOCUMENTO { get; set; }

        public string NRO_DOCUMENTO { get; set; }

        public string APELLIDOSNOMBRES { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
