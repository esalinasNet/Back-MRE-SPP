using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Persona : Auditoria
    {
        public int ID_PERSONA { get; set; }
        public int ID_TIPO_DOCUMENTO { get; set; }
        public int? ID_PAIS_NACIMIENTO { get; set; }
        public int ID_ESTADO_CIVIL { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string CORREO { get; set; }
        public string SEXO { get; set; }
        public string NUMERO_TELEFONO { get; set; }
        public DateTime? FECHA_NACIMIENTO { get; set; }
        public bool ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public string paisNacimiento { get; set; }
    }
}
