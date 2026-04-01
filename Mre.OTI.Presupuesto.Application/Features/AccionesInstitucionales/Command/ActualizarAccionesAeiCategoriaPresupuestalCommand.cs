using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Command;
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
    public class ActualizarAccionesAeiCategoriaPresupuestalCommand : IRequestHandler<ActualizarAccionesAeiCategoriaPresupuestalViewModel, CommandResponseViewModel>
    {
        readonly private IAccionesInstitucionalesRepository _IAccionesInstitucionalesRepository;        
        readonly private IAeiCategoriaPresupuestalRepository _IAeiCategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ActualizarAccionesAeiCategoriaPresupuestalCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesInstitucionalesRepository IAccionesInstitucionalesRepository, IAeiCategoriaPresupuestalRepository IAeiCategoriaPresupuestalRepository, IMapper mapper)
        {
            _IAccionesInstitucionalesRepository = IAccionesInstitucionalesRepository;
            _IAeiCategoriaPresupuestalRepository = IAeiCategoriaPresupuestalRepository;

            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarAccionesAeiCategoriaPresupuestalViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

                //hay que validar como esta en PersonaRepository.
                if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_ACCIONES_INSTITUCIONALES_AÑO_REQUIRED);

                //se elimina todos los centros de costo segun el idAcciones 
                var requestentity = AeiCategoriaPresupuestalMap.MaptoEntity(new EliminarAeiCategoriaPresupuestalViewModel
                {
                    idAnio = request.idAnio,
                    idAcciones = request.idAcciones,
                    ipModificacion = request.ipModificacion,
                    usuarioModificacion = request.usuarioModificacion
                });

                var valCodigo = await _IAeiCategoriaPresupuestalRepository.Eliminar(requestentity);
                //if (valCodigo != 0 ) throw new MreException(Constantes.MensajesError.EX_ACCIONES_CODIGO_OBJETIVOS);

                //recorremos la listaa de Id Presupuestal y se registran 
                foreach (var idPre in request.idPresupuestal)
                {
                    var valrequestentity = AeiCategoriaPresupuestalMap.MaptoEntity(new AgregarAeiCategoriaPresupuestalViewModel
                    {
                        idAnio = request.idAnio,
                        idAcciones = request.idAcciones,
                        idPresupuestal = idPre,
                        usuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT),
                        ipCreacion = request.ipCreacion
                    });

                    var valagragar = await _IAeiCategoriaPresupuestalRepository.Guardar(valrequestentity);
                }

                var entity = AccionesInstitucionalesMap.MaptoEntityCategoria(request);

                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IAccionesInstitucionalesRepository.ActualizarAEICategoria(entity);

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
