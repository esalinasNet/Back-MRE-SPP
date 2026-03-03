using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Command
{
    internal class EliminarSubProgramaCommand : IRequestHandler<EliminarSubProgramaViewModel, CommandResponseViewModel>
    {
        private readonly ISubProgramaRepository _ISubProgramaRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarSubProgramaCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            ISubProgramaRepository ISubProgramaRepository)

        {
            _ISubProgramaRepository = ISubProgramaRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarSubProgramaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idSubPrograma == 0) throw new MreException(Constantes.MensajesError.EX_SUBPROGRAMA_ELIMINAR_ID_REQUIRED);
            var entity = SubProgramaMap.MaptoEntity(request);
            var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioModificacion;

            var result = await _ISubProgramaRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_SUBPROGRAMA_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
    
}
