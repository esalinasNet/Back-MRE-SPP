using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Acciones.Command
{
    public class AgregarAccionesCommand : IRequestHandler<AgregarAccionesViewModel, CommandResponseViewModel>
    {
        readonly private IAccionesRepository _IAccionesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarAccionesCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesRepository IAccionesRepository, IMapper mapper)
        {
            _IAccionesRepository = IAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarAccionesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_ACCIONES_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcionObjetivos)) throw new MreException(Constantes.MensajesError.EX_ACCIONES_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoAccionesRequestDTO
            {
                anio = request.anio,
                codigoAcciones = request.codigoAcciones
            };

            //valida si el Codigo de Acciones existe 
            var valCodigo = await _IAccionesRepository.ObtenerCodigoAcciones(requestDto);
            if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_ACCIONES_CODIGO_OBJETIVOS);          

            var entity = AccionesMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IAccionesRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACCIONES_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
