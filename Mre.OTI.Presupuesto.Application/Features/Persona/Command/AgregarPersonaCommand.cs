using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
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

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Command
{
    public class AgregarPersonaCommand : IRequestHandler<AgregarPersonaViewModel, CommandResponseViewModel>
    {
        readonly private IPersonaRepository _IPersonaRepository;
        readonly private IUnitOfWork _IUnitOfWork;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarPersonaCommand(IUsuarioRolRepository IIUsuarioRolRepository, IPersonaRepository IPersonaRepository, IUnitOfWork IUnitOfWork)
        {
            _IPersonaRepository = IPersonaRepository;
            _IUnitOfWork = IUnitOfWork;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarPersonaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idTipoDocumento == 0) throw new MreException(Constantes.MensajesError.EX_PERSONA_TIPO_DOCUMENTO_REQUIRED);
                if (string.IsNullOrEmpty(request.numeroDocumento)) throw new MreException(Constantes.MensajesError.EX_PERSONA_DOCUMENTO_REQUIRED);
                if (string.IsNullOrEmpty(request.nombres)) throw new MreException(Constantes.MensajesError.EX_PERSONA_NOMBRE_REQUIRED);
                if (string.IsNullOrEmpty(request.apellidoPaterno)) throw new MreException(Constantes.MensajesError.EX_PERSONA_APELLIDO_PATERNO_REQUIRED);
                //if (string.IsNullOrEmpty(request.apellidoMaterno)) throw new UarmException(Constantes.MensajesError.EX_PERSONA_APELLIDO_MATERNO_REQUIRED);
                if (request.idEstadoCivil==0) throw new MreException(Constantes.MensajesError.EX_PERSONA_ESTADO_CIVIL_REQUIRED);
                if (request.idPaisNacimiento == 0) throw new MreException(Constantes.MensajesError.EX_PERSONA_PAIS_NACIMIENTO_REQUIRED);
                if (string.IsNullOrEmpty(request.correo) || !IsValidEmail(request.correo)) throw new MreException(Constantes.MensajesError.EX_VALIDATE_CORREO_GENERAL);
                if (request.fechaNacimiento == null) throw new MreException(Constantes.MensajesError.EX_PERSONA_FECHA_NACIMIENTO_REQUIRED);
                //if (request.numeroTelefono == null) throw new MreException(Constantes.MensajesError.EX_PERSONA_TELEFONO_REQUIRED);
                if (request.sexo == null || request.sexo == "0"  || request.sexo == "") throw new MreException(Constantes.MensajesError.EX_PERSONA_SEXO_REQUIRED);

                var valDocumento = await _IPersonaRepository.ObtenerPersonaVal(new ObtenerPersonaValRequestDTO()
                {
                    idTipoDocumento = request.idTipoDocumento,
                    numeroDocumento = request.numeroDocumento
                });
                if (valDocumento != null) throw new MreException(Constantes.MensajesError.EX_PERSONA_DOCUMENTO_DP);

                var entity = PersonaMap.MaptoEntity(request);
                var idUsuarioPersonaCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioPersonaCreacion;

                var result = await _IPersonaRepository.Guardar(entity);
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_PERSONA_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
