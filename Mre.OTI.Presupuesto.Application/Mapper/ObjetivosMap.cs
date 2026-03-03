using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Command;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Command;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Domain.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ObjetivosMap
    {
        public static ObtenerObjetivosPaginadoResponseDTO MaptoDTO(Objetivos item)
        {
            return new ObtenerObjetivosPaginadoResponseDTO()
            {
                idObjetivos = item.ID_OBJETIVOS,
                idAnio = item.ID_ANIO,

                codigoObjetivos = item.CODIGO_OBJETIVOS,
                descripcionObjetivos = item.DESCRIPCION_OBJETIVOS,

                idPoliticas = item.ID_POLITICAS,
                //codigoPrioritarios = item.CODIGO_PRIORITARIOS,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerObjetivosPaginadoRequestDTO MaptoDTO(ObtenerObjetivosPaginadoViewModel item)
        {
            return new ObtenerObjetivosPaginadoRequestDTO()
            {
                anio = item.anio,

                codigoObjetivos = item.codigoObjetivos,
                descripcionObjetivos = item.descripcionObjetivos,

                codigoPrioritarios = item.codigoPrioritarios,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerObjetivosRequestDTO MaptoDTO(ObtenerObjetivosViewModel item)
        {
            return new ObtenerObjetivosRequestDTO()
            {
                idObjetivos = item.idObjetivos
            };
        }

        public static Objetivos MaptoEntity(AgregarObjetivosViewModel request)
        {
            return new Objetivos()
            {
                ID_ANIO = request.idAnio,
                CODIGO_OBJETIVOS = request.codigoObjetivos,
                DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,

                ID_POLITICAS = request.idPoliticas,
                //CODIGO_PRIORITARIOS = request.codigoPrioritarios,
                //DESCRIPCION_PRIORITARIOS = request.descripcionPrioritarios,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static Objetivos MaptoEntity(ActualizarObjetivosViewModel request)
        {
            return new Objetivos()
            {
                ID_OBJETIVOS = request.idObjetivos,
                ID_ANIO = request.idAnio,
                CODIGO_OBJETIVOS = request.codigoObjetivos,
                DESCRIPCION_OBJETIVOS = request.descripcionObjetivos,
                ID_POLITICAS = request.idPoliticas,
                //CODIGO_PRIORITARIOS = request.codigoPrioritarios,
                //DESCRIPCION_PRIORITARIOS = request.descripcionPrioritarios,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Objetivos MaptoEntity(EliminarObjetivosViewModel request)
        {
            return new Objetivos()
            {
                ID_OBJETIVOS = request.idObjetivos,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoObjetivosRequestDTO MaptoDTOCodigoObjetivos(ObtenerCodigoObjetivosViewModel item)
        {
            return new ObtenerCodigoObjetivosRequestDTO()
            {
                anio = item.anio,
                codigoObjetivos = item.codigoObjetivos
            };
        }

        public static ObtenerListadoObjetivosResponseViewModel MaptoViewModelObjetivos(dynamic item)
        {
            return new ObtenerListadoObjetivosResponseViewModel()
            {
                idObjetivos = item.idObjetivos,
                idAnio = item.idAnio,
                anio = item.anio,

                codigoObjetivos = item.codigoObjetivos,
                descripcionObjetivos = item.descripcionObjetivos,
                idPoliticas = item.idPoliticas,
                codigoPrioritarios = item.codigoPrioritarios,
                descripcionPrioritarios = item.descripcionPrioritarios,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };

        }

        public static ObtenerListadoObjetivosRequestDTO MaptoObjetivosDTO(ObtenerListadoObjetivosViewModel item)
        {
            return new ObtenerListadoObjetivosRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

    }

}
