using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Sistema;
using Mre.OTI.Presupuesto.Application.Features.Sistema.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class SistemaMap
    {
        public static ObtenerListadoSistemaResponseViewModel MaptoViewModel(dynamic funcion)
        {
            return new ObtenerListadoSistemaResponseViewModel()
            {
                idSistema = funcion.idSistema,                
                nombre = funcion.nombre,
                descripcion = funcion.descripcion,
                codigo_sistema = funcion.codigo_sistema
            };

        }

      /*  public static Sistema MaptoEntity(AgregarSistemaViewModel request)
        {
            return new Sistema()
            {                
                NOMBRE = request.nombre,
                DESCRIPCION = request.descripcion,
                CODIGO_SISTEMA = request.codigo_sistema,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Sistema MaptoEntity(ActualizarSistemaViewModel request)
        {
            return new Sistema()
            {
                ID_SISTEMA = request.idSistema,
                NOMBRE = request.nombre,
                DESCRIPCION = request.descripcion,
                CODIGO_SISTEMA = request.codigo_sistema,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Sistema MaptoEntity(EliminarSistemaViewModel request)
        {
            return new Sistema()
            {
                ID_SISTEMA = request.idSistema,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }
      */

        public static ObtenerSistemaPaginadoResponseDTO MaptoDTO(Sistema item)
        {
            return new ObtenerSistemaPaginadoResponseDTO()
            {
                idSistema = item.ID_SISTEMA,                
                nombre = item.NOMBRE,
                descripcion = item.DESCRIPCION,
                codigo_sistema = item.CODIGO_SISTEMA,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerSistemaPaginadoRequestDTO MaptoDTO(ObtenerSistemaPaginadoViewModel item)
        {
            return new ObtenerSistemaPaginadoRequestDTO()
            {                
                nombre = item.nombre,
                descripcion = item.descripcion,
                //codigo_sistema = item.codigo_sistema,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }
    }
}
