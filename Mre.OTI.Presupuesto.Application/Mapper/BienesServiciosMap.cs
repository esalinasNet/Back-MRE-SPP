using Mre.OTI.Presupuesto.Application.DTO.BienesServicios;
using Mre.OTI.Presupuesto.Application.Features.BienesServicios.Command;
using Mre.OTI.Presupuesto.Application.Features.BienesServicios.Queries;
using Mre.OTI.Presupuesto.Application.Responses.BienesServicios;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class BienesServiciosMap
    {
        public static ObtenerBienesServiciosPaginadoResponseDTO MaptoDTO(BienesServicios item)
        {
            return new ObtenerBienesServiciosPaginadoResponseDTO()
            {
                idBienesServicios = item.ID_BIENES_SERVICIOS,
                idAnio = item.ID_ANIO,
                codigoBien = item.ITEM_BIEN,
                nombreBien = item.DENOMINACION_ITEM,
                tipoItems = item.TIPO_ITEMS,

                idUnidadMedida = item.ID_UNIDADMEDIDA,

                precio = item.PRECIO,

                idClasificador = item.ID_CLASIFICADOR,
                //denominacionEegg = item.DENOMINACION_EEGG,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerBienesServiciosPaginadoRequestDTO MaptoDTO(ObtenerBienesServiciosPaginadoViewModel item)
        {
            return new ObtenerBienesServiciosPaginadoRequestDTO()
            {
                anio = item.anio,
                codigoBien = item.codigoBien,
                tipoItems = item.tipoItems,
                nombreBien =item.nombreBien,
                
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static BienesServicios MaptoEntity(AgregarBienesServiciosViewModel request)
        {
            return new BienesServicios()
            {
                ID_ANIO = request.idAnio,
                ITEM_BIEN = request.codigoBien,
                DENOMINACION_ITEM = request.nombreBien,
                TIPO_ITEMS = request.tipoItems,

                ID_UNIDADMEDIDA = request.idUnidadMedida,
                PRECIO = request.precio,
                ID_CLASIFICADOR = request.idClasificador,
                //DENOMINACION_EEGG = request.denominacionEegg,

                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static BienesServicios MaptoEntity(ActualizarBienesServiciosViewModel request)
        {
            return new BienesServicios()
            {
                ID_BIENES_SERVICIOS = request.idBienesServicios,
                ID_ANIO = request.idAnio,
                ITEM_BIEN = request.codigoBien,
                DENOMINACION_ITEM = request.nombreBien,
                TIPO_ITEMS = request.tipoItems,
                ID_UNIDADMEDIDA = request.idUnidadMedida,
                PRECIO = request.precio,
                ID_CLASIFICADOR = request.idClasificador,
                //DENOMINACION_EEGG = request.denominacionEegg,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static BienesServicios MaptoEntity(EliminarBienesServiciosViewModel request)
        {
            return new BienesServicios()
            {
                ID_BIENES_SERVICIOS = request.idBienesServicios,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerBienesServiciosRequestDTO MaptoDTO(ObtenerBienesServiciosViewModel item)
        {
            return new ObtenerBienesServiciosRequestDTO()
            {
                idBienesServicios = item.idBienesServicios
            };
        }

        public static ObtenerListadoBienesServiciosResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoBienesServiciosResponseViewModel()
            {
                idBienesServicios = item.idBienesServicios,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoBien = item.codigoBien,
                nombreBien = item.nombreBien,
                tipoItems = item.tipoItems,

                idUnidadMedida = item.idUnidadMedida,
                descripcionUinidadMedida = item.descripcionUinidadMedida,

                precio = item.precio,

                idClasificador = item.idClasificador,
                clasificadorGasto = item.clasificadorGasto,
                descripcionClasificador = item.descripcionClasificador,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoBienesServiciosRequestDTO MaptoBienesServiciosDTO(ObtenerListadoBienesServiciosViewModel item)
        {
            return new ObtenerListadoBienesServiciosRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerListadoBienesServiciosTipoItemsRequestDTO MaptoBienesServiciosTipoItemsDTO(ObtenerListadoBienesServiciosTipoItemsViewModel item)
        {
            return new ObtenerListadoBienesServiciosTipoItemsRequestDTO()
            {
                idAnio = item.idAnio,
                tipoItems = item.tipoItems,
                clasificadorGasto = item.clasificadorGasto
            };
        }

        public static ObtenerListadoBienesServiciosTipoItemsResponseViewModel MaptoViewModelTipoItems(dynamic item)
        {
            return new ObtenerListadoBienesServiciosTipoItemsResponseViewModel()
            {
                idBienesServicios = item.idBienesServicios,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoBien = item.codigoBien,
                nombreBien = item.nombreBien,
                tipoItems = item.tipoItems,

                idUnidadMedida = item.idUnidadMedida,
                descripcionUinidadMedida = item.descripcionUinidadMedida,

                precio = item.precio,

                idClasificador = item.idClasificador,
                clasificadorGasto = item.clasificadorGasto,
                descripcionClasificador = item.descripcionClasificador,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoGrupoBienesServiciosResponseViewModel MaptoGrupoViewModel(dynamic item)
        {
            return new ObtenerListadoGrupoBienesServiciosResponseViewModel()
            {
                idGrupo = item.idGrupo,
                idAnio = item.idAnio,
                anio = item.anio,

                tipoBien = item.tipoBien,
                grupoBien = item.grupoBien,
                nombreBien = item.nombreBien,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoGrupoBienesServiciosRequestDTO MaptoGrupoBienesServiciosDTO(ObtenerListadoGrupoBienesServiciosViewModel item)
        {
            return new ObtenerListadoGrupoBienesServiciosRequestDTO()
            {
                idAnio = item.idAnio,
                tipoBien = item.tipoBien
            };
        }

        public static ObtenerListadoBienesServiciosGrupoBienRequestDTO MaptoBienesServiciosGrupoBienDTO(ObtenerListadoBienesServiciosGrupoBienViewModel item)
        {
            return new ObtenerListadoBienesServiciosGrupoBienRequestDTO()
            {
                idAnio = item.idAnio,
                grupoBien = item.grupoBien
            };
        }

        public static ObtenerListadoBienesServiciosGrupoBienResponseViewModel MaptoGrupoBienViewModel(dynamic item)
        {
            return new ObtenerListadoBienesServiciosGrupoBienResponseViewModel()
            {
                idBienesServicios = item.idBienesServicios,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoBien = item.codigoBien,
                nombreBien = item.nombreBien,
                tipoItems = item.tipoItems,

                idUnidadMedida = item.idUnidadMedida,
                descripcionUinidadMedida = item.descripcionUinidadMedida,

                precio = item.precio,

                idClasificador = item.idClasificador,
                clasificadorGasto = item.clasificadorGasto,
                descripcionClasificador = item.descripcionClasificador,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }
    }
}
