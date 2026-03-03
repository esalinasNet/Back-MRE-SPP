using Mre.OTI.Presupuesto.Application.DTO.Actividad;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.Features.Actividad.Command;
using Mre.OTI.Presupuesto.Application.Features.Actividad.Queries;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Command;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Actividad;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ActividadMap
    {
        public static ObtenerListadoActividadResponseViewModel MaptoViewModel(dynamic actividad)
        {
            return new ObtenerListadoActividadResponseViewModel()
            {
                idActividad = actividad.idActividad,
                anio = actividad.anio,
                actividad = actividad.actividad,
                descripcion = actividad.descripcion,
                estado = actividad.estado
            };

        }

        public static ObtenerListadoActividadRequestDTO MaptoActividadDTO(ObtenerListadoActividadViewModel item)
        {
            return new ObtenerListadoActividadRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static Actividad MaptoEntity(AgregarActividadViewModel request)
        {
            return new Actividad()
            {
                ID_ANIO = request.idAnio,
                ACTIVIDAD = request.actividad,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; 
        }

        public static Actividad MaptoEntity(ActualizarActividadViewModel request)
        {
            return new Actividad()
            {
                ID_ACTIVIDAD = request.idActividad,
                ID_ANIO = request.idAnio,
                ACTIVIDAD = request.actividad,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Actividad MaptoEntity(EliminarActividadViewModel request)
        {
            return new Actividad()
            {
                ID_ACTIVIDAD = request.idActividad,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerActividadPaginadoResponseDTO MaptoDTO(Actividad item)
        {
            return new ObtenerActividadPaginadoResponseDTO()
            {
                idActividad = item.ID_ACTIVIDAD,
                idAnio = item.ID_ANIO,
                actividad = item.ACTIVIDAD,
                descripcion = item.DESCRIPCION,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerActividadPaginadoRequestDTO MaptoDTO(ObtenerActividadPaginadoViewModel item)
        {
            return new ObtenerActividadPaginadoRequestDTO()
            {
                Anio = item.anio,
                actividad = item.actividad,
                descripcion = item.descripcion,
                //estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }
    }
}
