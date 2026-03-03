using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Command
{
    public class EliminarUsuarioRolCommand : IRequestHandler<EliminarUsuarioRolViewModel, CommandResponseViewModel>
    {
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        readonly private IRolRepository _IRolRepository;

        public EliminarUsuarioRolCommand(IUsuarioRolRepository IUsuarioRolRepository, IRolRepository IRolRepository)
        {
            _IUsuarioRolRepository = IUsuarioRolRepository;
            _IRolRepository = IRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(EliminarUsuarioRolViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
            if (request.idUsuarioRol == 0) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_DELETE_IDROL_REQUIRED);
            var entity = UsuarioRolMap.MaptoEntity(request);

            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IUsuarioRolRepository.Eliminar(entity);


            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_USUARIOROL_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };

        }
    }
}
