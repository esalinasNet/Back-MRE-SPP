using Mre.OTI.Presupuesto.Application.DTO.Componente;
using Mre.OTI.Presupuesto.Application.Features.Componente.Command;
using Mre.OTI.Presupuesto.Application.Features.Componente.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ComponenteMap
    {
        public static ObtenerListadoComponenteResponseViewModel MaptoViewModel(dynamic response)
        {
            return new ObtenerListadoComponenteResponseViewModel()
            {
                idComponente = response.id_componente,
                anio = response.anio,
                componente = response.componente,
                tipoComponente = response.tipoComponente,
                descripcion = response.descripcion,
                estado = response.estado
            };
        }

        public static Componente MaptoEntity(AgregarComponenteViewModel request)
        {
            return new Componente()
            {
                ID_ANIO = request.idAnio,
                COMPONENTE = request.componente,
                TIPO_COMPONENTE = request.tipoComponente,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Componente MaptoEntity(ActualizarComponenteViewModel request)
        {
            return new Componente()
            {
                ID_COMPONENTE = request.idComponente,
                ID_ANIO = request.idAnio,
                COMPONENTE = request.componente,
                TIPO_COMPONENTE = request.tipoComponente,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Componente MaptoEntity(EliminarComponenteViewModel request)
        {
            return new Componente()
            {
                ID_COMPONENTE = request.idComponente,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static ObtenerComponentePaginadoResponseDTO MaptoDTO(Componente item)
        {
            return new ObtenerComponentePaginadoResponseDTO()
            {
                idComponente = item.ID_COMPONENTE,
                idAnio = item.ID_ANIO,
                componente = item.COMPONENTE,
                tipoComponente = item.TIPO_COMPONENTE,
                descripcion = item.DESCRIPCION,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerComponentePaginadoRequestDTO MaptoDTO(ObtenerComponentePaginadoViewModel item)
        {
            return new ObtenerComponentePaginadoRequestDTO()
            {
                Anio = item.anio,
                componente = item.componente,
                tipoComponente = item.tipoComponente,
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
