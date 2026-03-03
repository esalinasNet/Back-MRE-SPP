using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Command
{
    public class EliminarAeiCategoriaPresupuestalCommand : IRequestHandler<EliminarAeiCategoriaPresupuestalViewModel, CommandResponseViewModel>
    {
        readonly private IAeiCategoriaPresupuestalRepository _IAeiCategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public EliminarAeiCategoriaPresupuestalCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAeiCategoriaPresupuestalRepository IAeiCategoriaPresupuestalRepository, IMapper mapper)
        {
            _IAeiCategoriaPresupuestalRepository = IAeiCategoriaPresupuestalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarAeiCategoriaPresupuestalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idPresupuestal == 0) throw new MreException(Constantes.MensajesError.EX_AEICATEGORIA_ELIMINAR_ID_REQUIRED);

            var entity = AeiCategoriaPresupuestalMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IAeiCategoriaPresupuestalRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_AEICATEGORIAPRESUPUESTAL_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
