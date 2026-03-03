using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
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
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Command
{
    public class AgregarProgramacionAccionesCommand : IRequestHandler<AgregarProgramacionAccionesViewModel, CommandResponseViewModel>
    {
        private readonly IProgramacionTareasRepository _IProgramacionTareasRepository;
        private readonly IProgramacionAccionesRepository _IProgramacionAccionesRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarProgramacionAccionesCommand(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionAccionesRepository IProgramacionAccionesRepository, IMapper mapper)
        {
            _IProgramacionAccionesRepository = IProgramacionAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarProgramacionAccionesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_PROGACCIONES_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcionAcciones)) throw new MreException(Constantes.MensajesError.EX_PROGACCIONES_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoProgramacionAccionesRequestDTO
            {
                anio = request.anio,
                codigoAcciones = request.codigoAcciones
            };

            //valida el codigo de Tarea si existe
            //var valCodigo = await _IProgramacionAccionesRepository.ObtenerCodigoProgramacionAcciones(requestDto);
            //if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_PROGTAREAS_CODIGO);

            // Crear el DTO con los valores del request
            var Medida = new ObtenerUnidadMedidaProgramacionAccionesRequestDTO
            {
                idProgramacionTareas = request.idProgramacionTareas,
                idUnidadMedida = request.idUnidadMedida
            };
            var resMedida = await _IProgramacionAccionesRepository.ObtenerUnidadMedidaProgramacionAcciones(Medida);
            if (resMedida == null) throw new MreException(Constantes.MensajesError.EX_PROGTAREAS_UNDMEDIDA);

            var entity = ProgramacionAccionesMap.MaptoEntity(request);

            var idUsuarioFuncionCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioFuncionCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IProgramacionAccionesRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_PROGTAREAS_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
