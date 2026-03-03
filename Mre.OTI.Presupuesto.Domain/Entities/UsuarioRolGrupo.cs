using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class UsuarioRolGrupo : Auditoria
    {

        public int ID_USUARIO_PERFIL_GRUPO { get; set; }
        public int ID_GRUPO_ATENCION { get; set; }
        public int ID_USUARIO_PERFIL { get; set; }

        public bool ACTIVO { get; set; }

        public int registro { get; set; }

        public int totalRegistro { get; set; }

    }
}
