using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.Features.CentroCostos.Command;
using Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class CentroCostosMap
    {
        public static ObtenerListadoCentroCostosResponseViewModel MaptoViewModel(dynamic costos)
        {
            return new ObtenerListadoCentroCostosResponseViewModel()
            {
                idCentroCostos = costos.idCentroCostos,
                anio = costos.anio,
                ejecutora = costos.ejecutora,
                centroCostos = costos.centroCostos,
                descripcion = costos.descripcion,
                centroCostosPadre = costos.centroCostosPadre,
                estado = costos.estado
            };
        }

        public static ObtenerListadoCentroCostosRequestDTO MaptoCentroCostosDTO(ObtenerListadoCentroCostosViewModel item)
        {
            return new ObtenerListadoCentroCostosRequestDTO()
            {
                idAnio = item.idAnio
            };
        }


        public static ObtenerCodigoCostosResponseViewModel MaptoViewModelCodigoCostos(dynamic costos)
        {
            return new ObtenerCodigoCostosResponseViewModel()
            {

                idCentroCostos = costos.idCentroCostos,
                idAnio = costos.idAnio,
                idEjecutora = costos.idEjecutora,
                centroCostos = costos.centroCostos,
                descripcion = costos.descripcion,
                centroCostosPadre = costos.centroCostosPadre,
                idEstado = costos.idEstado,
                estado = costos.estado,
                estadoDescripcion = costos.estadoDescripcion,
                activo = costos.ativo
            };
        }


        public static CentroCostos MaptoEntity(AgregarCentroCostosViewModel request)
        {
            return new CentroCostos()
            {
                ID_ANIO = request.idAnio,
                ID_EJECUTORA = request.idEjecutora,
                CENTRO_COSTOS = request.centroCostos,
                DESCRIPCION = request.descripcion,
                CENTRO_COSTOS_PADRE = request.centroCostosPadre,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static CentroCostos MaptoEntity(ActualizarCentroCostosViewModel request)
        {
            return new CentroCostos()
            {
                ID_CENTRO_COSTOS = request.idCentroCostos,
                ID_ANIO = request.idAnio,
                ID_EJECUTORA = request.idEjecutora,
                CENTRO_COSTOS = request.centroCostos,
                DESCRIPCION = request.descripcion,
                CENTRO_COSTOS_PADRE = request.centroCostosPadre,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static CentroCostos MaptoEntity(EliminarCentroCostosViewModel request)
        {
            return new CentroCostos()
            {
                ID_CENTRO_COSTOS = request.idCentroCostos,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCentroCostosPaginadoResponseDTO MaptoDTO(CentroCostos item)
        {
            return new ObtenerCentroCostosPaginadoResponseDTO()
            {
                idCentroCostos = item.ID_CENTRO_COSTOS,
                idAnio = item.ID_ANIO,
                centroCostos = item.CENTRO_COSTOS,
                descripcion = item.DESCRIPCION,
                centroCostosPadre = item.CENTRO_COSTOS_PADRE,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }
        public static ObtenerCentroCostosPaginadoRequestDTO MaptoDTO(ObtenerCentroCostosPaginadoViewModel item)
        {
            return new ObtenerCentroCostosPaginadoRequestDTO()
            {
                anio = item.anio,
                centroCostos = item.centroCostos,
                descripcion = item.descripcion,
                centroCostosPadre = item.centroCostosPadre,
                //estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerCentroCostosRequestDTO MaptoDTO(ObtenerCentroCostosViewModel item)
        {
            return new ObtenerCentroCostosRequestDTO()
            {
                idCentroCostos = item.idCentroCostos
            };
        }

    }
}
