using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Politicas.Command
{
    public class AgregarPoliticasCommand : IRequestHandler<AgregarPoliticasViewModel, CommandResponseViewModel>
    {
        readonly private IPoliticasRepository _IPoliticasRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarPoliticasCommand(IUsuarioRolRepository IIUsuarioRolRepository, IPoliticasRepository IPoliticasRepository, IMapper mapper)
        {
            _IPoliticasRepository = IPoliticasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarPoliticasViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_POLITICAS_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcionPoliticas)) throw new MreException(Constantes.MensajesError.EX_POLITICAS_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoPoliticasRequestDTO
            {
                anio = request.anio,
                codigoPoliticas = request.codigoPoliticas
            };

            //hay que validar como esta en PersonaRepository.
            var valClasificador = await _IPoliticasRepository.ObtenerCodigoPoliticas(requestDto);
            if (valClasificador != null) throw new MreException(Constantes.MensajesError.EX_POLITICAS_CODIGO_POLITICAS);

            //if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_CCOSTOS_DESCRIPCION_REQUIRED);

            var entity = PoliticasMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IPoliticasRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_POLITICAS_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
