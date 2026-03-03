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
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Command
{
    public class ActualizarBienesServiciosCommand : IRequestHandler<ActualizarBienesServiciosViewModel, CommandResponseViewModel>
    {

        readonly private IBienesServiciosRepository _IBienesServiciosRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarBienesServiciosCommand(IBienesServiciosRepository IBienesServiciosRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(ActualizarBienesServiciosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (string.IsNullOrEmpty(request.nombreBien)) throw new MreException(Constantes.MensajesError.EX_BIENESSERVICIOS_DESCRIPCION_REQUIRED);

                var entity = BienesServiciosMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IBienesServiciosRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_BIENESSERVICIOS_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
