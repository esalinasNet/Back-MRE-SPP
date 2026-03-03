using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
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

namespace Mre.OTI.Presupuesto.Application.Features.Anios.Command
{
    public class ActualizarAniosCommand : IRequestHandler<ActualizarAniosViewModel, CommandResponseViewModel>
    {
        readonly private IAniosRepository _IAniosRepository;        
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarAniosCommand(IAniosRepository IAniosRepository, IUnitOfWork IUnitOfWork, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _IAniosRepository = IAniosRepository;            
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarAniosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_ANIOS_DESCRIPCION_REQUIRED);

                var entity = AniosMap.MaptoEntity(request);
                var idUsuarioAniosModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioAniosModificacion;

                var result = await _IAniosRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_ANIOS_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
