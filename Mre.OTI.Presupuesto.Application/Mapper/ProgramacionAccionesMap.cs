using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Command;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static iTextSharp.text.pdf.AcroFields;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProgramacionAccionesMap
    {
        public static ObtenerProgramacionAccionesPaginadoResponseDTO MaptoDTO(ProgramacionAcciones item)
        {
            return new ObtenerProgramacionAccionesPaginadoResponseDTO()
            {
                idProgramacionAcciones = item.ID_PROGRAMACION_ACCIONES,
                idAnio = item.ID_ANIO,

                idProgramacionActividad = item.ID_PROGRAMACION_ACTIVIDAD,                
                idProgramacionTareas = item.ID_PROGRAMACION_TAREAS,

                codigoAcciones = item.CODIGO_ACCIONES,
                descripcionAcciones = item.DESCRIPCION_ACCIONES,
                                
                idUnidadMedida = item.ID_UNIDAD_MEDIDA,

                representativa = item.REPRESENTATIVA,
                acumulativa = item.ACUMULATIVA,
                                
                metaFisica = item.META_FISICA,
                enero = item.ENERO,
                febrero = item.FEBRERO,
                marzo = item.MARZO,
                abril = item.ABRIL,
                mayo = item.MARZO,
                junio = item.JUNIO,
                julio = item.JULIO,
                agosto = item.AGOSTO,
                setiembre = item.SETIEMBRE,
                octubre = item.OCTUBRE,
                noviembre = item.NOVIEMBRE,
                diciembre = item.DICIEMBRE,
                totalAnual = item.TOTAL_ANUAL,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerProgramacionAccionesPaginadoRequestDTO MaptoDTO(ObtenerProgramacionAccionesPaginadoViewModel item)
        {
            return new ObtenerProgramacionAccionesPaginadoRequestDTO()
            {
                anio = item.anio,

                idProgramacionActividad = item.idProgramacionActividad,
                idProgramacionTareas = item.idProgramacionTareas,

                codigoAcciones = item.codigoAcciones,
                //descripcionTareas = item.descripcionTareas,
                //descripcionUnidadMedida = item.descripcionUnidadMedida,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerProgramacionAccionesRequestDTO MaptoDTO(ObtenerProgramacionAccionesViewModel item)
        {
            return new ObtenerProgramacionAccionesRequestDTO()
            {
                idProgramacionAcciones = item.idProgramacionAcciones
            };
        }

        public static ProgramacionAcciones MaptoEntity(AgregarProgramacionAccionesViewModel request)
        {
            return new ProgramacionAcciones()
            {
                ID_ANIO = request.idAnio,
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,

                CODIGO_ACCIONES = request.codigoAcciones,
                DESCRIPCION_ACCIONES = request.descripcionAcciones,

                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ACUMULATIVA = request.acumulativa,
                                
                META_FISICA = request.metaFisica,
                ENERO = request.enero,
                FEBRERO = request.febrero,
                MARZO = request.marzo,
                ABRIL = request.abril,
                MAYO = request.mayo,
                JUNIO = request.junio,
                JULIO = request.julio,
                AGOSTO = request.agosto,
                SETIEMBRE = request.setiembre,
                OCTUBRE = request.octubre,
                NOVIEMBRE = request.noviembre,
                DICIEMBRE = request.diciembre,
                TOTAL_ANUAL = request.totalAnual,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static ProgramacionAcciones MaptoEntity(ActualizarProgramacionAccionesViewModel request)
        {
            return new ProgramacionAcciones()
            {
                ID_PROGRAMACION_ACCIONES = request.idProgramacionAcciones,
                ID_ANIO = request.idAnio,
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,

                CODIGO_ACCIONES = request.codigoAcciones,
                DESCRIPCION_ACCIONES = request.descripcionAcciones,

                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ACUMULATIVA = request.acumulativa,

                META_FISICA = request.metaFisica,
                ENERO = request.enero,
                FEBRERO = request.febrero,
                MARZO = request.marzo,
                ABRIL = request.abril,
                MAYO = request.mayo,
                JUNIO = request.junio,
                JULIO = request.julio,
                AGOSTO = request.agosto,
                SETIEMBRE = request.setiembre,
                OCTUBRE = request.octubre,
                NOVIEMBRE = request.noviembre,
                DICIEMBRE = request.diciembre,
                TOTAL_ANUAL = request.totalAnual,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ProgramacionAcciones MaptoEntity(EliminarProgramacionAccionesViewModel request)
        {
            return new ProgramacionAcciones()
            {
                ID_PROGRAMACION_ACCIONES = request.idProgramacionAcciones,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoProgramacionAccionesRequestDTO MaptoDTOCodigoProgramacionAcciones(ObtenerCodigoProgramacionAccionesViewModel item)
        {
            return new ObtenerCodigoProgramacionAccionesRequestDTO()
            {
                anio = item.anio,
                codigoAcciones = item.codigoAcciones
            };
        }

        public static ObtenerUnidadMedidaProgramacionAccionesRequestDTO MaptoDTOUnidadMedidaProgramacionAcciones(ObtenerUnidadMedidaProgramacionAccionesViewModel item)
        {
            return new ObtenerUnidadMedidaProgramacionAccionesRequestDTO()
            {
                idProgramacionTareas = item.idProgramacionTareas,
                idUnidadMedida = item.idUnidadMedida
            };
        }

        public static ObtenerListadoProgramacionAccionesResponseViewModel MaptoViewModelProgramacionAcciones(dynamic item)
        {
            return new ObtenerListadoProgramacionAccionesResponseViewModel()
            {
                idProgramacionAcciones = item.idProgramacionAcciones,
                idAnio = item.idAnio,
                anio = item.anio,

                idProgramacionActividad = item.idProgramacionActividad,
                codigoProgramacion = item.codigoProgramacion,

                idProgramacionTareas = item.idProgramacionTareas,
                codigoTareas = item.codigoTareas,

                codigoAcciones = item.codigoAcciones,
                descripcionAcciones = item.descripcionAcciones,
                                
                idUnidadMedida = item.idUnidadMedida,
                descripcionUnidadMedida = item.descripcionUnidadMedida,

                representativa = item.representativa,
                acumulativa = item.acumulativa,

                metaFisica = item.metaFisica,
                enero = item.enero,
                febrero = item.febrero,
                marzo = item.marzo,
                abril = item.abril,
                mayo = item.mayo,
                junio = item.junio,
                julio = item.julio,
                agosto = item.agosto,
                setiembre = item.setiembre,
                octubre = item.octubre,
                noviembre = item.noviembre,
                diciembre = item.diciembre,
                totalAnual = item.TOTAL_ANUAL,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoProgramacionAccionesRequestDTO MaptoProgramacionAccionesDTO(ObtenerListadoProgramacionAccionesViewModel item)
        {
            return new ObtenerListadoProgramacionAccionesRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerListadoProgramacionAccionesPorTareasRequestDTO MaptoProgramacionAccionesPorTareasDTO(ObtenerListadoProgramacionAccionesPorTareasViewModel item)
        {
            return new ObtenerListadoProgramacionAccionesPorTareasRequestDTO()
            {
                idAnio = item.idAnio,
                idProgramacionActividad = item.idProgramacionActividad,
                idProgramacionTareas = item.idProgramacionTareas
            };
        }

        public static ObtenerProgramacionTareasAccionesRequestDTO MaptoTareasAccionesDTO(ObtenerProgramacionTareasAccionesViewModel item)
        {
            return new ObtenerProgramacionTareasAccionesRequestDTO()
            {
                idProgramacionActividad = item.idProgramacionActividad,
                idProgramacionTareas = item.idProgramacionTareas
            };
        }

    }
}
