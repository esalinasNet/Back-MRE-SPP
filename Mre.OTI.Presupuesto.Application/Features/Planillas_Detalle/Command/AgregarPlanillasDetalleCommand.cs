using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
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

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Command
{   

    public class AgregarPlanillasDetalleCommand : IRequestHandler<AgregarPlanillasDetalleViewModel, CommandResponseViewModel>
    {
        readonly private IPlanillasDetalleRepository _IPlanillasDetalleRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarPlanillasDetalleCommand(IUsuarioRolRepository IIUsuarioRolRepository, IPlanillasDetalleRepository IPlanillasDetalleRepository, IMapper mapper)
        {
            _IPlanillasDetalleRepository = IPlanillasDetalleRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarPlanillasDetalleViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
        VariablesGlobales.TablaRol.ANALISTA_OGTH
    });

            /*if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_ACCIONES_AÑO_REQUIRED);
            if (string.IsNullOrEmpty(request.apellidosNombres)) throw new MreException(Constantes.MensajesError.EX_ACCIONES_DESCRIPCION_REQUIRED);

            // Crear el DTO con los valores del request
            var requestDto = new ObtenerCodigoPlanillasDetalleRequestDTO
            {
                anio = request.anio,
                Mes = request.Mes,
                nroDocumento = request.nroDocumento
            };*/

            //valida si el Codigo de PlanillasDetalle existe 
            /*var valCodigo = await _IPlanillasDetalleRepository.ObtenerCodigoPlanillasDetalle(requestDto);
            if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_ACCIONES_CODIGO_OBJETIVOS); */

            var entity = PlanillasDetalleMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IPlanillasDetalleRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACCIONES_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
