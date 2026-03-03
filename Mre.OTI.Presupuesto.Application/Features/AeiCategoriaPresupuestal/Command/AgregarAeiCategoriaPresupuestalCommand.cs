using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
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
    public class AgregarAeiCategoriaPresupuestalCommand : IRequestHandler<AgregarAeiCategoriaPresupuestalViewModel, CommandResponseViewModel>
    {
        readonly private IAeiCategoriaPresupuestalRepository _IAeiCategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarAeiCategoriaPresupuestalCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAeiCategoriaPresupuestalRepository IAeiCategoriaPresupuestalRepository, IMapper mapper)
        {
            _IAeiCategoriaPresupuestalRepository = IAeiCategoriaPresupuestalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarAeiCategoriaPresupuestalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            var entity = AeiCategoriaPresupuestalMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IAeiCategoriaPresupuestalRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? "" : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
