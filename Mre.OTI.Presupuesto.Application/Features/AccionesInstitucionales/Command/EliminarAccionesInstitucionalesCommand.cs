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

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Command
{
    public class EliminarAccionesInstitucionalesCommand : IRequestHandler<EliminarAccionesInstitucionalesViewModel, CommandResponseViewModel>
    {
        readonly private IAccionesInstitucionalesRepository _IAccionesInstitucionalesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public EliminarAccionesInstitucionalesCommand(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesInstitucionalesRepository IAccionesInstitucionalesRepository, IMapper mapper)
        {
            _IAccionesInstitucionalesRepository = IAccionesInstitucionalesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarAccionesInstitucionalesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idAcciones == 0) throw new MreException(Constantes.MensajesError.EX_ACCIONES_INSTITUCIONALES_ELIMINAR_ID_REQUIRED);

            var entity = AccionesInstitucionalesMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IAccionesInstitucionalesRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACCIONES_INSTITUCIOANAL_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
