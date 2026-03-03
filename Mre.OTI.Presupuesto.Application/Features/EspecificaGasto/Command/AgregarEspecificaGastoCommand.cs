using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;  //Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Command
{
    public class AgregarEspecificaGastoCommand : IRequestHandler<AgregarEspecificaGastoViewModel, CommandResponseViewModel>
    {
        private readonly IEspecificaGastoRepository _IEspecificaGastoRepository;        
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarEspecificaGastoCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEspecificaGastoRepository IEspecificaGastoRepository)
        {
            _IEspecificaGastoRepository = IEspecificaGastoRepository;            
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarEspecificaGastoViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });
                        
            var valClasificador = await _IEspecificaGastoRepository.ObtenerClasificador(request.clasificador);
            if (valClasificador != null) throw new MreException(Constantes.MensajesError.EX_ESPECIFICA_CLASIFICADOR_DP);

            if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_ESPECIFICA_GASTO_DESCRIPCION_REQUIRED);

            var entity = EspecificaGastoMap.MaptoEntity(request);
            var idUsuarioEspecificaCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioEspecificaCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IEspecificaGastoRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ESPECIFICA_GASTO_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
