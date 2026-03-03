using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Command
{
    public class ActualizarUnidadMedidaCommand : IRequestHandler<ActualizarUnidadMedidaViewModel, CommandResponseViewModel>
    {
        private readonly IUnidadMedidaRepository _IUnidadMedidaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarUnidadMedidaCommand(IUsuarioRolRepository IUsuarioRolRepository, IUnidadMedidaRepository IUnidadMedidaRepository, IMapper mapper)
        {
            _IUnidadMedidaRepository = IUnidadMedidaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarUnidadMedidaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_UNIDADMEDIDA_DESCRIPCION_REQUIRED);

                var entity = UnidadMedidaMap.MaptoEntity(request);

                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IUnidadMedidaRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_UNIDAD_MEDIDA_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
