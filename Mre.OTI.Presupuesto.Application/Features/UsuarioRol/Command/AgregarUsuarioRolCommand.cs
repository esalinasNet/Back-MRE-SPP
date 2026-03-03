using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.UsuarioRol;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Command
{
    public class AgregarUsuarioRolCommand : IRequestHandler<AgregarUsuarioRolViewModel, CommandResponseViewModel>
    {
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        readonly private IRolRepository _IRolRepository;
        
        readonly private IUnitOfWork _IUnitOfWork;
        public AgregarUsuarioRolCommand(IUsuarioRolRepository IUsuarioRolRepository, IRolRepository IRolRepository, IUnitOfWork IUnitOfWork)
        {
            _IUsuarioRolRepository = IUsuarioRolRepository;
            _IRolRepository = IRolRepository;
            _IUnitOfWork = IUnitOfWork;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarUsuarioRolViewModel request, CancellationToken cancellationToken)
        {
            _IUnitOfWork.BeginTransaction();
            try
            {
               // await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
               //    VariablesGlobales.TablaRol.ANALISTA_OGTH
               //});
                if (request.idRol == 0) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_INSERT_IDROL_REQUIRED);
                if (request.idUsuario == 0) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_INSERT_IDUSUARIO_REQUIRED);


                var valIdRol = await _IUsuarioRolRepository.ObtenerUsuarioRolVal(new ObtenerUsuarioRolValRequestDTO()
                {
                    idRol = request.idRol,
                    idUsuario = request.idUsuario,
                });
                if (valIdRol != null) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_USUARIO_ROL_DP);
                
                var objRol = await _IRolRepository.ObtenerRol(request.idRol);

                /*if (objRol.codigoRol == (int) ||  objRol.codigoRol == (int)VariablesGlobales.TablaRol.AUXILIAR_OGTH || objRol.codigoRol == (int))
                {
                    //if (request.grupoPais == null || !request.grupoPais.Any()) throw new UarmException(Constantes.MensajesError.EX_USUARIOROL_INSERT_IDUSUARIO_REQUIRED);
                }
                else if (objRol.codigoRol == (int)VariablesGlobales.TablaRol.PERSONAL)
                { } */

                if (objRol.codigoRol == (int)VariablesGlobales.TablaRol.PERSONAL && request.idCentroCostos == 0) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_CentroCosto_REQUIRED);
                

                var entity = UsuarioRolMap.MaptoEntity(request);
                var idUsuarioRolCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioRolCreacion;


                var result = await _IUsuarioRolRepository.Guardar(entity);

               // if (objRol.codigoRol == (int) ||
               //    objRol.codigoRol == (int)VariablesGlobales.TablaRol.AUXILIAR_OGTH ||
               //    objRol.codigoRol == (int))
               // {
               //     foreach (var item in request.grupoPais)
               //     {
               //         if (item.activo==true)
               //         {
               //             item.idUsuarioRol = result;
               //             item.ipCreacion = entity.ipCreacion;
               //             item.usuarioCreacion = entity.usuarioCreacion;
               //             /*MAPEAR LA ENTIDAD PARA EL GRUPOPAIS Y ENVIAR AL REPOSITORIO GRUPOPAIS*/
               //             var grupos = UsuarioRolGrupoMap.MaptoEntity(item);
               //         }
               //     }
               // }

                //_IUnitOfWork.Commit();
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_USUARIOROL_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };
            }
            catch (Exception ex)
            {
                _IUnitOfWork.Rollback();
                throw ex;
            }


        }
    }
}
