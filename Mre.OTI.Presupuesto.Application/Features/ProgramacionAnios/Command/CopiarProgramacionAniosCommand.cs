using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAnios.Command
{
    public class CopiarProgramacionAniosCommand : IRequestHandler<CopiarProgramacionAniosViewModel, CommandResponseViewModel>
    {
        private readonly IProgramacionAniosRepository _IProgramacionAniosRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public CopiarProgramacionAniosCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IProgramacionAniosRepository IProgramacionAniosRepository)
        {
            _IProgramacionAniosRepository = IProgramacionAniosRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(CopiarProgramacionAniosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.anioOrigen == 0) throw new MreException("Debe especificar el año origen");
                if (request.aniosDestino == null || request.aniosDestino.Count == 0) throw new MreException("Debe especificar al menos un año destino");
                if (request.actividades == null || request.actividades.Count == 0) throw new MreException("Debe seleccionar al menos una actividad");

                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);

                var result = await _IProgramacionAniosRepository.CopiarProgramacion(
                    request.anioOrigen,
                    request.aniosDestino,
                    request.actividades,
                    idUsuarioCreacion
                );

                return new CommandResponseViewModel
                {
                    message = result.mensaje,
                    result = result.aniosDestinoProcesados
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}