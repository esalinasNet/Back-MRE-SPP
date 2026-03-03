using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
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
    public class ActualizarCatalogoCommand : IRequestHandler<ActualizarCatalogoViewModel, CommandResponseViewModel>
    {
        readonly private ICatalogoRepository _ICatalogoRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;


        public ActualizarCatalogoCommand(ICatalogoRepository ICatalogoRepository, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _ICatalogoRepository = ICatalogoRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;


        }
        public async Task<CommandResponseViewModel> Handle(ActualizarCatalogoViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH 
            });


            if (request.idCatalogo == 0) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ACTUALIZAR_ID_REQUIRED);
            if (string.IsNullOrEmpty(request.descripcionCatalogo)) throw new MreException(Constantes.MensajesError.EX_CATALOGO_NOMBRE_REQUIRED);

            var valNombreCatalogo = await _ICatalogoRepository.ObtenerCatalogoVal(new ObtenerCatalogoValRequestDTO()
            {
                nombreCatalogo = request.descripcionCatalogo,
            });
            if (valNombreCatalogo != null && valNombreCatalogo.idCatalogo != request.idCatalogo) throw new MreException(Constantes.MensajesError.EX_CATALOGO_DESCRIPCION_DP);

            var valCodigoCatalogo = await _ICatalogoRepository.ObtenerCatalogoVal(new ObtenerCatalogoValRequestDTO()
            {
                codigoCatalogo = request.codigoCatalogo,
            });
            if (valCodigoCatalogo != null && valCodigoCatalogo.idCatalogo != request.idCatalogo) throw new MreException(Constantes.MensajesError.EX_CATALOGO_CODIGO_DP);


            var entity = CatalogoMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _ICatalogoRepository.Actualizar(entity);
            //    return result;
            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_CATALOGO_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };


        }
    }
}
