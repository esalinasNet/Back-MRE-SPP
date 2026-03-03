using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class UsuarioRol : Auditoria
    {
        public int ID_USUARIO_ROL { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_PERFIL { get; set; }
        public int ACCESO_PRIVADO { get; set; }
        public int ID_CENTRO_COSTOS { get; set; }
        public int ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
