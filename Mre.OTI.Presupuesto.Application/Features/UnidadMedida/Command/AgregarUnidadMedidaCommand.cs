using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.UnidadMedida;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Command
{
    public class AgregarUnidadMedidaCommand : IRequestHandler<AgregarUnidadMedidaViewModel, CommandResponseViewModel>
    {
        private readonly IUnidadMedidaRepository _IUnidadMedidaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarUnidadMedidaCommand(IUsuarioRolRepository IUsuarioRolRepository, IUnidadMedidaRepository IUnidadMedidaRepository, IMapper mapper)
        {
            _IUnidadMedidaRepository = IUnidadMedidaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarUnidadMedidaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_UNIDADMEDIDA_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_UNIDADMEDIDA_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoUnidadMedidaRequestDTO
            {
                anio = request.anio,
                unidadMedida = request.unidadMedida
            };

            //hay que validar como esta en PersonaRepository.
            var valCodigo = await _IUnidadMedidaRepository.ObtenerCodigoUnidadMedida(requestDto);
            if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_UNIDADMEDIDA_CODIGO);


            var entity = UnidadMedidaMap.MaptoEntity(request);

            var idUsuarioFuncionCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioFuncionCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IUnidadMedidaRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_UNIDAD_MEDIDA_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
