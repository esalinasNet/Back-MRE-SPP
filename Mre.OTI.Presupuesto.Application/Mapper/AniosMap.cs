using Mre.OTI.Presupuesto.Application.DTO.Anio;
using Mre.OTI.Presupuesto.Application.Features.Anios.Command;
using Mre.OTI.Presupuesto.Application.Features.Anios.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class AniosMap
    {
        public static ObtenerListadoAniosResponseViewModel MaptoViewModel(dynamic anios)
        {
            return new ObtenerListadoAniosResponseViewModel()
            {
                idAnio = anios.id_Anio,
                anio = anios.anio,                
                descripcion = anios.descripcion,
                estado = anios.estado
            };
        }

        public static Anios MaptoEntity(AgregarAniosViewModel request)
        {
            return new Anios()
            {
                ID_ANIO = request.idAnio,
                ANIO = request.Anio,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Anios MaptoEntity(ActualizarAniosViewModel request)
        {
            return new Anios()
            {
                ID_ANIO = request.idAnio,
                ANIO = request.Anio,                
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Anios MaptoEntity(EliminarAniosViewModel request)
        {
            return new Anios()
            {
                ID_ANIO = request.idAnio,                
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static ObtenerAniosPaginadoResponseDTO MaptoDTO(Anios item)
        {
            return new ObtenerAniosPaginadoResponseDTO()
            {                
                idAnio = item.ID_ANIO,                
                descripcion = item.DESCRIPCION,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerAniosPaginadoRequestDTO MaptoDTO(ObtenerAniosPaginadoViewModel item)
        {
            return new ObtenerAniosPaginadoRequestDTO()
            {
                Anio = item.anio,                
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
