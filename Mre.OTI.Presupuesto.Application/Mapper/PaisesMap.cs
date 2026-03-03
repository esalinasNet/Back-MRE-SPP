using Mre.OTI.Presupuesto.Application.DTO.Paises;
using Mre.OTI.Presupuesto.Application.Features.Paises.Command;
using Mre.OTI.Presupuesto.Application.Features.Paises.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Paises;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class PaisesMap
    {
        public static ObtenerListadoPaisesResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoPaisesResponseViewModel()
            {
                idPaises = item.idPaises,
                codigo = item.codigo,
                nombre_pais = item.nombre_pais,
                continente = item.continente,
                estado = item.estado
            };

        }

        public static Paises MaptoEntity(AgregarPaisesViewModel request)
        {
            return new Paises()
            {
                CODIGO = request.codigo,
                NOMBRE_PAIS = request.nombre_pais,
                CONTINENTE = request.continente,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Paises MaptoEntity(ActualizarPaisesViewModel request)
        {
            return new Paises()
            {
                ID_PAISES = request.idPaises,                
                CODIGO = request.codigo,
                NOMBRE_PAIS = request.nombre_pais,
                CONTINENTE = request.continente,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static Paises MaptoEntity(EliminarPaisesViewModel request)
        {
            return new Paises()
            {
                ID_PAISES = request.idPaises,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerPaisesPaginadoResponseDTO MaptoDTO(Paises item)
        {
            return new ObtenerPaisesPaginadoResponseDTO()
            {
                idPaises = item.ID_PAISES,                
                codigo = item.CODIGO,
                nombre_pais = item.NOMBRE_PAIS,
                continente = item.CONTINENTE,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerPaisesPaginadoRequestDTO MaptoDTO(ObtenerPaisesPaginadoViewModel item)
        {
            return new ObtenerPaisesPaginadoRequestDTO()
            {
                codigo = item.codigo,
                nombre_pais = item.nombre_pais,
                continente = item.continente,
                //estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }
    }
}
