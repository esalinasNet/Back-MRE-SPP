using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Command
{
    public class EliminarCatalogoCommand : IRequestHandler<EliminarCatalogoViewModel, CommandResponseViewModel>
    {
        readonly private ICatalogoRepository _ICatalogoRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;


        public EliminarCatalogoCommand(ICatalogoRepository ICatalogoRepository,  IUsuarioRolRepository  IIUsuarioRolRepository)
        {
            _ICatalogoRepository = ICatalogoRepository;
             _IUsuarioRolRepository = IIUsuarioRolRepository;

        }
        public async Task<CommandResponseViewModel> Handle(EliminarCatalogoViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> 
            { 
                VariablesGlobales.TablaRol.ANALISTA_OGTH 
            });

            if (request.idCatalogo == 0) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ELIMINAR_ID_REQUIRED);

            var entity = CatalogoMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;
            var result = await _ICatalogoRepository.Eliminar(entity);


            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_CATALOGO_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };

        }
    }
}
