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

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Command
{
    public class ActualizarComponenteCommand : IRequestHandler<ActualizarComponenteViewModel, CommandResponseViewModel>
    {
        readonly private IComponenteRepository _IComponenteRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarComponenteCommand(IComponenteRepository IComponenteRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _IComponenteRepository = IComponenteRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(ActualizarComponenteViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_COMPONENTE_DESCRIPCION_REQUIRED);

                var entity = ComponenteMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IComponenteRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_COMPONENTE_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
