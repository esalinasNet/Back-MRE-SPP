using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class AccionesMap
    {
        public static ObtenerAccionesPaginadoResponseDTO MaptoDTO(Acciones item)
        {
            return new ObtenerAccionesPaginadoResponseDTO()
            {
                idAcciones = item.ID_ACCIONES,
                idAnio = item.ID_ANIO,

                codigoAcciones = item.CODIGO_ACCIONES,
                descripcionAcciones = item.DESCRIPCION_ACCIONES,

                idObjetivos = item.ID_OBJETIVOS,
                //codigoObjetivos = item.CODIGO_OBJETIVOS,
                //descripcionObjetivos = item.DESCRIPCION_OBJETIVOS,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerAccionesPaginadoRequestDTO MaptoDTO(ObtenerAccionesPaginadoViewModel item)
        {
            return new ObtenerAccionesPaginadoRequestDTO()
            {
                anio = item.anio,

                codigoAcciones = item.codigoAcciones,
                descripcionAcciones = item.descripcionAcciones,

                codigoObjetivos = item.codigoObjetivos,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerAccionesRequestDTO MaptoDTO(ObtenerAccionesViewModel item)
        {
            return new ObtenerAccionesRequestDTO()
            {
                idAcciones = item.idAcciones
            };
        }

        public static Acciones MaptoEntity(AgregarAccionesViewModel request)
        {
            return new Acciones()
            {
                ID_ANIO = request.idAnio,
                CODIGO_ACCIONES = request.codigoAcciones,
                DESCRIPCION_ACCIONES = request.descripcionAcciones,

                ID_OBJETIVOS = request.idObjetivos,
                //CODIGO_OBJETIVOS = request.codigoObjetivos,
                //DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static Acciones MaptoEntity(ActualizarAccionesViewModel request)
        {
            return new Acciones()
            {
                ID_ACCIONES = request.idAcciones,
                ID_ANIO = request.idAnio,

                CODIGO_ACCIONES = request.codigoAcciones,
                DESCRIPCION_ACCIONES = request.descripcionAcciones,

                ID_OBJETIVOS = request.idObjetivos,
                //CODIGO_OBJETIVOS = request.codigoObjetivos,
                //DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static Acciones MaptoEntity(EliminarAccionesViewModel request)
        {
            return new Acciones()
            {
                ID_ACCIONES = request.idAcciones,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoAccionesRequestDTO MaptoDTOCodigoAcciones(ObtenerCodigoAccionesViewModel item)
        {
            return new ObtenerCodigoAccionesRequestDTO()
            {
                anio = item.anio,
                codigoAcciones = item.codigoAcciones
            };
        }

        public static ObtenerListadoAccionesResponseViewModel MaptoViewModelAcciones(dynamic item)
        {
            return new ObtenerListadoAccionesResponseViewModel()
            {
                idAcciones = item.idAcciones,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoAcciones = item.codigoAcciones,
                descripcionAcciones = item.descripcionAcciones,
                idObjetivos = item.idObjetivos,
                codigoObjetivos = item.codigoObjetivos,
                descripcionObjetivos = item.descripcionObjetivos,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoAccionesRequestDTO MaptoAccionesDTO(ObtenerListadoAccionesViewModel item)
        {
            return new ObtenerListadoAccionesRequestDTO()
            {
                idAnio = item.idAnio
            };
        }
    }
}
