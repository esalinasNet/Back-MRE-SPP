using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Paises.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Paises.Command
{
    public class AgregarPaisesCommand : IRequestHandler<AgregarPaisesViewModel, CommandResponseViewModel>
    {
        readonly private IPaisesRepository _IPaisesRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarPaisesCommand(IPaisesRepository IPaisesRepository, IUnitOfWork IUnitOfWork, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _IPaisesRepository = IPaisesRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarPaisesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            //hay que validar como esta en PersonaRepository.
            if (string.IsNullOrEmpty(request.nombre_pais)) throw new MreException(Constantes.MensajesError.EX_PAIS_DESCRIPCION_REQUIRED);


            var entity = PaisesMap.MaptoEntity(request);
            var idUsuarioPaisesCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioCreacion = idUsuarioPaisesCreacion;
            entity.fechaCreacion = DateTime.Now;

            var result = await _IPaisesRepository.Guardar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_PAIS_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
