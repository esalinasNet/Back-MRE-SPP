using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;

using Mre.OTI.Passport.Util.Encriptador;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Util
{
    public static class ValidateGlobalBase
    {/// <summary>
     ///  Valida el acceso al recursos del servicio.
     ///  idUsuarioRolSession: id del usuario + rol logeado en formato string encriptado.
     ///  rolPermitido:  Lista de Roles que podran acceder al recurso
     ///  IUsuarioRolRepository : Interfaz que conecta al repositorio para validar
     /// </summary>
     /// <param name="idUsuarioRolSession"></param>
     /// <param name="_IUsuarioRolRepository"></param>
     /// <param name="rolPermitido"></param>
     /// <returns>idUsuarioRol int</returns>
     /// <exception cref="MreException"></exception>
        public static async Task<int> Autorizacion(string idUsuarioRolSession, IUsuarioRolRepository _IUsuarioRolRepository, IEnumerable<VariablesGlobales.TablaRol> rolPermitido)
        {
            //int veces_existe = 0;
            //var accesoTodos = false;

            if (string.IsNullOrEmpty(idUsuarioRolSession)) throw new MreException(Constantes.MensajesError.EX_GRAL_REQUEST_REQUIRED_ROL_SESION);
            var idUsuarioRol = EncryptionPassportHandler.Decrypt(idUsuarioRolSession, Constantes.SISTEMA.KEY_ENCRYPT);
         
            //var rolTodos = rolPermitido.Where(x => x == (int)VariablesGlobales.TablaRol.TODOS);
            //if (rolTodos.Any()) accesoTodos = true;

            //if (!accesoTodos)
            //{
            //    var usuarioRolExt = await _IUsuarioRolRepository.ObtenerUsuarioRolExterior(Convert.ToInt32(Convert.ToInt32(idUsuarioRol)));
            //    var usuarioRol = await _IUsuarioRolRepository.ObtenerUsuarioRol(Convert.ToInt32(idUsuarioRol),Constantes.SISTEMA.KEY_ENCRYPT_LOGIN);


            //    if (usuarioRolExt == null && usuarioRol == null) throw new UarmException(Constantes.MensajesError.EX_GRAL_NO_ACCESS);
            //    else
            //    {
            //        if (usuarioRolExt != null)
            //        {
            //            foreach (var rol in rolPermitido)
            //            {
            //                if (usuarioRolExt.codigoRol == (int)rol) veces_existe++;
            //            }
            //        }
            //        if (usuarioRol != null)
            //        {
            //            foreach (var rol in rolPermitido)
            //            {
            //                if (usuarioRol.codigoRol == (int)rol) veces_existe++;
            //            }
            //        }

            //        if (veces_existe == 0) throw new UarmException(Constantes.MensajesError.EX_GRAL_PROFILE_NO_ACCESS);
            //    }
            //}



            return Convert.ToInt32(idUsuarioRol);

        }
        
    }
}