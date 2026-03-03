using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
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

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Command
{
    public class AgregarCatalogoCommand : IRequestHandler<AgregarCatalogoViewModel, CommandResponseViewModel>
    {
        readonly private ICatalogoRepository _ICatalogoRepository;
        readonly private IUnitOfWork _IUnitOfWork;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarCatalogoCommand(ICatalogoRepository ICatalogoRepository, IUnitOfWork IUnitOfWork, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _ICatalogoRepository = ICatalogoRepository;
            _IUnitOfWork = IUnitOfWork;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarCatalogoViewModel request, CancellationToken cancellationToken)
        {

            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });
               if (string.IsNullOrEmpty(request.descripcionCatalogo)) throw new MreException(Constantes.MensajesError.EX_CATALOGO_NOMBRE_REQUIRED);

                var valNombreCatalogo = await _ICatalogoRepository.ObtenerCatalogoVal(new ObtenerCatalogoValRequestDTO()
                {
                    nombreCatalogo = request.descripcionCatalogo,
                });
                if (valNombreCatalogo != null) throw new MreException(Constantes.MensajesError.EX_CATALOGO_DESCRIPCION_DP);

                var valCodigoCatalogo = await _ICatalogoRepository.ObtenerCatalogoVal(new ObtenerCatalogoValRequestDTO()
                {
                    codigoCatalogo = request.codigoCatalogo,
                });
                if (valCodigoCatalogo != null) throw new MreException(Constantes.MensajesError.EX_CATALOGO_CODIGO_DP);

                var entity = CatalogoMap.MaptoEntity(request);
                var idUsuarioRolCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioRolCreacion;

                var result = await _ICatalogoRepository.Guardar(entity);

                //   _IUnitOfWork.Commit();
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_CATALOGO_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };
        }
    }
}
