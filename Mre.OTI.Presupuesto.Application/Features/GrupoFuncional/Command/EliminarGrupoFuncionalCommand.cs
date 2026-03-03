using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Command
{
    public class EliminarGrupoFuncionalCommand : IRequestHandler<EliminarGrupoFuncionalViewModel, CommandResponseViewModel>
    {
        private readonly IGrupoFuncionalRepository _IGrupoFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarGrupoFuncionalCommand(IUsuarioRolRepository IUsuarioRolRepository, IGrupoFuncionalRepository IGrupoFuncionalRepository, IMapper mapper)
        {
            _IGrupoFuncionalRepository = IGrupoFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarGrupoFuncionalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idGrupoFuncional == 0) throw new MreException(Constantes.MensajesError.EX_GRUPOFUNCIONAL_ELIMINAR_ID_REQUIRED);

            var entity = GrupoFuncionalMap.MaptoEntity(request);

            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IGrupoFuncionalRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_GRUPO_FUNCIONAL_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
