using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Command
{
    public class EliminarFasesPoiCommand : IRequestHandler<EliminarFasesPoiViewModel, CommandResponseViewModel>
    {
        readonly private IFasesPoiRepository _IFasesPoiRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public EliminarFasesPoiCommand(IUsuarioRolRepository IIUsuarioRolRepository, IFasesPoiRepository IFasesPoiRepository, IMapper mapper)
        {
            _IFasesPoiRepository = IFasesPoiRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarFasesPoiViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idFasesPoi == 0) throw new MreException(Constantes.MensajesError.EX_FASESPOI_ELIMINAR_ID_REQUIRED);

            var entity = FasesPoiMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IFasesPoiRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACCIONES_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
