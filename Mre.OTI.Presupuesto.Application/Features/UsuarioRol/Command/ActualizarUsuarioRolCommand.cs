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
    public class ActualizarUsuarioRolCommand : IRequestHandler<ActualizarUsuarioRolViewModel, CommandResponseViewModel>
    {
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        readonly private IRolRepository _IRolRepository;
        readonly private IUsuarioRepository _IUsuarioRepository;
        readonly private IUnitOfWork _IUnitOfWork;
        public ActualizarUsuarioRolCommand(
            IUsuarioRolRepository IUsuarioRolRepository, IUnitOfWork IUnitOfWork,
            IRolRepository IRolRepository, IUsuarioRolRepository IIUsuarioRolRepository,
            IUsuarioRepository IIUsuarioRepository
            )
        {
            _IUsuarioRolRepository = IUsuarioRolRepository;
            _IRolRepository = IRolRepository;
            _IUsuarioRepository = IIUsuarioRepository;
            _IUnitOfWork = IUnitOfWork;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(ActualizarUsuarioRolViewModel request, CancellationToken cancellationToken)
        {
            _IUnitOfWork.BeginTransaction();
            try
            {
               var idUsuarioModificacion= await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idRol == 0) throw new MreException(Constantes.MensajesError.EX_ROL_ACTUALIZAR_ID_REQUIRED);
                if (request.idUsuarioRol == 0) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_UPDATE_IDUSUARIOROL_REQUIRED);

                var valIdRol = await _IUsuarioRolRepository.ObtenerUsuarioRolVal(new ObtenerUsuarioRolValRequestDTO()
                {
                    idRol = request.idRol,
                    idUsuario = request.idUsuario,
                });
                if (valIdRol != null && valIdRol.idUsuarioRol != request.idUsuarioRol) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_USUARIO_ROL_DP);

                var objRol = await _IRolRepository.ObtenerRol(request.idRol);

                var entity = UsuarioRolMap.MaptoEntity(request);
                entity.usuarioModificacion = idUsuarioModificacion.ToString();

                /*
                if (objRol.codigoRol == (int) ||
                    objRol.codigoRol == (int)VariablesGlobales.TablaRol.AUXILIAR_OGTH)
                {
                    if (request.grupoPais == null || !request.grupoPais.Any()) throw new UarmException(Constantes.MensajesError.EX_USUARIOROL_GRUPO_REQUIRED);
                    var inacTodos = await _IUsuarioRolGrupoRepository.DesactivarTodosxIdUsuarioRol(new Domain.Entities.UsuarioRolGrupo() {
                        ID_USUARIO_PERFIL=request.idUsuarioRol,
                        ipModificacion= entity.ipModificacion,
                        usuarioModificacion= entity.usuarioModificacion
                    });
                }else if (objRol.codigoRol == (int)VariablesGlobales.TablaRol.PERSONAL)
                {}*/
                 if (objRol.codigoRol == (int)VariablesGlobales.TablaRol.PERSONAL && request.idCentroCostos == 0) throw new MreException(Constantes.MensajesError.EX_USUARIOROL_CentroCosto_REQUIRED);
                

               
                var result = await _IUsuarioRolRepository.Actualizar(entity);

                /*
                if (objRol.codigoRol == (int) ||
                    objRol.codigoRol == (int)VariablesGlobales.TablaRol.AUXILIAR_OGTH ||
                    objRol.codigoRol == (int))
                {
                    foreach (var item in request.grupoPais.Where(x=>x.activo))
                    {
                            item.idUsuarioRol = entity.ID_USUARIO_ROL;
                            item.ipCreacion = entity.ipModificacion;
                            item.usuarioCreacion = entity.usuarioModificacion;
                           
                            MAPEAR LA ENTIDAD PARA EL GRUPOPAIS Y ENVIAR AL REPOSITORIO GRUPOPAIS
                            var grupos = UsuarioRolGrupoMap.MaptoEntity(item);
                            var gruposinsert = await _IUsuarioRolGrupoRepository.Guardar(grupos);
                    }
                }*/
                _IUnitOfWork.Commit();
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_USUARIOROL_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
