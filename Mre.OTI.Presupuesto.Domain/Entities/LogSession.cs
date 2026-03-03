using Mre.OTI.Presupuesto.Domain.Base;
using System;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class LogSession : Auditoria
    {
        public int ID_LOG_SESSION { get; set; }
        public string USUARIO_LOGIN { get; set; }
        public string? RESULTADO { get; set; }
        public string IP_LOGIN { get; set; }
        public string? ORIGEN_DISPOSITIVO { get; set; }
        public string? ORIGEN_LOGIN { get; set; }
        public string? COMEMTARIOS { get; set; }
        public string? CODIGO_SISTEMA { get; set; }
        public DateTime? FECHA_LOGIN { get; set; }
        public DateTime? FECHA_LOGOUT { get; set; }
        public string? TOKEN { get; set; }
        public DateTime? FECHA_EXPIRA { get; set; }

    }
}
