using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.FasesPoi;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Features.FasesPoi.Command;
using Mre.OTI.Presupuesto.Application.Features.FasesPoi.Queries;
using Mre.OTI.Presupuesto.Application.Responses.FasesPoi;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class FasesPoiMap
    {
        public static ObtenerFasesPoiPaginadoResponseDTO MaptoDTO(FasesPoi item)
        {
            return new ObtenerFasesPoiPaginadoResponseDTO()
            {
                idFasesPoi = item.ID_FASES_POI,
                idAnio = item.ID_ANIO,

                codigoFases = item.CODIGO_FASES,
                descripcionFases = item.DESCRIPCION_FASES,

                anioInicial = item.ANIO_INICIAL,
                anioFinal = item.ANIO_FINAL,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerFasesPoiPaginadoRequestDTO MaptoDTO(ObtenerFasesPoiPaginadoViewModel item)
        {
            return new ObtenerFasesPoiPaginadoRequestDTO()
            {
                anio = item.anio,

                codigoFases = item.codigoFases,
                descripcionFases = item.descripcionFases,

                anioInicial = item.anioInicial,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerFasesPoiRequestDTO MaptoDTO(ObtenerFasesPoiViewModel item)
        {
            return new ObtenerFasesPoiRequestDTO()
            {
                idFasesPoi = item.idFasesPoi
            };
        }

        public static FasesPoi MaptoEntity(AgregarFasesPoiViewModel request)
        {
            return new FasesPoi()
            {
                ID_ANIO = request.idAnio,
                CODIGO_FASES = request.codigoFases,
                DESCRIPCION_FASES = request.descripcionFases,

                ANIO_INICIAL = request.anioInicial,
                ANIO_FINAL = request.anioFinal,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static FasesPoi MaptoEntity(ActualizarFasesPoiViewModel request)
        {
            return new FasesPoi()
            {
                ID_FASES_POI = request.idFasesPoi,
                ID_ANIO = request.idAnio,

                CODIGO_FASES = request.codigoFases,
                DESCRIPCION_FASES = request.descripcionFases,

                ANIO_INICIAL = request.anioInicial,
                ANIO_FINAL = request.anioFinal,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static FasesPoi MaptoEntity(EliminarFasesPoiViewModel request)
        {
            return new FasesPoi()
            {
                ID_FASES_POI = request.idFasesPoi,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerListadoFasesPoiResponseViewModel MaptoViewModelFasesPoi(dynamic item)
        {
            return new ObtenerListadoFasesPoiResponseViewModel()
            {
                idFasesPoi = item.idFasesPoi,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoFases = item.codigoFases,
                descripcionFases = item.descripcionFases,
                anioInicial = item.anioInicial,
                anioFinal = item.anioFinal,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoFasesPoiRequestDTO MaptoFasesPoiDTO(ObtenerListadoFasesPoiViewModel item)
        {
            return new ObtenerListadoFasesPoiRequestDTO()
            {
                idAnio = item.idAnio
            };
        }
    }
}
