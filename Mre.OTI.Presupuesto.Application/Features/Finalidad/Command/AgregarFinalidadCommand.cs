using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.Finalidad;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Finalidad.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.Finalidad.Command
{ 
    public class AgregarFinalidadCommand : IRequestHandler<AgregarFinalidadViewModel, CommandResponseViewModel>
    {
        private readonly IFinalidadRepository _IFinalidadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarFinalidadCommand(IUsuarioRolRepository IUsuarioRolRepository, IFinalidadRepository IFinalidadRepository, IMapper mapper)
        {
            _IFinalidadRepository = IFinalidadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarFinalidadViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_FINALIDAD_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_FINALIDAD_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoFinalidadRequestDTO
            {
                anio = request.anio,
                finalidad = request.finalidad
            };

            //hay que validar como esta en PersonaRepository.
            var valCodigo = await _IFinalidadRepository.ObtenerCodigoFinalidad(requestDto);
            if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_FINALIDAD_CODIGO);


            var entity = FinalidadMap.MaptoEntity(request);

            var idUsuarioFuncionCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioFuncionCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IFinalidadRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_FINALIDAD_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}