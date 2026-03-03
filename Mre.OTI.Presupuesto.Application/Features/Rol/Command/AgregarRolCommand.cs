using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Rol;
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

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Command
{
    public class AgregarRolCommand : IRequestHandler<AgregarRolViewModel, CommandResponseViewModel>
    {
        readonly private IRolRepository _IRolRepository;
        readonly private IUnitOfWork _IUnitOfWork;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarRolCommand(IUsuarioRolRepository IIUsuarioRolRepository, IRolRepository IRolRepository, IUnitOfWork IUnitOfWork)
        {
            _IRolRepository = IRolRepository;
            _IUnitOfWork = IUnitOfWork;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarRolViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (string.IsNullOrEmpty(request.nombre)) throw new MreException(Constantes.MensajesError.EX_ROL_NOMBRE_REQUIRED);
                var valNombre = await _IRolRepository.ObtenerRolVal(new ObtenerRolValRequestDTO()
                {
                    nombre = request.nombre,
                });
                if (valNombre != null) throw new MreException(Constantes.MensajesError.EX_ROL_NOMBRE_DP);

                var entity = RolMap.MaptoEntity(request);
                var idUsuarioRolCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioRolCreacion;

                var result = await _IRolRepository.Guardar(entity);
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_ROL_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
