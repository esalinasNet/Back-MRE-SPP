using Mre.OTI.Presupuesto.Application.DTO.UsuarioRol;
using Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Command;
using Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Queries;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class UsuarioRolMap
    {
        public static UsuarioRol MaptoEntity(AgregarUsuarioRolViewModel request)
        {
            return new UsuarioRol()
            {
                ID_PERFIL = request.idRol,
                ID_USUARIO = request.idUsuario,
                ACCESO_PRIVADO = request.accesoPrivado,                
                ID_CENTRO_COSTOS = request.idCentroCostos,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }
        public static UsuarioRol MaptoEntity(ActualizarUsuarioRolViewModel request)
        {
            return new UsuarioRol()
            {
                ID_USUARIO_ROL = request.idUsuarioRol,
                ID_PERFIL = request.idRol,
                ID_CENTRO_COSTOS = request.idCentroCostos,
                usuarioModificacion = request.usuarioModificacion,
                ipModificacion = request.ipModificacion

            }; ;
        }
        public static UsuarioRol MaptoEntity(EliminarUsuarioRolViewModel request)
        {
            return new UsuarioRol()
            {
                ID_USUARIO_ROL = request.idUsuarioRol,
                ipCreacion = request.ipModificacion,
                usuarioCreacion = request.usuarioModificacion
            }; ;
        }
        public static ObtenerUsuarioRolExteriorResponseDTO MaptoDTO(ObtenerUsuarioRolResponseDTO item)
        {
            return new ObtenerUsuarioRolExteriorResponseDTO()
            {
                idRol = item.idRol,
                idUsuario = item.idUsuario,
                codigoRol=item.codigoRol,
                idCentroCostos = item.idCentroCostos,
                idUsuarioRol =item.idUsuarioRol
            };
        }
        public static ObtenerUsuarioRolPaginadoRequestDTO MaptoDTO(ObtenerUsuarioRolPaginadoViewModel item)
        {
            return new ObtenerUsuarioRolPaginadoRequestDTO()
            {
                idRol = item.idRol,
                idUsuario = item.idUsuario,
                idSistema = item.idSistema,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina
            };
        }
        public static ObtenerUsuarioRolRequestDTO MaptoDTO(ObtenerUsuarioRolViewModel item)
        {
            return new ObtenerUsuarioRolRequestDTO()
            {
                idUsuarioRol = item.idUsuarioRol
            };
        }

        public static ObtenerUsuarioRolPaginadoResponseDTO MaptoDTO(UsuarioRol item)
        {
            return new ObtenerUsuarioRolPaginadoResponseDTO()
            {
                idUsuarioRol = item.ID_USUARIO_ROL,
                idUsuario = item.ID_USUARIO,
                idRol = item.ID_PERFIL,
                idCentroCostos = item.ID_CENTRO_COSTOS,
                accesoPrivado = item.ACCESO_PRIVADO,
                //nombreSistema = item.nombreSistema,
                //nombreOSE = item.nombreOSE,

                activo = item.ACTIVO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }
    }
}
