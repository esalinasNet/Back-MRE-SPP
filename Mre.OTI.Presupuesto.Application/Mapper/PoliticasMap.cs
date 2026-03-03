using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Command;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Queries;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Command;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class PoliticasMap
    {
        public static ObtenerListadoPoliticasResponseViewModel MaptoViewModelPoliticas(dynamic item)
        {
            return new ObtenerListadoPoliticasResponseViewModel()
            {
                idPoliticas = item.idPoliticas,
                idAnio = item.idAnio,
                anio = item.anio,
                codigoPoliticas = item.codigoPoliticas,
                descripcionPoliticas = item.descripcionPoliticas,
                codigoObjetivo = item.codigoObjetivo,
                descripcionObjetivo = item.descripcionObjetivo,
                codigoLinemiento = item.codigoLinemiento,
                descripcionLineamiento = item.descripcionLineamiento,
                codigoServicio = item.codigoServicio,
                descripcionServicio = item.descripcionServicio,
                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };

        }

        public static ObtenerListadoPoliticasRequestDTO MaptoPoliticasDTO(ObtenerListadoPoliticasViewModel item)
        {
            return new ObtenerListadoPoliticasRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static Politicas MaptoEntity(AgregarPoliticasViewModel request)
        {
            return new Politicas()
            {
                ID_ANIO = request.idAnio,
                CODIGO_POLITICAS = request.codigoPoliticas,
                DESCRIPCION_POLITICAS = request.descripcionPoliticas,
                CODIGO_OBJETIVO = request.codigoObjetivo,
                DESCRIPCION_OBJETIVO = request.descripcionObjetivo,
                CODIGO_LINEAMIENTO = request.codigoLinemiento,
                DESCRIPCION_LINEAMIENTO = request.descripcionLineamiento,
                CODIGO_SERVICIO = request.codigoServicio,
                DESCRIPCION_SERVICIO = request.descripcionServicio,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }


        public static Politicas MaptoEntity(ActualizarPoliticasViewModel request)
        {
            return new Politicas()
            {
                ID_POLITICAS = request.idPoliticas,
                ID_ANIO = request.idAnio,
                CODIGO_POLITICAS = request.codigoPoliticas,
                DESCRIPCION_POLITICAS = request.descripcionPoliticas,
                CODIGO_OBJETIVO = request.codigoObjetivo,
                DESCRIPCION_OBJETIVO = request.descripcionObjetivo,
                CODIGO_LINEAMIENTO = request.codigoLinemiento,
                DESCRIPCION_LINEAMIENTO = request.descripcionLineamiento,
                CODIGO_SERVICIO = request.codigoServicio,
                DESCRIPCION_SERVICIO = request.descripcionServicio,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Politicas MaptoEntity(EliminarPoliticasViewModel request)
        {
            return new Politicas()
            {
                ID_POLITICAS = request.idPoliticas,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }


        public static ObtenerPoliticasPaginadoResponseDTO MaptoDTO(Politicas item)
        {
            return new ObtenerPoliticasPaginadoResponseDTO()
            {
                idPoliticas = item.ID_POLITICAS,
                idAnio = item.ID_ANIO,
                codigoPoliticas = item.CODIGO_POLITICAS,
                descripcionPoliticas = item.DESCRIPCION_POLITICAS,
                codigoObjetivo = item.CODIGO_OBJETIVO,
                descripcionObjetivo = item.DESCRIPCION_OBJETIVO,
                codigoLinemiento = item.CODIGO_LINEAMIENTO,
                descripcionLineamiento = item.DESCRIPCION_LINEAMIENTO,
                codigoServicio = item.CODIGO_SERVICIO,
                descripcionServicio = item.DESCRIPCION_SERVICIO,                
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerPoliticasPaginadoRequestDTO MaptoDTO(ObtenerPoliticasPaginadoViewModel item)
        {
            return new ObtenerPoliticasPaginadoRequestDTO()
            {
                anio = item.anio,
                codigoPoliticas = item.codigoPoliticas,
                descripcionObjetivo = item.descripcionObjetivo,                
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerPoliticasRequestDTO MaptoDTO(ObtenerPoliticasViewModel item)
        {
            return new ObtenerPoliticasRequestDTO()
            {
                idPoliticas = item.idPoliticas
            };
        }

        public static ObtenerCodigoPoliticasRequestDTO MaptoDTOCodigoPoliticas(ObtenerCodigoPoliticasViewModel item)
        {
            return new ObtenerCodigoPoliticasRequestDTO()
            {
                anio = item.anio,
                codigoPoliticas = item.codigoPoliticas
            };
        }
    }
}
