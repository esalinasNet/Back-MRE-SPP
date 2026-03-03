using Mre.OTI.Presupuesto.Application.DTO.AccionesInstitucionales;
using Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Command;
using Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AccionesInstitucionales;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static iTextSharp.text.pdf.AcroFields;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class AccionesInstitucionalesMap
    {
        public static ObtenerAccionesInstitucionalesPaginadoResponseDTO MaptoDTO(AccionesInstitucionales item)
        {
            return new ObtenerAccionesInstitucionalesPaginadoResponseDTO()
            {
                idAcciones = item.ID_ACCIONES,
                idAnio = item.ID_ANIO,

                codigoAcciones = item.CODIGO_ACCONES,
                descripcionAcciones = item.DESCRIPCION_ACCIONES,

                codigoObjetivos = item.CODIGO_OBJETIVOS,
                descripcionObjetivos = item.DESCRIPCION_OBJETIVOS,

                nroCentroCostos = item.NRO_CENTRO_COSTOS,


                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }


        public static ObtenerAccionesInstitucionalesPaginadoRequestDTO MaptoDTO(ObtenerAccionesInstitucionalesPaginadoViewModel item)
        {
            return new ObtenerAccionesInstitucionalesPaginadoRequestDTO()
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

        public static ObtenerAccionesInstitucionalesRequestDTO MaptoDTO(ObtenerAccionesInstitucionalesViewModel item)
        {
            return new ObtenerAccionesInstitucionalesRequestDTO()
            {
                idAcciones = item.idAcciones
            };
        }

        public static AccionesInstitucionales MaptoEntity(AgregarAccionesInstitucionalesViewModel request)
        {
            return new AccionesInstitucionales()
            {
                ID_ANIO = request.idAnio,
                CODIGO_ACCONES = request.codigoAcciones,
                DESCRIPCION_ACCIONES = request.descripcionAcciones,

                CODIGO_OBJETIVOS = request.codigoObjetivos,
                DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,

                //NRO_CENTRO_COSTOS = request.nroCentroCostos,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static AccionesInstitucionales MaptoEntity(ActualizarAccionesInstitucionalesViewModel request)
        {
            return new AccionesInstitucionales()
            {
                ID_ACCIONES = request.idAcciones,
                ID_ANIO = request.idAnio,

                CODIGO_ACCONES = request.codigoAcciones,
                DESCRIPCION_ACCIONES = request.descripcionAcciones,

                CODIGO_OBJETIVOS = request.codigoObjetivos,
                DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,

                //NRO_CENTRO_COSTOS = request.nroCentroCostos,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static AccionesInstitucionales MaptoEntity(EliminarAccionesInstitucionalesViewModel request)
        {
            return new AccionesInstitucionales()
            {
                ID_ACCIONES = request.idAcciones,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static AccionesInstitucionales MaptoEntity(ActualizarAccionesAeiCentroCostosViewModel request)
        {
            return new AccionesInstitucionales()
            {
                ID_ACCIONES = request.idAcciones,
                ID_ANIO = request.idAnio,

                ID_CENTRO_COSTOS = request.idCentroCostos,
                NRO_CENTRO_COSTOS = request.nroCentroCostos,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

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

        public static ObtenerListadoAccionesInstitucionalesResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoAccionesInstitucionalesResponseViewModel()
            {
                idAcciones = item.idAcciones,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoAcciones = item.codigoAcciones,
                descripcionAcciones = item.descripcionAcciones,

                codigoObjetivos = item.codigoObjetivos,
                descripcionObjetivos = item.descripcionObjetivos,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };

        }

        public static ObtenerListadoAccionesInstitucionalesRequestDTO MaptoAccionesInstitucionalesDTO(ObtenerListadoAccionesInstitucionalesViewModel item)
        {
            return new ObtenerListadoAccionesInstitucionalesRequestDTO()
            {
                idAnio = item.idAnio
            };
        }
    }
}
