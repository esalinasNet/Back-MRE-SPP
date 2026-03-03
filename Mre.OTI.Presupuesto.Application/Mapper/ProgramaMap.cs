using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Programa;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Features.Programa.Command;
using Mre.OTI.Presupuesto.Application.Features.Programa.Queries;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Programa;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProgramaMap
    {
        public static ObtenerListadoProgramaResponseViewModel MaptoViewModel(dynamic programa)
        {
            return new ObtenerListadoProgramaResponseViewModel()
            {
                idPrograma = programa.idPrograma,
                anio = programa.anio,
                programa = programa.programa,
                descripcion = programa.descripcion,
                estado = programa.estado
            };
        }

        public static Programa MaptoEntity(AgregarProgramaViewModel request)
        {
            return new Programa()
            {
                ID_ANIO = request.idAnio,
                PROGRAMA = request.programa,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Programa MaptoEntity(ActualizarProgramaViewModel request)
        {
            return new Programa()
            {
                ID_PROGRAMA = request.idPrograma,
                ID_ANIO = request.idAnio,
                PROGRAMA = request.programa,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; 
        }

        public static Programa MaptoEntity(EliminarProgramaViewModel request)
        {
            return new Programa()
            {
                ID_PROGRAMA = request.idPrograma,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static ObtenerProgramaPaginadoResponseDTO MaptoDTO(Programa item)
        {
            return new ObtenerProgramaPaginadoResponseDTO()
            {
                idPrograma = item.ID_PROGRAMA,
                idAnio = item.ID_ANIO,
                programa = item.PROGRAMA,
                descripcion = item.DESCRIPCION,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerProgramaPaginadoRequestDTO MaptoDTO(ObtenerProgramaPaginadoViewModel item)
        {
            return new ObtenerProgramaPaginadoRequestDTO()
            {
                Anio = item.anio,
                programa = item.programa,
                descripcion = item.descripcion,
                //estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerListadoProgramaRequestDTO MaptoProgramaDTO(ObtenerListadoProgramaViewModel item)
        {
            return new ObtenerListadoProgramaRequestDTO()
            {
                idAnio = item.idAnio
            };
        }
    }
}
