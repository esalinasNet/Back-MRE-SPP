using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Command
{
    public class AgregarFuncionCommand : IRequestHandler<AgregarFuncionViewModel, CommandResponseViewModel>
    {
        readonly private IFuncionRepository _IFuncionRepository;        
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarFuncionCommand(IFuncionRepository IFuncionRepository, IUnitOfWork IUnitOfWork, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _IFuncionRepository = IFuncionRepository;            
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarFuncionViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            //hay que validar como esta en PersonaRepository.
            if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_FUNCION_DESCRIPCION_REQUIRED);

            var entity = FuncionMap.MaptoEntity(request);

            var idUsuarioFuncionCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioFuncionCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IFuncionRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_FUNCION_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };            
        }
    }
}
