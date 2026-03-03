using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Command;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Command;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class AeiCentroCostosMap
    {
        public static ObtenerAeiCentroCostosPaginadoResponseDTO MaptoDTO(AeiCentroCostos item)
        {
            return new ObtenerAeiCentroCostosPaginadoResponseDTO()
            {
                idAeiCostos = item.ID_AEI_COSTOS,
                idAnio = item.ID_ANIO,

                idAcciones = item.ID_ACCIONES,

                idCentroCostos = item.ID_CENTRO_COSTOS,
                
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerAeiCentroCostosPaginadoRequestDTO MaptoDTO(ObtenerAeiCentroCostosPaginadoViewModel item)
        {
            return new ObtenerAeiCentroCostosPaginadoRequestDTO()
            {
                idAnio = item.idAnio,
                idAcciones = item.idAcciones,
                codigoAcciones = item.codigoAcciones,
                descripcionAcciones = item.descripcionAcciones,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static EliminaAeiCentroCostosRequestDTO MaptoDTO(EliminaAeiCentroCostosViewModel item)
        {
            return new EliminaAeiCentroCostosRequestDTO()
            {
                idAcciones = item.idAcciones
            };
        }

        public static AeiCentroCostos MaptoEntity(EliminarAeiCentroCostosViewModel request)
        {
            return new AeiCentroCostos()
            {
                ID_ANIO = request.idAnio,
                ID_ACCIONES = request.idAcciones,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerAeiCentroCostosRequestDTO MaptoCCDTO(ObtenerAeiCentroCostosViewModel item)
        {
            return new ObtenerAeiCentroCostosRequestDTO()
            {
                idAnio = item.idAnio,
                idAcciones = item.idAcciones
            };
        }

        public static ObtenerAeiCentroCostosResponseViewModel MaptoViewModelAeiCostos(dynamic item)
        {
            return new ObtenerAeiCentroCostosResponseViewModel()
            {
                idAeiCostos = item.idAeiCostos,
                idAnio = item.idAnio,
                idAcciones = item.idAcciones,                
                idCentroCostos = item.idCentroCostos,
                activo = item.activo
            };
        }

        public static AeiCentroCostos MaptoEntity(AgregarAeiCentroCostosViewModel request)
        {
            return new AeiCentroCostos()
            {
                ID_ANIO = request.idAnio,
                ID_ACCIONES = request.idAcciones,

                ID_CENTRO_COSTOS = request.idCentroCostos,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }
    }
}
