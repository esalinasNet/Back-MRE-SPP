using MediatR;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Passport.Util.Encriptador;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Command
{
    public class ActualizarFuncionCommand : IRequestHandler<ActualizarFuncionViewModel, CommandResponseViewModel>
    {
        readonly private IFuncionRepository _IFuncionRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarFuncionCommand(IFuncionRepository IFuncionRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _IFuncionRepository = IFuncionRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarFuncionViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_FUNCION_DESCRIPCION_REQUIRED);

                var entity = FuncionMap.MaptoEntity(request);
                var idUsuarioFuncionModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioFuncionModificacion;

                var result = await _IFuncionRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_FUNCION_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
