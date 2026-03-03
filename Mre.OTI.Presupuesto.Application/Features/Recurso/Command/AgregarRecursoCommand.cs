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

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Command
{
    public class AgregarRecursoCommand : IRequestHandler<AgregarRecursoViewModel, CommandResponseViewModel>
    {
        private readonly IRecursoRepository _IRecursoRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarRecursoCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IRecursoRepository IRecursoRepository)
        {
            _IRecursoRepository = IRecursoRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarRecursoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionTareas == 0) throw new MreException("Debe seleccionar una tarea");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = RecursoMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _IRecursoRepository.Guardar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Recurso registrado correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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