using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.DTO.CategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Command
{
    public class AgregarCategoriaPresupuestalCommand : IRequestHandler<AgregarCategoriaPresupuestalViewModel, CommandResponseViewModel>
    {
        readonly private ICategoriaPresupuestalRepository _ICategoriaPresupuestalRepository;
        readonly private IAeiCategoriaPresupuestalRepository _IAeiCategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarCategoriaPresupuestalCommand(IUsuarioRolRepository IIUsuarioRolRepository, ICategoriaPresupuestalRepository ICategoriaPresupuestalRepository, IAeiCategoriaPresupuestalRepository IAeiCategoriaPresupuestalRepository, IMapper mapper)
        {
            _ICategoriaPresupuestalRepository = ICategoriaPresupuestalRepository;
            _IAeiCategoriaPresupuestalRepository = IAeiCategoriaPresupuestalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarCategoriaPresupuestalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAnio == 0) throw new MreException(Constantes.MensajesError.EX_CATEGORIA_AÑO_REQUIRED);

            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);

            if (string.IsNullOrEmpty(request.descripcionPresupuestal)) throw new MreException(Constantes.MensajesError.EX_CATEGORIA_DESCRIPCION_REQUIRED);

             // Crear el DTO con los valores del request
             var requestDto = new ObtenerCodigoPresupuestalRequestDTO
             {
                 anio = request.anio,
                 codigoPresupuestal = request.codigoPresupuestal
             };
                         
             var valCodigo = await _ICategoriaPresupuestalRepository.ObtenerCodigoPresupuestal (requestDto);
             if (valCodigo != null) throw new MreException(Constantes.MensajesError.EX_CATEGORIAPRESUPUESTAL_CODIGO_OBJETIVOS);             

            //se elimina todos los centros de costo segun el idAcciones 
            /*var requestentity = AeiCategoriaPresupuestalMap.MaptoEntity(new EliminarAeiCategoriaPresupuestalViewModel
            {
                idAnio = request.idAnio,
                idPresupuestal = request.idPresupuestal,
                ipModificacion = request.ipCreacion,
                usuarioModificacion = idUsuarioCreacion
            });

            var valCodigo = await _IAeiCategoriaPresupuestalRepository.Eliminar(requestentity);
            //if (valCodigo != 0 ) throw new MreException(Constantes.MensajesError.EX_ACCIONES_CODIGO_OBJETIVOS);

            //recorremos la listaa de Acciones estrategicas y se registran 
            foreach (var id in request.idAcciones)
            {
                var valrequestentity = AeiCategoriaPresupuestalMap.MaptoEntity(new AgregarAeiCategoriaPresupuestalViewModel
                {
                    idAnio = request.idAnio,
                    idPresupuestal = request.idPresupuestal,
                    idAcciones = id,
                    usuarioCreacion = EncryptionPassportHandler.Decrypt(idUsuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT),
                    ipCreacion = request.ipCreacion
                });

                var valagragar = await _IAeiCategoriaPresupuestalRepository.Guardar(valrequestentity);
            }*/

            var entity = CategoriaPresupuestalMap.MaptoEntity(request);            
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _ICategoriaPresupuestalRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACCIONES_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
