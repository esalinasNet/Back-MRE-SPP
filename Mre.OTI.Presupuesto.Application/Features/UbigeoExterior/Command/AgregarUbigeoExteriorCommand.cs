using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Command
{
    public class AgregarUbigeoExteriorCommand : IRequestHandler<AgregarUbigeoExteriorViewModel, CommandResponseViewModel>
    {
        readonly private IUbigeoExteriorRepository _IUbigeoExteriorRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarUbigeoExteriorCommand(IUsuarioRolRepository IIUsuarioRolRepository, IUbigeoExteriorRepository IUbigeoExteriorRepository, IMapper mapper)
        {
            _IUbigeoExteriorRepository = IUbigeoExteriorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarUbigeoExteriorViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            //hay que validar como esta en PersonaRepository.
            if (string.IsNullOrEmpty(request.nombreOse)) throw new MreException(Constantes.MensajesError.EX_UBIGEO_EXTERIOR_DESCRIPCION_REQUIRED);

            var entity = UbigeoExteriorMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IUbigeoExteriorRepository.GuardarUbigeoExterior(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_UBIGEO_EXTERIOR_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
