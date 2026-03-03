using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Application.Features.Persona.Command;
using Mre.OTI.Presupuesto.Application.Features.Persona.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
  

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class PersonaMap
    {
        public static ObtenerListadoPersonaResponseViewModel MaptoViewModel(dynamic usuario)
        {
            return new ObtenerListadoPersonaResponseViewModel()
            {
                idPersona = usuario.idPersona,
                nombres = usuario.nombres,
                apellidoPaterno = usuario.apellidoPaterno,
                apellidoMaterno = usuario.apellidoMaterno
            };

        }
        public static Persona MaptoEntity(AgregarPersonaViewModel request)
        {
            return new Persona()
            {
                NOMBRES = request.nombres,
                APELLIDO_PATERNO = request.apellidoPaterno,
                APELLIDO_MATERNO = request.apellidoMaterno,
                ID_TIPO_DOCUMENTO = request.idTipoDocumento,
                NUMERO_DOCUMENTO = request.numeroDocumento,
                ID_ESTADO_CIVIL = request.idEstadoCivil,
                ID_PAIS_NACIMIENTO = request.idPaisNacimiento,
                CORREO = request.correo,
                SEXO=request.sexo,
                NUMERO_TELEFONO = request.numeroTelefono,
                FECHA_NACIMIENTO =request.fechaNacimiento.Value,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }
        //public static Persona MaptoEntityEvaluado(ListarCargaResponseDTO request)
        //{
        //    return new Persona()
        //    {
        //        NOMBRES = request.nombresEvaluado,
        //        APELLIDO_PATERNO = request.paternoEvaluado,
        //        APELLIDO_MATERNO = request.maternoEvaluado,
        //        NUMERO_DOCUMENTO = request.numDocumentoEvaluado,
        //    }; ;
        //}
        //public static Persona MaptoEntityEvaluador(ListarCargaResponseDTO request)
        //{
        //    return new Persona()
        //    {
        //        NOMBRES = request.nombresEvaluador,
        //        APELLIDO_PATERNO = request.paternoEvaluador,
        //        APELLIDO_MATERNO = request.maternoEvaluador,
        //        NUMERO_DOCUMENTO = request.numDocumentoEvaluador,
        //    }; ;
        //}
        public static Persona MaptoEntity(ActualizarPersonaViewModel request)
        {
            return new Persona()
            {
                ID_PERSONA = request.idPersona,
                NOMBRES = request.nombres,
                APELLIDO_PATERNO = request.apellidoPaterno,
                APELLIDO_MATERNO = request.apellidoMaterno,
                ID_TIPO_DOCUMENTO = request.idTipoDocumento,
                NUMERO_DOCUMENTO = request.numeroDocumento,
                ID_ESTADO_CIVIL = request.idEstadoCivil,
                NUMERO_TELEFONO=request.numeroTelefono,
                ID_PAIS_NACIMIENTO = request.idPaisNacimiento,
                CORREO = request.correo,
                SEXO= request.sexo,
                ACTIVO=request.activo,
                FECHA_NACIMIENTO = request.fechaNacimiento,
                usuarioModificacion = request.usuarioModificacion,
                ipModificacion = request.ipModificacion

            }; ;
        }
        public static Persona MaptoEntity(EliminarPersonaViewModel request)
        {
            return new Persona()
            {
                ID_PERSONA = request.idPersona,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion
            }; 
        }
        //public static ObtenerPersonaValRequestDTO MaptoDTOEvaluador(ListarCargaResponseDTO item)
        //{
        //    return new ObtenerPersonaValRequestDTO()
        //    {
        //        numeroDocumento=item.numDocumentoEvaluador
        //    };
        //}
        //public static ObtenerPersonaValRequestDTO MaptoDTOEvaluado(ListarCargaResponseDTO item)
        //{
        //    return new ObtenerPersonaValRequestDTO()
        //    {
        //        numeroDocumento = item.numDocumentoEvaluado
        //    };
        //}
        public static ObtenerPersonaPaginadoRequestDTO MaptoDTO(ObtenerPersonaPaginadoViewModel item)
        {
            return new ObtenerPersonaPaginadoRequestDTO()
            {
                idTipoDocumento=item.idTipoDocumento,
                nombres = item.nombres,
                apellidoPaterno = item.apellidoPaterno,
                numeroDocumento=item.numeroDocumento,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo=item.activo
            };
        }

        public static ObtenerPersonaPaginadoResponseDTO MaptoDTO(Persona item)
        {
            return new ObtenerPersonaPaginadoResponseDTO()
            {
                idPersona = item.ID_PERSONA,
                nombres = item.NOMBRES,
                apellidoPaterno = item.APELLIDO_PATERNO,
                apellidoMaterno=item.APELLIDO_MATERNO,
                idTipoDocumento=item.ID_TIPO_DOCUMENTO,
                numeroDocumento = item.NUMERO_DOCUMENTO,
                paisNacimiento = item.paisNacimiento,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }
    }
}
