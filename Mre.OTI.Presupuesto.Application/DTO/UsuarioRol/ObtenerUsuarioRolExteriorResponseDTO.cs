 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.DTO.UsuarioRol
{
    public class ObtenerUsuarioRolExteriorResponseDTO
    {
        public int idUsuarioRol { get; set; }
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public int codigoRol { get; set; }
        public int idCentroCostos { get; set; }
        public string nombreCentroCosto  { get; set; }
        public int idNivelCentroCosto { get; set; }
        
    }
}
