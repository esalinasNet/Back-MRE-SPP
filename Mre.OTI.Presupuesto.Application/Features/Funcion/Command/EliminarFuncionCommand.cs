using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Command
{
    public class EliminarFuncionCommand : IRequestHandler<EliminarFuncionViewModel, CommandResponseViewModel>
    {
        readonly private IFuncionRepository _IFuncionRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarFuncionCommand(IFuncionRepository IFuncionRepository, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _IFuncionRepository = IFuncionRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;

        }
        public async Task<CommandResponseViewModel> Handle(EliminarFuncionViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idFuncion == 0) throw new MreException(Constantes.MensajesError.EX_FUNCION_ELIMINAR_ID_REQUIRED);

            var entity = FuncionMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IFuncionRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_FUNCION_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
