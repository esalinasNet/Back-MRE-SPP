using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos;
using Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Command;
using Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{    
    public class AprobacionesCostosMap
    {
        public static ObtenerAprobacionesCostosPaginadoResponseDTO MaptoDTO(AprobacionesCostos item)
        {
            return new ObtenerAprobacionesCostosPaginadoResponseDTO()
            {
                idAprobaciones = item.ID_APROBACIONES,
                idAnio = item.ID_ANIO,
                idProgramacionActividad = item.ID_PROGRAMACION_ACTIVIDAD,

                idCentroCostos = item.ID_CENTRO_COSTOS,
                
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerAprobacionesCostosPaginadoRequestDTO MaptoDTO(ObtenerAprobacionesCostosPaginadoViewModel item)
        {
            return new ObtenerAprobacionesCostosPaginadoRequestDTO()
            {
                anio = item.anio,

                centroCostos = item.centroCostos,
                descripcionCostos = item.descripcionCostos,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerAprobacionesCostosRequestDTO MaptoDTO(ObtenerAprobacionesCostosViewModel item)
        {
            return new ObtenerAprobacionesCostosRequestDTO()
            {
                idAprobaciones = item.idAprobaciones
            };
        }

        public static AprobacionesCostos MaptoEntity(AgregarAprobacionesCostosViewModel request)
        {
            return new AprobacionesCostos()
            {
                ID_ANIO = request.idAnio,
                
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,

                ID_CENTRO_COSTOS = request.idCentroCostos,
                
                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static AprobacionesCostos MaptoEntity(ActualizarAprobacionesCostosViewModel request)
        {
            return new AprobacionesCostos()
            {
                ID_APROBACIONES = request.idAprobaciones,
                ID_ANIO = request.idAnio,

                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,

                ID_CENTRO_COSTOS = request.idCentroCostos,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static AprobacionesCostos MaptoEntity(EliminarAprobacionesCostosViewModel request)
        {
            return new AprobacionesCostos()
            {
                ID_APROBACIONES = request.idAprobaciones,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        } 

        public static ObtenerAprobacionesCentroCostosRequestDTO MaptoDTOAprobacionesCentroCostos(ObtenerAprobacionesCentroCostosViewModel item)
        {
            return new ObtenerAprobacionesCentroCostosRequestDTO()
            {
                anio = item.anio,
                centroCostos = item.centroCostos
            };
        }

        public static ObtenerListadoAprobacionesCostosResponseViewModel MaptoViewModelAprobacionesCostos(dynamic item)
        {
            return new ObtenerListadoAprobacionesCostosResponseViewModel()
            {
                idAprobaciones = item.idAprobaciones,
                idAnio = item.idAnio,
                anio = item.anio,

                idProgramacionActividad = item.idProgramacionActividad,
                codigoProgramacion = item.codigoProgramacion,

                idCentroCostos = item.idCentroCostos,
                centroCostos = item.centroCostos,
                descripcionCentroCostos = item.descripcionCentroCostos,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoAprobacionesCostosRequestDTO MaptoAprobacionesCostosDTO(ObtenerListadoAprobacionesCostosViewModel item)
        {
            return new ObtenerListadoAprobacionesCostosRequestDTO()
            {
                idAnio = item.idAnio
            };
        }
    }
}
