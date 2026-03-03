using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Command
{
    public class AgregarObjetivosCommand : IRequestHandler<AgregarObjetivosViewModel, CommandResponseViewModel>
    {
        readonly private IOjetivosRepository _IOjetivosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarObjetivosCommand(IUsuarioRolRepository IIUsuarioRolRepository, IOjetivosRepository IOjetivosRepository, IMapper mapper)
        {
            _IOjetivosRepository = IOjetivosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarObjetivosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if ( request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_OBJETIVOS_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcionObjetivos)) throw new MreException(Constantes.MensajesError.EX_OBJETIVOS_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoObjetivosRequestDTO
            {
                anio = request.anio,
                codigoObjetivos = request.codigoObjetivos
            };

            //hay que validar como esta en PersonaRepository.
            var valCodigo = await _IOjetivosRepository.ObtenerCodigoObjetivos(requestDto);
            if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_OBJETIVOS_CODIGO_OBJETIVOS);
            

            var entity = ObjetivosMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IOjetivosRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_OBJETIVOS_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
