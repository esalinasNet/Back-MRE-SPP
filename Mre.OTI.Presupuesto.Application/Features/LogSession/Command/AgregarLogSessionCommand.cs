using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.LogSession.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Presupuesto.Domain.Setting;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.SolicitudAcreditacion.Command
{
    public class AgregarLogSessionCommand : IRequestHandler<AgregarLogSessionViewModel, CommandResponseViewModel>
    {
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        readonly private IUnitOfWork _IUnitOfWork;
        readonly private IUsuarioRepository _IUsuarioRepository;
        readonly private ILogSessionRepository _ILogSessionRepository;
        public AgregarLogSessionCommand(
             IUnitOfWork IUnitOfWork, IUsuarioRolRepository IIUsuarioRolRepository,
            ILogSessionRepository ILogSessionRepository,
             IUsuarioRepository IIUsuarioRepository)
        {
            
            _ILogSessionRepository = ILogSessionRepository;
            _IUnitOfWork = IUnitOfWork;
            _IUsuarioRepository = IIUsuarioRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarLogSessionViewModel request, CancellationToken cancellationToken)
        {
            _IUnitOfWork.BeginTransaction();
            try
            {
                
               var entity = LogSessionMap.MaptoEntity(request);
               var idUsuarioRolCreacion = EncryptionPassportHandler.Decrypt(request.usuarioLogout, Constantes.SISTEMA.KEY_ENCRYPT);
                
                var datosUsuarioRol = await _IUsuarioRolRepository.ObtenerUsuarioRol(Convert.ToInt32(idUsuarioRolCreacion), Constantes.SISTEMA.KEY_ENCRYPT_LOGIN);
                var datosUsuario = await _IUsuarioRepository.ObtenerUsuario(datosUsuarioRol.idUsuario, Constantes.SISTEMA.KEY_ENCRYPT_LOGIN);
                entity.USUARIO_LOGIN = datosUsuario.usuarioNT;
                entity.FECHA_LOGOUT = DateTime.Now;
                entity.ORIGEN_LOGIN = Constantes.OrigenLogin.BACKOFFICE;
                entity.RESULTADO = Constantes.ResultadoLogin.CORRECTO;
                entity.COMEMTARIOS = string.Format(@"{0}-{1}", Constantes.MensajesOK.M01_LOGOUT_OK, Constantes.AccionLogin.LOGOUT);
                entity.TOKEN = (request.token).Replace("Bearer ", string.Empty);
                var result = await _ILogSessionRepository.Guardar(entity);

              
                _IUnitOfWork.Commit();
                return new CommandResponseViewModel
                {
                    result = result
                };
            }
            catch (Exception ex)
            {
                _IUnitOfWork.Rollback();
                throw ex;
            }
        }
       
    }
}
