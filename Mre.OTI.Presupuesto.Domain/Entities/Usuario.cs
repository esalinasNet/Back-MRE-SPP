using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Usuario : Auditoria
    {
        public int ID_USUARIO { get; set; }

        public string LOGIN { get; set; }
        public string CLAVE { get; set; }
        public string CORREO { get; set; }
        public int ACTIVO { get; set; }

        public int ID_PERSONA { get; set; }
       
        public string USUARIO_NT { get; set; }
        public string CLAVE_NT { get; set; }

        public int registro { get; set; }

        public int totalRegistro { get; set; }

        /// <summary>
        /// USADO SOLO PARA LA ENCRIPTACION DE LA CLAVE
        /// </summary>
        public string? fraseEncriptacion { get; set; }

        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string NOMBRES { get; set; }

        public int ID_TIPO_DOCUMENTO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
    }
}
