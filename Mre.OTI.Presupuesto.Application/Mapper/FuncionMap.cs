using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Command;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Features.Persona.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class FuncionMap
    {
        public static ObtenerListadoFuncionResponseViewModel MaptoViewModel(dynamic funcion)
        {
            return new ObtenerListadoFuncionResponseViewModel()
            {
                idFuncion = funcion.idFuncion,
                anio = funcion.anio,
                funcion = funcion.funcion,
                descripcion = funcion.descripcion,
                estado = funcion.estado
            };
        }

        public static ObtenerListadoFuncionRequestDTO MaptoFuncionDTO(ObtenerListadoFuncionViewModel item)
        {
            return new ObtenerListadoFuncionRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static Funcion MaptoEntity(AgregarFuncionViewModel request)
        {
            return new Funcion()
            {
                ID_ANIO = request.idAnio,
                FUNCION = request.funcion,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Funcion MaptoEntity(ActualizarFuncionViewModel request)
        {
            return new Funcion()
            {
                ID_FUNCION = request.idFuncion,
                ID_ANIO = request.idAnio,
                FUNCION = request.funcion,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Funcion MaptoEntity(EliminarFuncionViewModel request)
        {
            return new Funcion()
            {
                ID_FUNCION = request.idFuncion,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerFuncionPaginadoResponseDTO MaptoDTO(Funcion item)
        {
            return new ObtenerFuncionPaginadoResponseDTO()
            {
                idFuncion = item.ID_FUNCION,
                idAnio = item.ID_ANIO,
                funcion = item.FUNCION,
                descripcion = item.DESCRIPCION,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerFuncionPaginadoRequestDTO MaptoDTO(ObtenerFuncionPaginadoViewModel item)
        {
            return new ObtenerFuncionPaginadoRequestDTO()
            {
                Anio = item.anio,
                funcion = item.funcion,
                descripcion = item.descripcion,
                //estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }
    }
}
