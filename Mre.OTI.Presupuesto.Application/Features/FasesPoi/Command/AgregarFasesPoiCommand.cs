using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Command
{
    public class AgregarFasesPoiCommand : IRequestHandler<AgregarFasesPoiViewModel, CommandResponseViewModel>
    {
        readonly private IFasesPoiRepository _IFasesPoiRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarFasesPoiCommand(IUsuarioRolRepository IIUsuarioRolRepository, IFasesPoiRepository IFasesPoiRepository, IMapper mapper)
        {
            _IFasesPoiRepository = IFasesPoiRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarFasesPoiViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

           /* if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_OBJETIVOS_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcionObjetivos)) throw new MreException(Constantes.MensajesError.EX_ACCIONES_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoAccionesRequestDTO
            {
                anio = request.anio,
                codigoAcciones = request.codigoAcciones
            };

            //hay que validar como esta en PersonaRepository.
            var valCodigo = await _IAccionesRepository.ObtenerCodigoAcciones(requestDto);
            if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_ACCIONES_CODIGO_OBJETIVOS);
            */

            var entity = FasesPoiMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IFasesPoiRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_FASESPOI_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
