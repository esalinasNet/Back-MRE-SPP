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
    public class EliminarAprobacionesCostosCommand : IRequestHandler<EliminarAprobacionesCostosViewModel, CommandResponseViewModel>
    {
        readonly private IAprobacionesCostosRepository _IAprobacionesCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public EliminarAprobacionesCostosCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAprobacionesCostosRepository IAprobacionesCostosRepository, IMapper mapper)
        {
            _IAprobacionesCostosRepository = IAprobacionesCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarAprobacionesCostosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
        {
            VariablesGlobales.TablaRol.ANALISTA_OGTH
        });

            if (request.idAprobaciones == 0) throw new MreException(Constantes.MensajesError.EX_ACCIONES_ELIMINAR_ID_REQUIRED);

            var entity = AprobacionesCostosMap.MaptoEntity(request);

            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IAprobacionesCostosRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACCIONES_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
