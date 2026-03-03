using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Command
{
    public class EliminarCajaChicaCommand : IRequestHandler<EliminarCajaChicaViewModel, CommandResponseViewModel>
    {
        private readonly ICajaChicaRepository _ICajaChicaRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarCajaChicaCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICajaChicaRepository ICajaChicaRepository)
        {
            _ICajaChicaRepository = ICajaChicaRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarCajaChicaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionCajaChica == 0) throw new MreException("Debe especificar el ID de Caja Chica");

                var entity = CajaChicaMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _ICajaChicaRepository.Eliminar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Caja Chica eliminada correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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