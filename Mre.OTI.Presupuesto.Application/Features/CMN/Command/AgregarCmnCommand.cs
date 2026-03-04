using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Cmn.Command
{
    public class AgregarCmnCommand : IRequestHandler<AgregarCmnViewModel, CommandResponseViewModel>
    {
        private readonly ICmnRepository _ICmnRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarCmnCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICmnRepository ICmnRepository)
        {
            _ICmnRepository = ICmnRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarCmnViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
            VariablesGlobales.TablaRol.ANALISTA_OGTH
        });

                if (request.idProgramacionRecurso == 0) throw new MreException("Debe seleccionar un recurso");
                if (request.idProgramacionTareas == 0) throw new MreException("Debe seleccionar una tarea");
                if (request.idActividadOperativa == 0) throw new MreException("Debe seleccionar una actividad operativa");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = CmnMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _ICmnRepository.Guardar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "CMN registrado correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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