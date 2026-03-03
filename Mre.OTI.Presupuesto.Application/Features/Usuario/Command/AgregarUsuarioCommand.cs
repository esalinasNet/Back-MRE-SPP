using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Command
{
    public class AgregarUsuarioCommand : IRequestHandler<AgregarUsuarioViewModel, CommandResponseViewModel>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        readonly private IUnitOfWork _IUnitOfWork;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarUsuarioCommand(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository, IUnitOfWork IUnitOfWork)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _IUnitOfWork = IUnitOfWork;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarUsuarioViewModel request, CancellationToken cancellationToken)
        {
             _IUnitOfWork.BeginTransaction();
            try
            {
                var idUsuarioRolCreacion = await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idPersona==0) throw new MreException(Constantes.MensajesError.EX_USUARIO_ID_PERSONA_REQUIRED);

                if (string.IsNullOrEmpty(request.usuarioNT) && request.isMre==1) throw new MreException(Constantes.MensajesError.EX_USUARIO_USUARIO_NT_REQUIRED);
                //if (string.IsNullOrEmpty(request.claveNT) && request.isMre == 1) throw new MreException(Constantes.MensajesError.EX_USUARIO_CLAVE_NT_REQUIRED);
                if ((string.IsNullOrEmpty(request.correo) || !IsValidEmail(request.correo)) && request.isMre == 0) throw new MreException(Constantes.MensajesError.EX_VALIDATE_CORREO_GENERAL);
                var validPersona = await _IUsuarioRepository.ObtenerUsuarioVal(new ObtenerUsuarioValRequestDTO()
                {
                    idPersona = request.idPersona,
                    fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN
                });
            if (validPersona != null) throw new MreException(Constantes.MensajesError.EX_USUARIO_NUMERO_DOCUMENTO_DP);

            if (string.IsNullOrEmpty(request.correo))
            {
                var valCorreo = await _IUsuarioRepository.ObtenerUsuarioVal(new ObtenerUsuarioValRequestDTO()
                {
                    correo = request.correo,
                    fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN
                });
                if (valCorreo != null) throw new MreException(Constantes.MensajesError.EX_USUARIO_CORREO_DP);

            }

            if (!string.IsNullOrEmpty(request.usuarioNT))
            {
                var valUsuarioNT = await _IUsuarioRepository.ObtenerUsuarioVal(new ObtenerUsuarioValRequestDTO()
                {
                    usuarioNT = request.usuarioNT,
                    fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN    
                });
                if (valUsuarioNT != null) throw new MreException(Constantes.MensajesError.EX_USUARIO_NT_DP);

            }


            var entity = UsuarioMap.MaptoEntity(request);
            entity.usuarioCreacion = idUsuarioRolCreacion.ToString();
            entity.fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN;

            var result = await _IUsuarioRepository.Guardar(entity);

            _IUnitOfWork.Commit();

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_USUARIO_INSERT_OK : Constantes.MensajesError.EX_USUARIO_INSERT_ERROR,
                result = result
            };
            }
            catch (Exception ex)
            {
                _IUnitOfWork.Rollback();
                throw ex;
            }


        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
