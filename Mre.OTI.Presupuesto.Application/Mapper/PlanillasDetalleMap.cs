using Mre.OTI.Presupuesto.Application.DTO.Planillas_Detalle;
using Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Command;
using Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Queries;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static iTextSharp.text.pdf.AcroFields;

namespace Mre.OTI.Presupuesto.Application.Mapper
{    
    public class PlanillasDetalleMap
    {
        public static ObtenerPlanillasDetallePaginadoResponseDTO MaptoDTO(PlanillasDetalle item)
        {
            return new ObtenerPlanillasDetallePaginadoResponseDTO()
            {
                idPlanillaDetalle = item.ID_PLANILLA_DETALLE,
                idPlanillas = item.ID_PLANILLA,

                idEspecifica = item.ID_ESPECIFICA,                

                //Periodo = item.PERIODO,

                Importe = item.IMPORTE,
                
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerPlanillasDetallePaginadoRequestDTO MaptoDTO(ObtenerPlanillasDetallePaginadoViewModel item)
        {
            return new ObtenerPlanillasDetallePaginadoRequestDTO()
            {
                idPlanillas = item.idPlanillas,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerPlanillasDetalleRequestDTO MaptoDTO(ObtenerPlanillasDetalleViewModel item)
        {
            return new ObtenerPlanillasDetalleRequestDTO()
            {
                idPlanillaDetalle = item.idPlanillaDetalle
            };
        }

        public static PlanillasDetalle MaptoEntity(AgregarPlanillasDetalleViewModel request)
        {
            return new PlanillasDetalle()
            {
                ID_PLANILLA_DETALLE = request.idPlanillaDetalle,
                ID_PLANILLA = request.idPlanillas,
                ID_ESPECIFICA = request.idEspecifica,

                //PERIODO = request.Periodo,

                IMPORTE = request.Importe,
                
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static PlanillasDetalle MaptoEntity(ActualizarPlanillasDetalleViewModel request)
        {
            return new PlanillasDetalle()
            {
                ID_PLANILLA_DETALLE = request.idPlanillaDetalle,
                ID_PLANILLA = request.idPlanillas,
                ID_ESPECIFICA = request.idEspecifica,

                //PERIODO = request.Periodo,

                IMPORTE = request.Importe,

                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static PlanillasDetalle MaptoEntity(EliminarPlanillasDetalleViewModel request)
        {
            return new PlanillasDetalle()
            {
                ID_PLANILLA_DETALLE = request.idPlanillaDetalle,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

       /* public static ObtenerCodigoPlanillasDetalleRequestDTO MaptoDTOCodigoPlanillasDetalle(ObtenerCodigoPlanillasDetalleViewModel item)
        {
            return new ObtenerCodigoPlanillasDetalleRequestDTO()
            {
                anio = item.anio,
                Mes = item.Mes,
                nroDocumento = item.nroDocumento
            };
        }*/

        /*public static ObtenerListadoPlanillasDetalleResponseViewModel MaptoViewModelPlanillasDetalle(dynamic item)
        {
            return new ObtenerListadoPlanillasDetalleResponseViewModel()
            {
                idPlanillasDetalle = item.idPlanillasDetalle,
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

                Meta = item.Meta,

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

        public static ObtenerListadoPlanillasDetalleRequestDTO MaptoPlanillasDetalleDTO(ObtenerListadoPlanillasDetalleViewModel item)
        {
            return new ObtenerListadoPlanillasDetalleRequestDTO()
            {
                idAnio = item.idAnio,
                idMes = item.idMes
            };
        }*/
    }
}
