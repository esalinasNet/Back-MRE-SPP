using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Command;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Command;
using Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Queries;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Command;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class DivisionFuncionalMap
    {
        public static DivisionFuncional MaptoEntity(AgregarDivisionFuncionalViewModel request)
        {
            return new DivisionFuncional()
            {
                ID_ANIO = request.idAnio,

                DIVISIONFUNCIONAL = request.divisionFuncional,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static DivisionFuncional MaptoEntity(ActualizarDivisionFuncionalViewModel request)
        {
            return new DivisionFuncional()
            {
                ID_DIVISIONFUNCIONAL = request.idDivisionFuncional,
                ID_ANIO = request.idAnio,

                DIVISIONFUNCIONAL = request.divisionFuncional,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static DivisionFuncional MaptoEntity(EliminarDivisionFuncionalViewModel request)
        {
            return new DivisionFuncional()
            {
                ID_DIVISIONFUNCIONAL = request.idDivisionFuncional,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoDivisionRequestDTO MaptoDTOCodigoDivision(ObtenerCodigoDivisionViewModel item)
        {
            return new ObtenerCodigoDivisionRequestDTO()
            {
                anio = item.anio,
                divisionFuncional = item.divisionFuncional
            };
        }


        public static ObtenerDivisionFuncionalPaginadoResponseDTO MaptoDTO(DivisionFuncional item)
        {
            return new ObtenerDivisionFuncionalPaginadoResponseDTO()
            {
                idDivisionFuncional = item.ID_DIVISIONFUNCIONAL,
                idAnio = item.ID_ANIO,

                divisionFuncional = item.DIVISIONFUNCIONAL,
                descripcion = item.DESCRIPCION,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerDivisionFuncionalPaginadoRequestDTO MaptoDTO(ObtenerDivisionFuncionalPaginadoViewModel item)
        {
            return new ObtenerDivisionFuncionalPaginadoRequestDTO()
            {
                anio = item.anio,

                divisionFuncional = item.divisionFuncional,
                descripcion = item.descripcion,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }


        public static ObtenerListadoDivisionFuncionalResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoDivisionFuncionalResponseViewModel()
            {
                idDivisionFuncional = item.idDivisionFuncional,
                idAnio = item.idAnio,
                anio = item.anio,

                divisionFuncional = item.divisionFuncional,
                descripcion = item.descripcion,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoDivisionFuncionalRequestDTO MaptoDivisionFuncionalDTO(ObtenerListadoDivisionFuncionalViewModel item)
        {
            return new ObtenerListadoDivisionFuncionalRequestDTO()
            {
                idAnio = item.idAnio
            };
        }


        public static ObtenerDivisionFuncionalRequestDTO MaptoDTO(ObtenerDivisionFuncionalViewModel item)
        {
            return new ObtenerDivisionFuncionalRequestDTO()
            {
                idDivisionFuncional = item.idDivisionFuncional
            };
        }
    }
}
