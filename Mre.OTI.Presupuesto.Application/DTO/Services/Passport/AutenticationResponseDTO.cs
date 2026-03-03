using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.DTO.Services.Passport
{
    public class AutenticationResponseDTO
    {

        //public int idUsuarioRol { get; set; }
        public string idUsuarioRolStr { get; set; }
        public string nombreUsuario { get; set; }
        public string correo { get; set; }
        public string descripcionRol { get; set; }
        public bool isVerified { get; set; }
        public string JWToken { get; set; }
        public string message { get; set; }

        public int codigoRol { get; set; }
        //  [JsonIgnore]
        public string refreshToken { get; set; }
        public string idRol { get; set; }
        public string idSistema { get; set; }
    

        public IEnumerable<RolResponse> roles { get; set; }

    }
    public class RolResponse
    {
 

        public string idUsuarioRol { get; set; }
        public int codigoRol { get; set; }
        public string idRol { get; set; }

        public string idSistema { get; set; }
        public string descripcionRol { get; set; }
        public string nombreRol { get; set; }
    }

    public class ObtenerUsuarioLoginResponseDTO
    {
        public int idUsuarioRol { get; set; }
        public int idRol { get; set; }
        public string nombres { get; set; }
        public string descripcionRol { get; set; }
        public string correo { get; set; }
        public string usuarioNT { get; set; }
        public string claveNT { get; set; }
        public int codigoRol { get; set; }
        public int idSistema { get; set; }
        public bool result { get; set; }

    }
}
