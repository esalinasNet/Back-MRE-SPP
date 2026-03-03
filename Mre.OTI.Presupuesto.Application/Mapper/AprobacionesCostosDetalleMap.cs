using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos_Detalle;
using Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Command;
using Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Queries;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class AprobacionesCostosDetalleMap
    {
        public static ObtenerAprobacionesCostosDetallePaginadoResponseDTO MaptoDTO(AprobacionesCostosDetalle item)
        {
            return new ObtenerAprobacionesCostosDetallePaginadoResponseDTO()
            {
                idAprobacionesDetalle = item.ID_APROBACIONES_DETALLE,
                idAprobaciones = item.ID_APROBACIONES,

                idPersona = item.ID_PERSONA,
                //nombresApellidos = item.NO

                //idCentroCostos = item.ID_CENTRO_COSTOS,
                //centroCostos = item.
                //descripcionCentroCostos = item.ID_ESPECIFICA,

                puestoTrabajo = item.PUESTO_TRABAJO,

                fechaInicio = item.FECHA_INICIO,
                fechaFin = item.FECHA_FIN,

                activo = item.ACTIVO,

                idEstado = item.ID_ESTADO,

                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerAprobacionesCostosDetallePaginadoRequestDTO MaptoDTO(ObtenerAprobacionesCostosDetallePaginadoViewModel item)
        {
            return new ObtenerAprobacionesCostosDetallePaginadoRequestDTO()
            {
                idAprobaciones = item.idAprobaciones,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerAprobacionesCostosDetalleRequestDTO MaptoDTO(ObtenerAprobacionesCostosDetalleViewModel item)
        {
            return new ObtenerAprobacionesCostosDetalleRequestDTO()
            {
                idAprobacionesDetalle = item.idAprobacionesDetalle
            };
        }

        public static AprobacionesCostosDetalle MaptoEntity(AgregarAprobacionesCostosDetalleViewModel request)
        {
            return new AprobacionesCostosDetalle()
            {
                ID_APROBACIONES_DETALLE = request.idAprobacionesDetalle,
                ID_APROBACIONES = request.idAprobaciones,
                ID_PERSONA = request.idPersona,

                //ID_CENTRO_COSTOS = request.idCentroCostos,

                PUESTO_TRABAJO = request.puestoTrabajo,

                //FECHA_INICIO = request.fechaInicio,
                //FECHA_FIN = request.fechaFin,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static AprobacionesCostosDetalle MaptoEntity(ActualizarAprobacionesCostosDetalleViewModel request)
        {
            return new AprobacionesCostosDetalle()
            {
                ID_APROBACIONES_DETALLE = request.idAprobacionesDetalle,
                ID_APROBACIONES = request.idAprobaciones,
                ID_PERSONA = request.idPersona,

                //ID_CENTRO_COSTOS = request.idCentroCostos,

                PUESTO_TRABAJO = request.puestoTrabajo,

                //FECHA_INICIO = request.fechaInicio,
                //FECHA_FIN = request.fechaFin,

                ID_ESTADO = request.idEstado,

                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static AprobacionesCostosDetalle MaptoEntityAprobados(ActualizarAprobacionesCostosDetalleAprobadosViewModel request)
        {
            return new AprobacionesCostosDetalle()
            {
                ID_APROBACIONES_DETALLE = request.idAprobacionesDetalle,
                
                FECHA_INICIO = request.fechaInicio,
                FECHA_FIN = request.fechaFin,

                ID_ESTADO = request.idEstado,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static AprobacionesCostosDetalle MaptoEntity(EliminarAprobacionesCostosDetalleViewModel request)
        {
            return new AprobacionesCostosDetalle()
            {
                ID_APROBACIONES_DETALLE = request.idAprobacionesDetalle,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }


    }
}