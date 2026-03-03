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
    public class AgregarComponenteCommand : IRequestHandler<AgregarComponenteViewModel, CommandResponseViewModel>
    {
        readonly private IComponenteRepository _IComponenteRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarComponenteCommand(IComponenteRepository IComponenteRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _IComponenteRepository = IComponenteRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarComponenteViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            //hay que validar como esta en PersonaRepository.
            if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_COMPONENTE_DESCRIPCION_REQUIRED);

            var entity = ComponenteMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IComponenteRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_COMPONENTE_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
