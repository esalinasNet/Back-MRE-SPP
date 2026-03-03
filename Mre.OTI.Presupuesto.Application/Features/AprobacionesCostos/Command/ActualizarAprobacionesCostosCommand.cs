using AutoMapper;
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

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Command
{    
    public class ActualizarAprobacionesCostosCommand : IRequestHandler<ActualizarAprobacionesCostosViewModel, CommandResponseViewModel>
    {
        readonly private IAprobacionesCostosRepository _IAprobacionesCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ActualizarAprobacionesCostosCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAprobacionesCostosRepository IAprobacionesCostosRepository, IMapper mapper)
        {
            _IAprobacionesCostosRepository = IAprobacionesCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarAprobacionesCostosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                //if (string.IsNullOrEmpty(request.descripcionCostos)) throw new MreException(Constantes.MensajesError.EX_DIVISIONFUNCIONAL_DESCRIPCION_REQUIRED);

                var entity = AprobacionesCostosMap.MaptoEntity(request);

                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IAprobacionesCostosRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_DIVISION_FUNCIONAL_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
