using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Autentication
{
    public class AutenticationServiceViewModel
    {

        //public int idUsuarioRol { get; set; }
        public string idUsuarioRolStr { get; set; }
        public string nombreUsuario { get; set; }
        public string correo { get; set; }
        public string descripcionRol { get; set; }
        public bool isVerified { get; set; }
        public string jwToken { get; set; }
        public string message { get; set; }

        public int codigoRol { get; set; }
        
        public string refreshToken { get; set; }
        public string idRol { get; set; }
        public string idSistema { get; set; }
        public bool result { get; set; }
        public DateTime? expira { get; set; }
        

        public IEnumerable<RolResponse> roles { get; set; }

    }
    //public class RolResponse
    //{
 

    //    public string idUsuarioRol { get; set; }
    //    public int codigoRol { get; set; }
    //    public string idRol { get; set; }

    //    public string idSistema { get; set; }
    //    public string descripcionRol { get; set; }
    //    public string nombreRol { get; set; }
    //}
}
