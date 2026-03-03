using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Command
{
    public class ActualizarRolCommand : IRequestHandler<ActualizarRolViewModel, CommandResponseViewModel>
    {
        readonly private IRolRepository _IRolRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarRolCommand(IUsuarioRolRepository IIUsuarioRolRepository, IRolRepository IRolRepository)
        {
            _IRolRepository = IRolRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(ActualizarRolViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
            if (request.idRol == 0) throw new MreException(Constantes.MensajesError.EX_ROL_ACTUALIZAR_ID_REQUIRED);
            if (string.IsNullOrEmpty(request.nombre)) throw new MreException(Constantes.MensajesError.EX_ROL_NOMBRE_REQUIRED);

            var valNombre = await _IRolRepository.ObtenerRolVal(new ObtenerRolValRequestDTO()
            {
                nombre = request.nombre,
            });
            if (valNombre != null && valNombre.idRol != request.idRol) throw new MreException(Constantes.MensajesError.EX_ROL_NOMBRE_DP);


            var entity = RolMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;


            var result = await _IRolRepository.Actualizar(entity);
            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ROL_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };

        }
    }
}
