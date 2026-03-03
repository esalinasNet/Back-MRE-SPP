using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Command
{
    public class ActualizarProgramacionAccionesCommand : IRequestHandler<ActualizarProgramacionAccionesViewModel, CommandResponseViewModel>
    {
        private readonly IProgramacionTareasRepository _IProgramacionTareasRepository;
        private readonly IProgramacionAccionesRepository _IProgramacionAccionesRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarProgramacionAccionesCommand(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionAccionesRepository IProgramacionAccionesRepository, IMapper mapper)
        {
            _IProgramacionAccionesRepository = IProgramacionAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarProgramacionAccionesViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (string.IsNullOrEmpty(request.descripcionAcciones)) throw new MreException(Constantes.MensajesError.EX_PROGACCIONES_DESCRIPCION_REQUIRED);

                // Crear el DTO con los valores del request
                var Medida = new ObtenerUnidadMedidaProgramacionAccionesRequestDTO
                {
                    idProgramacionTareas = request.idProgramacionTareas,
                    idUnidadMedida = request.idUnidadMedida
                };
                var resMedida = await _IProgramacionAccionesRepository.ObtenerUnidadMedidaProgramacionAcciones(Medida);
                if (resMedida == null) throw new MreException(Constantes.MensajesError.EX_PROGTAREAS_UNDMEDIDA);

                var entity = ProgramacionAccionesMap.MaptoEntity(request);

                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IProgramacionAccionesRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_PROGACCIONES_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
