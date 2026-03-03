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

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Command
{
    
    public class EliminarPlanillasDetalleCommand : IRequestHandler<EliminarPlanillasDetalleViewModel, CommandResponseViewModel>
    {
        readonly private IPlanillasDetalleRepository _IPlanillasDetalleRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public EliminarPlanillasDetalleCommand(IUsuarioRolRepository IIUsuarioRolRepository, IPlanillasDetalleRepository IPlanillasDetalleRepository, IMapper mapper)
        {
            _IPlanillasDetalleRepository = IPlanillasDetalleRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarPlanillasDetalleViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
    {
        VariablesGlobales.TablaRol.ANALISTA_OGTH
    });

            if (request.idPlanillaDetalle == 0) throw new MreException(Constantes.MensajesError.EX_ACCIONES_ELIMINAR_ID_REQUIRED);

            var entity = PlanillasDetalleMap.MaptoEntity(request);

            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IPlanillasDetalleRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACCESO_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
