using AutoMapper;
using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.SubPrograna.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Responses.SubPrograma;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Command
{
    internal class AgregarSubProgramaCommand : IRequestHandler<AgregarSubProgramaViewModel, CommandResponseViewModel>
    {
        private readonly ISubProgramaRepository _ISubProgramaRepository;        
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarSubProgramaCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            ISubProgramaRepository ISubProgramaRepository)
            
        {
            _ISubProgramaRepository = ISubProgramaRepository;            
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarSubProgramaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            //hay que validar como esta en PersonaRepository.
            if (string.IsNullOrEmpty(request.descripcion)) throw new MreException(Constantes.MensajesError.EX_SUBPROGRAMA_DESCRIPCION_REQUIRED);

            var entity = SubProgramaMap.MaptoEntity(request);
            var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _ISubProgramaRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_SUBPROGRAMA_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };

        }
    }
}
