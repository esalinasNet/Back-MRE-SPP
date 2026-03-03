using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Org.BouncyCastle.Security.Certificates;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Command
{
    public class EliminarUsuarioCommand : IRequestHandler<EliminarUsuarioViewModel, int>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarUsuarioCommand(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<int> Handle(EliminarUsuarioViewModel request, CancellationToken cancellationToken)
        {
            var idUsuarioPerfil = await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
            });
            if (request.idUsuario == 0) throw new MreException(Constantes.MensajesError.EX_USUARIO_ELIMINAR_ID_REQUIRED);
            var validacion = await _IUsuarioRepository.tieneAccesoActivo(request.idUsuario);
            if (validacion == 1) throw new MreException(Constantes.MensajesError.EX_USUARIO_ELIMINAR_ACCESO_ACTIVO);

            var entity = UsuarioMap.MaptoEntity(request);
            entity.usuarioModificacion = idUsuarioPerfil.ToString();
            var result = await _IUsuarioRepository.Eliminar(entity);

            return result;

        }
    }
}
