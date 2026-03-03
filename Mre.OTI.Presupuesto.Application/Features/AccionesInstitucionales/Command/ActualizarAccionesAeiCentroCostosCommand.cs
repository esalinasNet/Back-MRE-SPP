using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Command
{
    public class ActualizarAccionesAeiCentroCostosCommand : IRequestHandler<ActualizarAccionesAeiCentroCostosViewModel, CommandResponseViewModel>
    {
        readonly private IAccionesInstitucionalesRepository _IAccionesInstitucionalesRepository;
        readonly private IAeiCentroCostosRepository _IAeiCentroCostosRepository;

        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ActualizarAccionesAeiCentroCostosCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesInstitucionalesRepository IAccionesInstitucionalesRepository, IAeiCentroCostosRepository IAeiCentroCostosRepository, IMapper mapper)
        {
            _IAccionesInstitucionalesRepository = IAccionesInstitucionalesRepository;
            _IAeiCentroCostosRepository = IAeiCentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarAccionesAeiCentroCostosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_ACCIONES_INSTITUCIONALES_AÑO_REQUIRED);

                //se elimina todos los centros de costo segun el idAcciones 
                var requestentity = AeiCentroCostosMap.MaptoEntity(new EliminarAeiCentroCostosViewModel
                {
                    idAnio = request.idAnio,
                    idAcciones = request.idAcciones,
                    ipModificacion = request.ipModificacion,
                    usuarioModificacion = request.usuarioModificacion
                });

                var valCodigo = await _IAeiCentroCostosRepository.Eliminar(requestentity);
                //if (valCodigo != 0 ) throw new MreException(Constantes.MensajesError.EX_ACCIONES_CODIGO_OBJETIVOS);

                //recorremos la listaa de centro de costos y se registran 
                foreach (var idCostos in request.idCentroCostos)
                {
                    var valrequestentity = AeiCentroCostosMap.MaptoEntity(new AgregarAeiCentroCostosViewModel
                    {
                        idAnio = request.idAnio,
                        idAcciones = request.idAcciones,
                        idCentroCostos = idCostos,
                        usuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT),
                        ipCreacion = request.ipCreacion
                    });

                    var valagragar = await _IAeiCentroCostosRepository.Guardar(valrequestentity);
                }

                var entity = AccionesInstitucionalesMap.MaptoEntity(request);

                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IAccionesInstitucionalesRepository.ActualizarAEICostos(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_ACCIONES_INSTITUCIOANAL_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
