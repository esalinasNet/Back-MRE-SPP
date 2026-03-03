using AutoMapper;
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
    public class ActualizarRecursoCommand : IRequestHandler<ActualizarRecursoViewModel, CommandResponseViewModel>
    {
        private readonly IRecursoRepository _IRecursoRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarRecursoCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IRecursoRepository IRecursoRepository)
        {
            _IRecursoRepository = IRecursoRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarRecursoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionRecurso == 0) throw new MreException("Debe especificar el ID del recurso");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = RecursoMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IRecursoRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Recurso actualizado correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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