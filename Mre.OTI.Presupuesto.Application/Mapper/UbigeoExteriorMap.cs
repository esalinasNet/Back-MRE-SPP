using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.DTO.UbigeoExterior;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Command;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries;
using Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Command;
using Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class UbigeoExteriorMap
    {

        public static UbigeoExterior MaptoEntity(AgregarUbigeoExteriorViewModel request)
        {
            return new UbigeoExterior()
            {
                ZONE = request.zone,
                REGION = request.region,
                PAIS = request.pais,
                OSE_RES = request.oseRes,
                OSE = request.ose,
                TIPO_MISION = request.tipoMision,
                NOMBRE_OSE = request.nombreOse,
                MONEDA = request.moneda,
                MON = request.mon,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static UbigeoExterior MaptoEntity(ActualizarUbigeoExteriorViewModel request)
        {
            return new UbigeoExterior()
            {
                ID_UBIGEO_EXTERIOR = request.idUbigeoExterior,
                ZONE = request.zone,
                REGION = request.region,
                PAIS = request.pais,
                OSE_RES = request.oseRes,
                OSE = request.ose,
                TIPO_MISION = request.tipoMision,
                NOMBRE_OSE = request.nombreOse,
                MONEDA = request.moneda,
                MON = request.mon,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static UbigeoExterior MaptoEntity(EliminarUbigeoExteriorViewModel request)
        {
            return new UbigeoExterior()
            {
                ID_UBIGEO_EXTERIOR = request.idUbigeoExterior,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }
        public static ObtenerUbigeoExteriorPaginadoResponseDTO MaptoDTO(UbigeoExterior item)
        {
            return new ObtenerUbigeoExteriorPaginadoResponseDTO()
            {
                idUbigeoExterior = item.ID_UBIGEO_EXTERIOR,
                item = item.ITEM,
                zone = item.ZONE,
                region = item.REGION,
                pais = item.PAIS,
                oseRes = item.OSE_RES,
                tipoMision = item.TIPO_MISION,
                nombreOse = item.NOMBRE_OSE,
                moneda = item.MONEDA,
                mon = item.MON,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerUbigeoExteriorPaginadoRequestDTO MaptoDTO(ObtenerUbigeoExteriorPaginadoViewModel item)
        {
            return new ObtenerUbigeoExteriorPaginadoRequestDTO()
            {
                item = item.item,
                zone = item.zone,
                region = item.region,
                pais = item.pais,
                oseRes = item.oseRes,
                tipoMision = item.tipoMision,
                nombreOse = item.nombreOse,
                moneda = item.moneda,
                mon = item.mon,                
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerListadoUbigeoExteriorRegionResponseViewModel MaptoViewModelRegion(dynamic item)
        {
            return new ObtenerListadoUbigeoExteriorRegionResponseViewModel()
            {
                codigoRegion = item.codigoRegion,
                region = item.region
                
            };
        }

        public static ObtenerListadoUbigeoExteriorPaisRequestDTO MaptoExteriorPaisDTO(ObtenerListadoUbigeoExteriorPaisViewModel item)
        {
            return new ObtenerListadoUbigeoExteriorPaisRequestDTO()
            {
                codigoRegion = item.codigoRegion
            };
        }

        public static ObtenerListadoUbigeoExteriorPaisResponseViewModel MaptoViewModelExteriorPais(dynamic item)
        {
            return new ObtenerListadoUbigeoExteriorPaisResponseViewModel()
            {
                codigoPais = item.codigoPais,
                pais = item.pais
            };
        }

        public static ObtenerListadoUbigeoExteriorOseRequestDTO MaptoExteriorOseDTO(ObtenerListadoUbigeoExteriorOseViewModel item)
        {
            return new ObtenerListadoUbigeoExteriorOseRequestDTO()
            {
                codigoRegion = item.codigoRegion,
                codigoPais = item.codigoPais
            };
        }

        public static ObtenerListadoUbigeoExteriorOseResponseViewModel MaptoViewModelExteriorOse(dynamic item)
        {
            return new ObtenerListadoUbigeoExteriorOseResponseViewModel()
            {
                codigoOse = item.codigoOse,
                ciudad = item.ciudad
            };
        }

    }
}
