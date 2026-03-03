using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
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
    public class ActualizarAccionesInstitucionalesCommand : IRequestHandler<ActualizarAccionesInstitucionalesViewModel, CommandResponseViewModel>
    {
        readonly private IAccionesInstitucionalesRepository _IAccionesInstitucionalesRepository;
        readonly private IAeiCentroCostosRepository _IAeiCentroCostosRepository;

        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ActualizarAccionesInstitucionalesCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesInstitucionalesRepository IAccionesInstitucionalesRepository, IAeiCentroCostosRepository IAeiCentroCostosRepository, IMapper mapper)
        {
            _IAccionesInstitucionalesRepository = IAccionesInstitucionalesRepository;
            _IAeiCentroCostosRepository = IAeiCentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarAccionesInstitucionalesViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });
                                
                //hay que validar como esta en PersonaRepository.
                if (string.IsNullOrEmpty(request.descripcionObjetivos)) throw new MreException(Constantes.MensajesError.EX_ACCIONES_INSTITUCIONALES_DESCRIPCION_REQUIRED);

                var entity = AccionesInstitucionalesMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IAccionesInstitucionalesRepository.Actualizar(entity);

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
