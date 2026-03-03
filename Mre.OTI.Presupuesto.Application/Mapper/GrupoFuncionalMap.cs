using Mre.OTI.Presupuesto.Application.DTO.GrupoFuncional;
using Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Command;
using Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class GrupoFuncionalMap
    {
        public static GrupoFuncional MaptoEntity(AgregarGrupoFuncionalViewModel request)
        {
            return new GrupoFuncional()
            {
                ID_ANIO = request.idAnio,

                GRUPOFUNCIONAL = request.grupoFuncional,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static GrupoFuncional MaptoEntity(ActualizarGrupoFuncionalViewModel request)
        {
            return new GrupoFuncional()
            {
                ID_GRUPOFUNCIONAL = request.idGrupoFuncional,
                ID_ANIO = request.idAnio,

                GRUPOFUNCIONAL = request.grupoFuncional,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static GrupoFuncional MaptoEntity(EliminarGrupoFuncionalViewModel request)
        {
            return new GrupoFuncional()
            {
                ID_GRUPOFUNCIONAL = request.idGrupoFuncional,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerListadoGrupoFuncionalResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoGrupoFuncionalResponseViewModel()
            {
                idGrupoFuncional = item.idGrupoFuncional,
                idAnio = item.idAnio,
                anio = item.anio,

                grupoFuncional = item.grupoFuncional,
                descripcion = item.descripcion,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoGrupoFuncionalResquestDTO MaptoGrupoFuncionalDTO(ObtenerListadoGrupoFuncionalViewModel item)
        {
            return new ObtenerListadoGrupoFuncionalResquestDTO()
            {
                idAnio = item.idAnio
            };
        }


        public static ObtenerGrupoFuncionalPaginadoResponseDTO MaptoDTO(GrupoFuncional item)
        {
            return new ObtenerGrupoFuncionalPaginadoResponseDTO()
            {
                idGrupoFuncional = item.ID_GRUPOFUNCIONAL,
                idAnio = item.ID_ANIO,

                grupoFuncional = item.GRUPOFUNCIONAL,
                descripcion = item.DESCRIPCION,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerGrupoFuncionalPaginadoRequestDTO MaptoDTO(ObtenerGrupoFuncionalPaginadoViewModel item)
        {
            return new ObtenerGrupoFuncionalPaginadoRequestDTO()
            {
                anio = item.anio,

                grupoFuncional = item.grupoFuncional,
                descripcion = item.descripcion,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerGrupoFuncionalRequestDTO MaptoDTO(ObtenerGrupoFuncionalViewModel item)
        {
            return new ObtenerGrupoFuncionalRequestDTO()
            {
                idGrupoFuncional = item.idGrupoFuncional
            };
        }

        public static ObtenerCodigoGrupoFuncionalRequestDTO MaptoDTOCodigoGrupo(ObtenerCodigoGrupoFuncionalViewModel item)
        {
            return new ObtenerCodigoGrupoFuncionalRequestDTO()
            {
                anio = item.anio,
                grupoFuncional = item.grupoFuncional,
            };
        }

    }
}
