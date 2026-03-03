using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Application.Features.Rol.Queries;
using Mre.OTI.Presupuesto.Application.Features.Usuario.Command;
using Mre.OTI.Presupuesto.Application.Features.Usuario.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class UsuarioMap
    {
        public static ObtenerListadoUsuarioResponseViewModel MaptoViewModel(dynamic usuario)
        {
            return new ObtenerListadoUsuarioResponseViewModel()
            {
                apellidoMaterno = usuario.apellidoMaterno,
                apellidoPaterno = usuario.apellidoPaterno,
                idUsuario = usuario.idUsuario,
                nombres = usuario.nombres
            };

        }

        public static ObtenerListadoUsuarioSelectResponseViewModel MaptoViewModelSelect(dynamic usuario)
        {
            return new ObtenerListadoUsuarioSelectResponseViewModel()
            {
                apellidoMaterno = usuario.apellidoMaterno,
                apellidoPaterno = usuario.apellidoPaterno,
                idUsuario = usuario.idUsuario,
                nombres = usuario.nombres
            };

        }

        public static ObtenerListadoUsuarioRequestDTO MaptoDTO(ObtenerListadoUsuarioViewModel item)
        {
            return new ObtenerListadoUsuarioRequestDTO()
            {
                idRol = item.idRol
            };
        }

        public static Usuario MaptoEntity(AgregarUsuarioViewModel request)
        {
            return new Usuario()
            {
               
                CORREO = request.correo,
                ID_PERSONA = request.idPersona,
                LOGIN = request.login,
                CLAVE = request.clave,
                USUARIO_NT = request.usuarioNT,
                CLAVE_NT = request.claveNT,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }
        public static Usuario MaptoEntity(ActualizarUsuarioViewModel request)
        {
            return new Usuario()
            {
                ID_USUARIO = request.idUsuario,
                CORREO = request.correo,
                ID_PERSONA = request.idPersona,
                LOGIN = request.login,
                CLAVE = request.clave,
                USUARIO_NT = request.usuarioNT,
                CLAVE_NT=request.claveNT,
                usuarioModificacion = request.usuarioModificacion,
                ipModificacion = request.ipModificacion

            };
        }
        public static Usuario MaptoEntity(EliminarUsuarioViewModel request)
        {
            return new Usuario()
            {
                ID_USUARIO = request.idUsuario,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion
            }; ;
        }//ObtenerUsuarioPaginadoResponseDTO
        public static ObtenerUsuarioPaginadoRequestDTO MaptoDTO(ObtenerUsuarioPaginadoViewModel item)
        {
            return new ObtenerUsuarioPaginadoRequestDTO()
            {
                nombres = item.nombres,
                apellidoPaterno = item.apellidoPaterno,
                idTipoDocumento = item.idTipoDocumento,
                numeroDocumento = item.numeroDocumento,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina
            };
        }
        public static ObtenerUsuarioRequestDTO MaptoDTO(ObtenerUsuarioViewModel item)
        {
            return new ObtenerUsuarioRequestDTO()
            {
                idUsuario = item.idUsuario
            };
        }


        public static ObtenerUsuarioPaginadoResponseDTO MaptoDTO(Usuario item)
        {
            return new ObtenerUsuarioPaginadoResponseDTO()
            {
                idUsuario = item.ID_USUARIO,
                nombres = item.NOMBRES,
                apellidoPaterno = item.APELLIDO_PATERNO,
                apellidoMaterno = item.APELLIDO_MATERNO,
                correo = item.CORREO,
                activo = item.ACTIVO,
                tipoDocumento = item.TIPO_DOCUMENTO,
                idTipoDocumento = item.ID_TIPO_DOCUMENTO,
                usuarioNT = item.USUARIO_NT,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerListarUsuariosResponseViewModel MaptoListarUsuarioViewModel(dynamic usuario)
        {
            return new ObtenerListarUsuariosResponseViewModel()
            {
                apellidoMaterno = usuario.apellidoMaterno,
                apellidoPaterno = usuario.apellidoPaterno,
                idUsuario = usuario.idUsuario,
                nombres = usuario.nombres
            };

        }


    }
}
