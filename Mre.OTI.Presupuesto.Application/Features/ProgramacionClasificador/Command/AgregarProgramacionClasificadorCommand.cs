using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Command
{
    public class AgregarProgramacionClasificadorCommand : IRequestHandler<AgregarProgramacionClasificadorViewModel, CommandResponseViewModel>
    {
        private readonly IProgramacionClasificadorRepository _IProgramacionClasificadorRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarProgramacionClasificadorCommand(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionClasificadorRepository IProgramacionClasificadorRepository, IMapper mapper)
        {
            _IProgramacionClasificadorRepository = IProgramacionClasificadorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarProgramacionClasificadorViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_PROGTAREAS_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcionClasificador)) throw new MreException(Constantes.MensajesError.EX_PROGTAREAS_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoProgramacionClasificadorRequestDTO
            {
                anio = request.anio,
                codigoClasificador = request.codigoClasificador
            };

            //valida el codigo de Tarea si existe
            //var valCodigo = await _IProgramacionClasificadorRepository.ObtenerCodigoProgramacionClasificador(requestDto);
            //if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_PROGTAREAS_CODIGO);


            var entity = ProgramacionClasificadorMap.MaptoEntity(request);

            var idUsuarioFuncionCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioFuncionCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IProgramacionClasificadorRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_PROGTAREAS_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
