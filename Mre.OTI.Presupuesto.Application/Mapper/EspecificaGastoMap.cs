using Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Command;
using Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Command;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class EspecificaGastoMap
    {
        public static ObtenerListadoEspecificaGastoResponseViewModel MaptoViewModel(dynamic especifica)
        {
            return new ObtenerListadoEspecificaGastoResponseViewModel()
            {
                idClasificador = especifica.idClasificador,
                idAnio = especifica.idAnio,
                anio = especifica.anio,
                clasificador = especifica.clasificador,
                descripcion = especifica.descripcion,
                descripcion_detallada = especifica.descripcion_detallada,
                idEstado = especifica.idEstado,
                estado = especifica.estado,
                estadoDescripcion = especifica.estadoDescripcion,
                idCategoriaGasto = especifica.idCategoriaGasto,
                tipoClasificador = especifica.tipoClasificador
            };
        }

        public static ObtenerListadoEspecificaGastoGenericaResponseViewModel MaptoViewModelGenerica(dynamic especifica)
        {
            return new ObtenerListadoEspecificaGastoGenericaResponseViewModel()
            {
                idClasificador = especifica.idClasificador,
                idAnio = especifica.idAnio,
                anio = especifica.anio,
                clasificador = especifica.clasificador,
                descripcion = especifica.descripcion,
                descripcion_detallada = especifica.descripcion_detallada,
                idEstado = especifica.idEstado,
                estado = especifica.estado,
                estadoDescripcion = especifica.estadoDescripcion,
                idCategoriaGasto = especifica.idCategoriaGasto,
                tipoClasificador = especifica.tipoClasificador
            };
        }

        public static ObtenerEspecificaGastoResponseViewModel MaptoViewModelObtener(dynamic especifica)
        {
            return new ObtenerEspecificaGastoResponseViewModel()            {

                idClasificador = especifica.idClasificador,
                idAnio = especifica.idAnio,
                anio = especifica.anio,
                clasificador = especifica.clasificador,
                descripcion = especifica.descripcion,
                descripcion_detallada = especifica.descripcion_detallada,
                idEstado = especifica.idEstado,
                estado = especifica.estado,
                estadoDescripcion = especifica.estadoDescripcion,
                idCategoriaGasto = especifica.idCategoriaGasto,
                tipoClasificador = especifica.tipoClasificador
            };
        }

        public static ObtenerClasificadorResponseViewModel MaptoViewModelClasificador(dynamic especifica)
        {
            return new ObtenerClasificadorResponseViewModel()
            {

                idClasificador = especifica.idClasificador,
                idAnio = especifica.idAnio,
                anio = especifica.anio,
                clasificador = especifica.clasificador,
                descripcion = especifica.descripcion,
                descripcion_detallada = especifica.descripcion_detallada,
                idEstado = especifica.idEstado,
                estado = especifica.estado,
                estadoDescripcion = especifica.estadoDescripcion,
                idCategoriaGasto = especifica.idCategoriaGasto,
                tipoClasificador = especifica.tipoClasificador
            };
        }

        public static EspecificaGasto MaptoEntity(AgregarEspecificaGastoViewModel request)
        {
            return new EspecificaGasto()
            {
                ID_ANIO = request.idAnio,
                CLASIFICADOR = request.clasificador,
                DESCRIPCION = request.descripcion,
                DESCRIPCION_DETALLADA = request.descripcion_detallada,
                ID_ESTADO = request.idEstado,
                ID_CATEGORIA_GASTO = request.idCategoria_gasto,
                TIPO_CLASIFICADOR = request.tipo_clasificador,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; 
        }

        public static EspecificaGasto MaptoEntity(ActualizarEspecificaGastoViewModel request)
        {
            return new EspecificaGasto()
            {
                ID_CLASIFICADOR = request.idClasificador,
                ID_ANIO = request.idAnio,
                CLASIFICADOR = request.clasificador,
                DESCRIPCION = request.descripcion,
                DESCRIPCION_DETALLADA = request.descripcion_detallada,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ID_CATEGORIA_GASTO = request.idCategoria_gasto,
                TIPO_CLASIFICADOR = request.tipo_clasificador,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; 
        }

        public static EspecificaGasto MaptoEntity(EliminarEspecificaGastoViewModel request)
        {
            return new EspecificaGasto()
            {
                ID_CLASIFICADOR = request.idClasificador,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerEspecificaGastoPaginadoResponseDTO MaptoDTO(EspecificaGasto item)
        {
            return new ObtenerEspecificaGastoPaginadoResponseDTO()
            {
                idClasificador = item.ID_CLASIFICADOR,
                idAnio = item.ID_ANIO,                
                clasificador = item.CLASIFICADOR,                
                descripcion = item.DESCRIPCION,
                descripcion_detallada = item.DESCRIPCION_DETALLADA,
                idEstado = item.ID_ESTADO,
                activo = item.ACTIVO,
                idCategoriaGasto = item.ID_CATEGORIA_GASTO,
                tipoClasificador = item.TIPO_CLASIFICADOR,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerEspecificaGastoPaginadoRequestDTO MaptoDTO(ObtenerEspecificaGastoPaginadoViewModel item)
        {
            return new ObtenerEspecificaGastoPaginadoRequestDTO()
            {
                anio = item.anio,
                clasificador = item.clasificador,
                descripcion = item.descripcion,                
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }


        public static ObtenerListadoEspecificaGastoRequestDTO MaptoProgramacionEspecificaDTO(ObtenerListadoEspecificaGastoViewModel item)
        {
            return new ObtenerListadoEspecificaGastoRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerListadoEspecificaGastoGenericaRequestDTO MaptoProgramacionEspecificaGenericaDTO(ObtenerListadoEspecificaGastoGenericaViewModel item)
        {
            return new ObtenerListadoEspecificaGastoGenericaRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

    }
}
