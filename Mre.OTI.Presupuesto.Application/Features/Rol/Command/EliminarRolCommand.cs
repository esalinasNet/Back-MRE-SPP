using MediatR;
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

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Command
{
    public class EliminarRolCommand : IRequestHandler<EliminarRolViewModel, CommandResponseViewModel>
    {
        readonly private IRolRepository _IRolRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarRolCommand(IUsuarioRolRepository IIUsuarioRolRepository, IRolRepository IRolRepository)
        {
            _IRolRepository = IRolRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(EliminarRolViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idRol == 0) throw new MreException(Constantes.MensajesError.EX_USUARIO_ELIMINAR_ID_REQUIRED);

                var entity = RolMap.MaptoEntity(request);
                var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioRolModificacion;
                var result = await _IRolRepository.Eliminar(entity);


                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_ROL_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
