using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.Features.Rol.Command;
using Mre.OTI.Presupuesto.Application.Features.Rol.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Rol;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class RolMap
    {
        public static ObtenerListadoRolResponseViewModel MaptoViewModel(dynamic usuario)
        {
            return new ObtenerListadoRolResponseViewModel()
            {
                idRol = usuario.idRol,
                nombre = usuario.nombre
            };
        }

        public static ObtenerListaRolResponseViewModel MaptoViewModelLista(dynamic usuario)
        {
            return new ObtenerListaRolResponseViewModel()
            {
                idRol = usuario.idRol,
                nombre = usuario.nombre
            };
        }

        public static ObtenerListadoRolRequestDTO MaptoDTO(ObtenerListadoRolViewModel item)
        {
            return new ObtenerListadoRolRequestDTO()
            {
                idSistema = item.idSistema
            };
        }

        public static Rol MaptoEntity(AgregarRolViewModel request)
        {
            return new Rol()
            {
                //ID_USUARIO = request.idRol,
                CODIGO_ROL = request.codigoRol,
                ID_SISTEMA = request.idSistema,
                NOMBRE = request.nombre,
                DESCRIPCION = request.descripcion,                
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; 
        }
        public static Rol MaptoEntity(ActualizarRolViewModel request)
        {
            return new Rol()
            {
                ID_ROL = request.idRol,
                CODIGO_ROL = request.codigoRol,
                ID_SISTEMA = request.idSistema,
                NOMBRE = request.nombre,                
                DESCRIPCION = request.descripcion,
                usuarioModificacion = request.usuarioModificacion,
                ipModificacion = request.ipModificacion

            }; ;
        }
        public static Rol MaptoEntity(EliminarRolViewModel request)
        {
            return new Rol()
            {
                ID_ROL = request.idRol,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion
            }; ;
        }//ObtenerRolPaginadoResponseDTO
        public static ObtenerRolPaginadoRequestDTO MaptoDTO(ObtenerRolPaginadoViewModel item)
        {
            return new ObtenerRolPaginadoRequestDTO()
            {
                nombre = item.nombre,
                descripcion = item.descripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina
            };
        }
        public static ObtenerRolRequestDTO MaptoDTO(ObtenerRolViewModel item)
        {
            return new ObtenerRolRequestDTO()
            {
                idRol = item.idRol
            };
        }

        public static ObtenerRolPaginadoResponseDTO MaptoDTO(Rol item)
        {
            return new ObtenerRolPaginadoResponseDTO()
            {
                idRol = item.ID_ROL,
                nombre = item.NOMBRE,
                descripcion = item.DESCRIPCION,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }
    }
}
