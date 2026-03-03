using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Command
{
    public class AgregarTipoDeCambioCommand : IRequestHandler<AgregarTipoDeCambioViewModel, CommandResponseViewModel>
    {
        readonly private ITipoDeCambioRepository _ITipoDeCambioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarTipoDeCambioCommand(IUsuarioRolRepository IIUsuarioRolRepository, ITipoDeCambioRepository ITipoDeCambioRepository, IMapper mapper)
        {
            _ITipoDeCambioRepository = ITipoDeCambioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarTipoDeCambioViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            //hay que validar como esta en PersonaRepository.
            if (string.IsNullOrEmpty(request.nombre)) throw new MreException(Constantes.MensajesError.EX_TIPODECAMBIO_DESCRIPCION_REQUIRED);

            var entity = TipoDeCambioMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _ITipoDeCambioRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_TIODECAMBIO_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
