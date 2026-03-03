using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.DTO.ObjetivosInstitucionales;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Command;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries;
using Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Command;
using Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ObjetivosInstitucionalesMap
    {
        public static ObtenerObjetivosInstitucionalesPaginadoResponseDTO MaptoDTO(ObjetivosInstitucionaales item)
        {
            return new ObtenerObjetivosInstitucionalesPaginadoResponseDTO()
            {
                idObjetivos = item.ID_OBJETIVOS,
                idAnio = item.ID_ANIO,

                codigoObjetivos = item.CODIGO_OBJETIVOS,
                descripcionObjetivos = item.DESCRIPCION_OBJETIVOS,

                idAcciones = item.ID_ACCIONES,
                //codigoAcciones = item.CODIGO_ACCIONES,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerObjetivosInstitucionalesPaginadoRequestDTO MaptoDTO(ObtenerObjetivosInstitucionalesPaginadoViewModel item)
        {
            return new ObtenerObjetivosInstitucionalesPaginadoRequestDTO()
            {
                anio = item.anio,

                codigoObjetivos = item.codigoObjetivos,
                descripcionObjetivos = item.descripcionObjetivos,
                codigoAcciones = item.codigoAcciones,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerObjetivosInstitucionalesRequestDTO MaptoDTO(ObtenerObjetivosInstitucionalesViewModel item)
        {
            return new ObtenerObjetivosInstitucionalesRequestDTO()
            {
                idObjetivos = item.idObjetivos
            };
        }

        public static ObjetivosInstitucionaales MaptoEntity(AgregarObjetivosInstitucionalesViewModel request)
        {
            return new ObjetivosInstitucionaales()
            {
                ID_ANIO = request.idAnio,
                CODIGO_OBJETIVOS = request.codigoObjetivos,
                DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,

                ID_ACCIONES = request.idAcciones,
                //CODIGO_ACCIONES = request.codigoAcciones,
                //DESCRIPCION_ACCIONES = request.descripcionAcciones,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static ObjetivosInstitucionaales MaptoEntity(ActualizarObjetivosInstitucionalesViewModel request)
        {
            return new ObjetivosInstitucionaales()
            {
                ID_OBJETIVOS = request.idObjetivos,
                ID_ANIO = request.idAnio,
                CODIGO_OBJETIVOS = request.codigoObjetivos,
                DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,

                ID_ACCIONES = request.idAcciones,
                //CODIGO_ACCIONES = request.codigoAcciones,
                //DESCRIPCION_ACCIONES = request.descripcionAcciones,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static ObjetivosInstitucionaales MaptoEntity(EliminarObjetivosInstitucionalesViewModel request)
        {
            return new ObjetivosInstitucionaales()
            {
                ID_OBJETIVOS = request.idObjetivos,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoObjetivosInstitucionalesRequestDTO MaptoDTOCodigoObjetivos(ObtenerCodigoObjetivosInstitucionalesViewModel item)
        {
            return new ObtenerCodigoObjetivosInstitucionalesRequestDTO()
            {
                anio = item.anio,
                codigoObjetivos = item.codigoObjetivos
            };
        }


        public static ObtenerListadoObjetivosInstitucionalesResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoObjetivosInstitucionalesResponseViewModel()
            {
                idObjetivos = item.idObjetivos,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoObjetivos = item.codigoObjetivos,
                descripcionObjetivos = item.descripcionObjetivos,
                idAcciones = item.idAcciones,
                codigoAcciones = item.codigoAcciones,
                descripcionAcciones = item.descripcionAcciones,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoObjetivosInstitucionalesRequestDTO MaptoObjetivosInstitucionalesDTO(ObtenerListadoObjetivosInstitucionalesViewModel item)
        {
            return new ObtenerListadoObjetivosInstitucionalesRequestDTO()
            {
                idAnio = item.idAnio
            };
        }
    }
}
