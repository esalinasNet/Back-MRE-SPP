using AutoMapper;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionActividad;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Command
{
    public class AgregarProgramacionActividadCommand : IRequestHandler<AgregarProgramacionActividadViewModel, CommandResponseViewModel>
    {
        private readonly IProgramacionActividadRepository _IProgramacionActividadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarProgramacionActividadCommand(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionActividadRepository IProgramacionActividadRepository, IMapper mapper)
        {
            _IProgramacionActividadRepository = IProgramacionActividadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarProgramacionActividadViewModel request, CancellationToken cancellationToken)
        {
            //await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
            //    VariablesGlobales.TablaRol.ANALISTA_OGTH
            //});

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_FINALIDAD_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_FINALIDAD_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoProgramacionActividadRequestDTO
            {
                anio = request.anio,
                codigoProgramacion = request.codigoProgramacion
            };

            //hay que validar como esta en PersonaRepository.
            var valCodigo = await _IProgramacionActividadRepository.ObtenerCodigoProgramacionActividad(requestDto);
            if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_FINALIDAD_CODIGO);


            var entity = ProgramacionActividadMap.MaptoEntity(request);

            var idUsuarioFuncionCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioFuncionCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IProgramacionActividadRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_FINALIDAD_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
