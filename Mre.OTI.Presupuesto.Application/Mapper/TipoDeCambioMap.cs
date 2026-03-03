using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Command;
using Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class TipoDeCambioMap
    {
        public static ObtenerListadoTipoDeCambioResponseViewModel MaptoViewModelTipoDeCambio(dynamic item)
        {
            return new ObtenerListadoTipoDeCambioResponseViewModel()
            {
                idMoneda = item.idMoneda,
                idAnio = item.idAnio,
                codigoIso = item.codigoIso,
                nombre = item.nombre,
                valor = item.valor,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo

            };
        }
        public static ObtenerListadoTipoDeCambioRequestDTO MaptoTipoDeCambioDTO(ObtenerListadoTipodeCambioViewModel item)
        {
            return new ObtenerListadoTipoDeCambioRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerTipoDeCambioMonedaResponseViewModel MaptoViewModelTipoDeCambioMoneda(dynamic item)
        {
            return new ObtenerTipoDeCambioMonedaResponseViewModel()
            {
                idMoneda = item.idMoneda,
                idAnio = item.idAnio,
                codigoIso = item.codigoIso,
                nombre = item.nombre,
                valor = item.valor,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerTipoDeCambioMonedaRequestDTO MaptoTipoDeCambioMonedaDTO(ObtenerTipodeCambioMonedaViewModel item)
        {
            return new ObtenerTipoDeCambioMonedaRequestDTO()
            {
                idAnio = item.idAnio,
                codigoIso = item.codigoIso                
            };
        }

        public static TipoDeCambio MaptoEntity(AgregarTipoDeCambioViewModel request)
        {
            return new TipoDeCambio()
            {
                //ID_MONEDA = request.idMoneda,
                ID_ANIO = request.idAnio,
                CODIGO_ISO = request.codigoIso,
                NOMBRE = request.nombre,
                VALOR = request.valor,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,

                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static TipoDeCambio MaptoEntity(ActualizarTipoDeCambioViewModel request)
        {
            return new TipoDeCambio()
            {
                ID_MONEDA = request.idMoneda,
                ID_ANIO = request.idAnio,
                CODIGO_ISO = request.codigoIso,
                NOMBRE = request.nombre,                                
                VALOR = request.valor,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static ObtenerTipoDeCambioRequestDTO MaptoDTO(ObtenerTipoDeCambioViewModel item)
        {
            return new ObtenerTipoDeCambioRequestDTO()
            {                
                idMoneda = item.idMoneda                
            };
        }

        public static ObtenerTipoDeCambioPaginadoResponseDTO MaptoDTO(TipoDeCambio item)
        {
            return new ObtenerTipoDeCambioPaginadoResponseDTO()
            {
                idMoneda = item.ID_MONEDA,          
                idAnio = item.ID_ANIO,
                codigoIso = item.CODIGO_ISO,
                nombre = item.NOMBRE,
                valor = item.VALOR,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerTipoDeCambioPaginadoRequestDTO MaptoDTO(ObtenerTipoDeCambioPaginadoViewModel item)
        {
            return new ObtenerTipoDeCambioPaginadoRequestDTO()
            {
                anio = item.anio,
                codigoIso = item.codigoIso,
                nombre = item.nombre,
                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        
    }
}
