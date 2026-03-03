using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.CategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Command;
using Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Command;
using Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.CategoriaPresupuestal;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class CategoriaPresupuestalMap
    {
        public static ObtenerCategoriaPresupuestalPaginadoResponseDTO MaptoDTO(CategoriaPresupuestal item)
        {
            return new ObtenerCategoriaPresupuestalPaginadoResponseDTO()
            {
                idPresupuestal = item.ID_PRESUPUESTAL,
                idAnio = item.ID_ANIO,

                codigoPresupuestal = item.CODIGO_PRESUPUESTAL,
                descripcionPresupuestal = item.DESCRIPCION_PRESUPUESTAL,

                //idAcciones = item.ID_ACCIONES,

                nroCodigoAcciones = item.NRO_CODIGO_ACCIONES,

                idEstado = item.ID_ESTADO,

                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerCategoriaPresupuestalPaginadoRequestDTO MaptoDTO(ObtenerCategoriaPresupuestalPaginadoViewModel item)
        {
            return new ObtenerCategoriaPresupuestalPaginadoRequestDTO()
            {
                anio = item.anio,

                codigoPresupuestal = item.codigoPresupuestal,
                descripcionPresupuestal = item.descripcionPresupuestal,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerCategoriaPresupuestalRequestDTO MaptoDTO(ObtenerCategoriaPresupuestalViewModel item)
        {
            return new ObtenerCategoriaPresupuestalRequestDTO()
            {
                idPresupuestal = item.idPresupuestal
            };
        }


        public static CategoriaPresupuestal MaptoEntity(AgregarCategoriaPresupuestalViewModel request)
        {
            return new CategoriaPresupuestal()
            {
                ID_ANIO = request.idAnio,
                CODIGO_PRESUPUESTAL = request.codigoPresupuestal,
                DESCRIPCION_PRESUPUESTAL = request.descripcionPresupuestal,

                //ID_ACCIONES = request.idAcciones,
                NRO_CODIGO_ACCIONES = request.nroCodigoAcciones,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static CategoriaPresupuestal MaptoEntity(ActualizarCategoriaPresupuestalViewModel request)
        {
            return new CategoriaPresupuestal()
            {
                ID_PRESUPUESTAL = request.idPresupuestal,
                ID_ANIO = request.idAnio,

                CODIGO_PRESUPUESTAL = request.codigoPresupuestal,
                DESCRIPCION_PRESUPUESTAL = request.descripcionPresupuestal,

                //ID_ACCIONES = request.idAcciones,
                NRO_CODIGO_ACCIONES = request.nroCodigoAcciones,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static CategoriaPresupuestal MaptoEntity(ActualizarAeiCategoriaPresupuestalViewModel request)
        {
            return new CategoriaPresupuestal()
            {
                ID_PRESUPUESTAL = request.idPresupuestal,
                ID_ANIO = request.idAnio,

                CODIGO_PRESUPUESTAL = request.codigoPresupuestal,
                DESCRIPCION_PRESUPUESTAL = request.descripcionPresupuestal,

                ID_ACCIONES = request.idAcciones,

                NRO_CODIGO_ACCIONES = request.nroCodigoAcciones,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoPresupuestalRequestDTO MaptoDTOCodigoPresupuestal(ObtenerCodigoPresupuestalViewModel item)
        {
            return new ObtenerCodigoPresupuestalRequestDTO()
            {
                anio = item.anio,
                codigoPresupuestal = item.codigoPresupuestal
            };
        }

        public static ObtenerListadoCategoriaPresupuestalResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoCategoriaPresupuestalResponseViewModel()
            {
                idPresupuestal = item.idPresupuestal,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoPresupuestal = item.codigoPresupuestal,
                descripcionPresupuestal = item.descripcionPresupuestal,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoCategoriaPresupuestalRequestDTO MaptoCategoriaPresupuestalDTO(ObtenerListadoCategoriaPresupuestalViewModel item)
        {
            return new ObtenerListadoCategoriaPresupuestalRequestDTO()
            {
                idAnio = item.idAnio
            };
        }
    }
}
