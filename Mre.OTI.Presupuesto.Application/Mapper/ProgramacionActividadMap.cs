using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionActividad;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Command;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using Mre.OTI.Presupuesto.Domain.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProgramacionActividadMap
    {
        public static ProgramacionActividad MaptoEntity(AgregarProgramacionActividadViewModel request)
        {
            return new ProgramacionActividad()
            {
                ID_ANIO = request.idAnio,
                ANIO = request.anio,

                CODIGO_PROGRAMACION = request.codigoProgramacion,
                DENOMINACION = request.denominacion,
                DESCRIPCION = request.descripcion,
                OBJETIVO_PRIORITARIO = request.objetivoPrioritario,
                LINEAMIENTO = request.lineamiento,

                ID_POLITICAS = request.idPoliticas,
                ID_OBJETIVOS_ESTRATEGICOS = request.idObjetivosEstrategicas,
                ID_ACCIONES_ESTRATEGICOS = request.idAccionesEstrategicas,
                ID_OBJETIVOS_INSTITUCIONALES = request.idObjetivosInstitucionales,
                ID_ACCIONES_INSTITUCIONALES = request.idAccionesInstitucionales,
                ID_CATEGORIA_PRESUPUESTAL = request.idCategoriaPresupuestal,
                ID_PRODUCO_PROYECTO = request.idProductoProyecto,
                ID_FUNCION = request.idFuncion,
                ID_DIVISION_FUNCIONAL = request.idDivisionFuncional,
                ID_GRUPO_FUNCIONAL = request.idGrupoFuncional,
                ID_ACTIVIDAD_PRESUPUESTAL = request.idActividadPresupuestal,
                ID_FINALIDAD = request.idFinalidad,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                TIPO_UBIGEO = request.tipoUbigeo,
                UBIGEO = request.ubigeo,
                REGION = request.region,
                PAIS = request.pais,
                OSE = request.ose,
                ID_MONEDA = request.idMoneda,
                ACTIVIDAD_OPERATIVA = request.actividadOperativa,
                ACTIVIDAD_INVERSION = request.actividadInversion,
                ID_CENTRO_COSTOS = request.idCentroCostos,
                META_FISICA = request.metaFisica,
                META_FINANCIERA = request.metaFinanciera,

                OBSERVACION = request.observacion,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static ProgramacionActividad MaptoEntity(ActualizarProgramacionActividadViewModel request)
        {
            return new ProgramacionActividad()
            {
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_ANIO = request.idAnio,
                ANIO = request.anio,

                CODIGO_PROGRAMACION = request.codigoProgramacion,
                DENOMINACION = request.denominacion,
                DESCRIPCION = request.descripcion,
                OBJETIVO_PRIORITARIO = request.objetivoPrioritario,
                LINEAMIENTO = request.lineamiento,

                ID_POLITICAS = request.idPoliticas,
                ID_OBJETIVOS_ESTRATEGICOS = request.idObjetivosEstrategicas,
                ID_ACCIONES_ESTRATEGICOS = request.idAccionesEstrategicas,
                ID_OBJETIVOS_INSTITUCIONALES = request.idObjetivosInstitucionales,
                ID_ACCIONES_INSTITUCIONALES = request.idAccionesInstitucionales,
                ID_CATEGORIA_PRESUPUESTAL = request.idCategoriaPresupuestal,
                ID_PRODUCO_PROYECTO = request.idProductoProyecto,
                ID_FUNCION = request.idFuncion,
                ID_DIVISION_FUNCIONAL = request.idDivisionFuncional,
                ID_GRUPO_FUNCIONAL = request.idGrupoFuncional,
                ID_ACTIVIDAD_PRESUPUESTAL = request.idActividadPresupuestal,
                ID_FINALIDAD = request.idFinalidad,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                TIPO_UBIGEO = request.tipoUbigeo,
                UBIGEO = request.ubigeo,
                REGION = request.region,
                PAIS = request.pais,
                OSE = request.ose,
                ID_MONEDA = request.idMoneda,
                ACTIVIDAD_OPERATIVA = request.actividadOperativa,
                ACTIVIDAD_INVERSION = request.actividadInversion,
                ID_CENTRO_COSTOS = request.idCentroCostos,
                META_FISICA = request.metaFisica,
                META_FINANCIERA = request.metaFinanciera,

                OBSERVACION = request.observacion,

                ID_ESTADO = request.idEstado,

                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ProgramacionActividad MaptoEntity(ActualizarProgramacionActividadObservadoViewModel request)
        {
            return new ProgramacionActividad()
            {
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_ANIO = request.idAnio,
                
                CODIGO_PROGRAMACION = request.codigoProgramacion,
                
                OBSERVACION = request.observacion,

                ID_ESTADO = request.idEstado,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ProgramacionActividad MaptoEntity(ActualizarProgramacionActividadAprobacionesViewModel request)
        {
            return new ProgramacionActividad()
            {                
                ID_ANIO = request.idAnio,
                ID_CENTRO_COSTOS = request.idCentroCostos,

                ID_ESTADO = request.idEstado,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ProgramacionActividad MaptoEntity(EliminarProgramacionActividadViewModel request)
        {
            return new ProgramacionActividad()
            {
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerListadoProgramacionActividadResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoProgramacionActividadResponseViewModel()
            {
                idProgramacionActividad = item.idProgramacionActividad,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoProgramacion = item.codigoProgramacion,
                denominacion = item.denominacion,
                descripcion = item.descripcion,
                objetivoPrioritario = item.objetivoPrioritario,
                lineamiento = item.lineamiento,

                idPoliticas = item.idPoliticas,
                idObjetivosEstrategicas = item.idObjetivosEstrategicas,
                idAccionesEstrategicas = item.idAccionesEstrategicas,
                idObjetivosInstitucionales = item.idObjetivosInstitucionales,
                idAccionesInstitucionales = item.idAccionesInstitucionales,
                idCategoriaPresupuestal = item.idCategoriaPresupuestal,
                idProductoProyecto = item.idProductoProyecto,
                idFuncion = item.idFuncion,
                idDivisionFuncional = item.idDivisionFuncional,
                idGrupoFuncional = item.idGrupoFuncional,
                idActividadPresupuestal = item.idActividadPresupuestal,
                idFinalidad = item.idFinalidad,
                idUnidadMedida = item.idUnidadMedida,
                unidadMedidaDescripcion = item.unidadMedidaDescripcion,
                tipoUbigeo = item.tipoUbigeo,
                ubigeo = item.ubigeo,
                region = item.region,
                pais = item.pais,
                ose = item.ose,
                idMoneda = item.idMoneda,
                actividadOperativa = item.actividadOperativa,
                actividadInversion = item.actividadInversion,
                idCentroCostos = item.idCentroCostos,
                metaFisica = item.metaFisica,
                metaFinanciera = item.metaFinanciera,
                observacion = item.observacion,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,

                activo = item.activo
            };

        }

        public static ObtenerListadoProgramacionActividadRequestDTO MaptoProgramacionActividadDTO(ObtenerListadoProgramacionActividadViewModel item)
        {
            return new ObtenerListadoProgramacionActividadRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerProgramacionActividadPaginadoResponseDTO MaptoDTO(ProgramacionActividad item)
        {
            return new ObtenerProgramacionActividadPaginadoResponseDTO()
            {
                idProgramacionActividad = item.ID_PROGRAMACION_ACTIVIDAD,
                idAnio = item.ID_ANIO,
                anio = item.ANIO,

                codigoProgramacion = item.CODIGO_PROGRAMACION,
                denominacion = item.DENOMINACION,
                descripcion = item.DESCRIPCION,
                objetivoPrioritario = item.OBJETIVO_PRIORITARIO,
                lineamiento = item.LINEAMIENTO,

                idPoliticas = item.ID_POLITICAS,
                idObjetivosEstrategicas = item.ID_OBJETIVOS_ESTRATEGICOS,
                idAccionesEstrategicas = item.ID_ACCIONES_ESTRATEGICOS,
                idObjetivosInstitucionales = item.ID_OBJETIVOS_INSTITUCIONALES,
                idAccionesInstitucionales = item.ID_ACCIONES_INSTITUCIONALES,
                idCategoriaPresupuestal = item.ID_CATEGORIA_PRESUPUESTAL,
                idProductoProyecto = item.ID_PRODUCO_PROYECTO,
                idFuncion = item.ID_FUNCION,
                idDivisionFuncional = item.ID_DIVISION_FUNCIONAL,
                idGrupoFuncional = item.ID_GRUPO_FUNCIONAL,
                idActividadPresupuestal = item.ID_ACTIVIDAD_PRESUPUESTAL,
                idFinalidad = item.ID_FINALIDAD,
                idUnidadMedida = item.ID_UNIDAD_MEDIDA,

                tipoUbigeo = item.TIPO_UBIGEO,
                ubigeo = item.UBIGEO,
                region = item.REGION,
                pais = item.PAIS,
                ose = item.OSE,
                idMoneda = item.ID_MONEDA,
                actividadOperativa = item.ACTIVIDAD_OPERATIVA,
                actividadInversion = item.ACTIVIDAD_INVERSION,
                idCentroCostos = item.ID_CENTRO_COSTOS,
                metaFisica = item.META_FISICA,
                metaFinanciera = item.META_FINANCIERA,

                observacion = item.OBSERVACION,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerProgramacionActividadPaginadoRequestDTO MaptoDTO(ObtenerProgramacionActividadPaginadoViewModel item)
        {
            return new ObtenerProgramacionActividadPaginadoRequestDTO()
            {
                anio = item.anio,

                codigoProgramacion = item.codigoProgramacion,
                idCentroCostos = item.idCentroCostos,
                denominacion = item.denominacion,
                descripcion = item.descripcion,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerProgramacionActividadRequestDTO MaptoDTO(ObtenerProgramacionActividadViewModel item)
        {
            return new ObtenerProgramacionActividadRequestDTO()
            {
                idProgramacionActividad = item.idProgramacionActividad,
            };
        }

        public static ObtenerCodigoProgramacionActividadRequestDTO MaptoDTOCodigoProgramacionActividad(ObtenerCodigoProgramacionActividadViewModel item)
        {
            return new ObtenerCodigoProgramacionActividadRequestDTO()
            {
                anio = item.anio,
                codigoProgramacion = item.codigoProgramacion
            };
        }

        public static ObtenerProgramacionActividadAniosRequestDTO MaptoActividadAniosDTO(ObtenerProgramacionActividadAniosViewModel item)
        {
            return new ObtenerProgramacionActividadAniosRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerProgramacionActividadCentroCostosResponseViewModel MaptoCentroCostosViewModel(dynamic item)
        {
            return new ObtenerProgramacionActividadCentroCostosResponseViewModel()
            {
                idProgramacionActividad = item.idProgramacionActividad,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoProgramacion = item.codigoProgramacion,
                denominacion = item.denominacion,
                descripcion = item.descripcion,
                objetivoPrioritario = item.objetivoPrioritario,
                lineamiento = item.lineamiento,

                idPoliticas = item.idPoliticas,
                idObjetivosEstrategicas = item.idObjetivosEstrategicas,
                idAccionesEstrategicas = item.idAccionesEstrategicas,
                idObjetivosInstitucionales = item.idObjetivosInstitucionales,
                idAccionesInstitucionales = item.idAccionesInstitucionales,
                idCategoriaPresupuestal = item.idCategoriaPresupuestal,
                idProductoProyecto = item.idProductoProyecto,
                idFuncion = item.idFuncion,
                idDivisionFuncional = item.idDivisionFuncional,
                idGrupoFuncional = item.idGrupoFuncional,
                idActividadPresupuestal = item.idActividadPresupuestal,
                idFinalidad = item.idFinalidad,
                idUnidadMedida = item.idUnidadMedida,
                unidadMedidaDescripcion = item.unidadMedidaDescripcion,
                tipoUbigeo = item.tipoUbigeo,
                ubigeo = item.ubigeo,
                region = item.region,
                pais = item.pais,
                ose = item.ose,
                idMoneda = item.idMoneda,
                actividadOperativa = item.actividadOperativa,
                actividadInversion = item.actividadInversion,
                idCentroCostos = item.idCentroCostos,
                metaFisica = item.metaFisica,
                metaFinanciera = item.metaFinanciera,

                observacion = item.observacion,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,

                activo = item.activo
            };

        }

        public static ObtenerProgramacionActividadCentroCostosRequestDTO MaptoProgramacionActividadCentroCostoDTO(ObtenerProgramacionActividadCentroCostosViewModel item)
        {
            return new ObtenerProgramacionActividadCentroCostosRequestDTO()
            {
                anio = item.anio,
                idCentroCostos = item.idCentroCostos
            };
        }
    }
}
