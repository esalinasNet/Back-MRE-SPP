using Mre.OTI.Presupuesto.Application.DTO.Planillas;
using Mre.OTI.Presupuesto.Application.Features.Planillas.Command;
using Mre.OTI.Presupuesto.Application.Features.Planillas.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{    
    public class PlanillasMap
    {
        public static ObtenerPlanillasPaginadoResponseDTO MaptoDTO(Planillas item)
        {
            return new ObtenerPlanillasPaginadoResponseDTO()
            {
                idPlanillas = item.ID_PLANILLA,
                idAnio = item.ID_ANIO,

                idMes = item.ID_MES,                

                idPrograma = item.ID_PROGRAMA,

                idProducto = item.ID_PRODUCTO,

                idActividad = item.ID_ACTIVIDAD,

                Meta = item.META,
                idFinalidad = item.ID_FINALIDAD,
                idCentroCostos = item.ID_CENTRO_COSTOS,
                tipoDocumento = item.TIPO_DOCUMENTO,
                nroDocumento = item.NRO_DOCUMENTO,
                apellidosNombres = item.APELLIDOSNOMBRES,
                
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerPlanillasPaginadoRequestDTO MaptoDTO(ObtenerPlanillasPaginadoViewModel item)
        {
            return new ObtenerPlanillasPaginadoRequestDTO()
            {
                anio = item.anio,

                nroDocumento = item.nroDocumento,
                apellidosNombres = item.apellidosNombres,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerPlanillasRequestDTO MaptoDTO(ObtenerPlanillasViewModel item)
        {
            return new ObtenerPlanillasRequestDTO()
            {
                idPlanillas = item.idPlanillas
            };
        }

        public static Planillas MaptoEntity(AgregarPlanillasViewModel request)
        {
            return new Planillas()
            {
                ID_ANIO = request.idAnio,
                ID_MES = request.idMes,
                ID_PROGRAMA = request.idPrograma,

                ID_PRODUCTO = request.idProducto,
                ID_ACTIVIDAD = request.idActividad,
                META = request.Meta,

                ID_FINALIDAD = request.idFinalidad,
                ID_CENTRO_COSTOS = request.idCentroCostos,
                TIPO_DOCUMENTO = request.tipoDocumento,
                NRO_DOCUMENTO = request.nroDocumento,
                APELLIDOSNOMBRES = request.apellidosNombres,                

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static Planillas MaptoEntity(ActualizarPlanillasViewModel request)
        {
            return new Planillas()
            {
                ID_PLANILLA = request.idPlanillas,
                ID_ANIO = request.idAnio,
                ID_MES = request.idMes,
                ID_PROGRAMA = request.idPrograma,

                ID_PRODUCTO = request.idProducto,
                ID_ACTIVIDAD = request.idActividad,
                META = request.Meta,

                ID_FINALIDAD = request.idFinalidad,
                ID_CENTRO_COSTOS = request.idCentroCostos,
                TIPO_DOCUMENTO = request.tipoDocumento,
                NRO_DOCUMENTO = request.nroDocumento,
                APELLIDOSNOMBRES = request.apellidosNombres,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static Planillas MaptoEntity(EliminarPlanillasViewModel request)
        {
            return new Planillas()
            {
                ID_PLANILLA = request.idPlanillas,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoPlanillasRequestDTO MaptoDTOCodigoPlanillas(ObtenerCodigoPlanillasViewModel item)
        {
            return new ObtenerCodigoPlanillasRequestDTO()
            {
                anio = item.anio,
                Mes = item.Mes,
                nroDocumento = item.nroDocumento
            };
        }

        public static ObtenerListadoPlanillasResponseViewModel MaptoViewModelPlanillas(dynamic item)
        {
            return new ObtenerListadoPlanillasResponseViewModel()
            {
                idPlanillas = item.idPlanillas,
                idAnio = item.idAnio,
                anio = item.anio,

                idMes = item.idMes,
                Mes = item.Mes,
                descripcionMes = item.descripcionMes,

                idPrograma = item.idPrograma,
                Programa = item.Programa,
                descripcionPrograma = item.descripcionPrograma,

                idProducto = item.idProducto,
                Producto = item.Producto,
                descripcionProducto = item.descripcionProducto,

                idActividad = item.idActividad,
                Actividad = item.Actividad,
                descripcionActividad = item.descripcionActividad,

                Meta = item.Meta ,

                idFinalidad = item.idFinalidad,
                Finalidad = item.Finalidad,
                descripcionFinalidad = item.descripcionFinalidad,

                idCentroCostos = item.idCentroCostos,
                CentroCostos = item.CentroCostos,
                descripcionCentroCostos = item.descripcionCentroCostos,

                tipoDocumento = item.tipoDocumento,
                nroDocumento = item.nroDocumento,
                apellidosNombres = item.apellidosNombres,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoPlanillasRequestDTO MaptoPlanillasDTO(ObtenerListadoPlanillasViewModel item)
        {
            return new ObtenerListadoPlanillasRequestDTO()
            {
                idAnio = item.idAnio,
                idMes = item.idMes
            };
        }
    }
}
