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
    public class AgregarBienesServiciosCommand : IRequestHandler<AgregarBienesServiciosViewModel, CommandResponseViewModel>
    {
        readonly private IBienesServiciosRepository _IBienesServiciosRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarBienesServiciosCommand(IBienesServiciosRepository IBienesServiciosRepository, IUnitOfWork IUnitOfWork, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarBienesServiciosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            //hay que validar como esta en PersonaRepository.
            if (string.IsNullOrEmpty(request.nombreBien)) throw new MreException(Constantes.MensajesError.EX_BIENESSERVICIOS_DESCRIPCION_REQUIRED);

            var entity = BienesServiciosMap.MaptoEntity(request);
            var idUsuarioBienesServiciosCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioBienesServiciosCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IBienesServiciosRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_BIENESSERVICIOS_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
