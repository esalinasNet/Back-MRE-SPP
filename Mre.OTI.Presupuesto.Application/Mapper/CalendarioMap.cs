using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Command;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Queries;
using Mre.OTI.Presupuesto.Application.Features.CentroCostos.Command;
using Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using Mre.OTI.Presupuesto.Domain.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class CalendarioMap
    {
        public static ObtenerListadoCalendarioResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoCalendarioResponseViewModel()
            {
                idPeriodo = item.IdPeriodo,
                idAnio = item.idAnio,
                anio = item.anio,
                idMes = item.idMes,
                mesDescripcion = item.mesDescripcion,
                idCentroCostos = item.idCentroCostos,                                
                centroCostos = item.centroCostos,
                dependencia = item.dependencia,
                fechaInicio = item.fechaInicio,
                fechaFin = item.fechaFin,
                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };

        }

        public static Calendario MaptoEntity(AgregarCalendarioViewModel request)
        {
            return new Calendario()
            {
                ID_ANIO = request.idAnio,
                ID_MES = request.idMes,
                ID_CENTRO_COSTOS = request.idCentroCostos,
                FECHAINICIO = request.fechaInicio,
                FECHAFIN =  request.fechaFin,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Calendario MaptoEntity(ActualizarCalendarioViewModel request)
        {
            return new Calendario()
            {
                ID_PERIODO = request.idPeriodo,
                ID_ANIO = request.idAnio,
                ID_MES = request.idMes,
                ID_CENTRO_COSTOS = request.idCentroCostos,
                FECHAINICIO = request.fechaInicio,
                FECHAFIN = request.fechaFin,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Calendario MaptoEntity(EliminarCalendarioViewModel request)
        {
            return new Calendario()
            {
                ID_PERIODO = request.idPeriodo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCalendarioPaginadoResponseDTO MaptoDTO(Calendario item)
        {
            return new ObtenerCalendarioPaginadoResponseDTO()
            {
                idPeriodo = item.ID_PERIODO,
                idAnio = item.ID_ANIO,
                idMes = item.ID_MES,
                idCentroCostos = item.ID_CENTRO_COSTOS,
                fechaInicio = item.FECHAINICIO,
                fechaFin = item.FECHAFIN,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerCalendarioPaginadoRequestDTO MaptoDTO(ObtenerCalendarioPaginadoViewModel item)
        {
            return new ObtenerCalendarioPaginadoRequestDTO()
            {
                anio = item.anio,
                mesDescripcion = item.mesDescripcion,
                centroCostos = item.centroCostos,
                //estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerCalendarioRequestDTO MaptoDTO(ObtenerCalendarioViewModel item)
        {
            return new ObtenerCalendarioRequestDTO()
            {
                idPeriodo = item.idPeriodo
            };
        }

    }
}
