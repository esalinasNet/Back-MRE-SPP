using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Command;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Command;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries;
using Mre.OTI.Presupuesto.Application.Features.Usuario.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class UbigeoMap
    {
        public static ObtenerListadoUbigeoDepartamentoResponseViewModel MaptoViewModelDepartamento(dynamic item)
        {
            return new ObtenerListadoUbigeoDepartamentoResponseViewModel()
            {
                idUbigeo = item.idUbigeo,
                ubigeo = item.ubigeo,
                departamento = item.departamento,
                descripcion = item.descripcion,
                estado = item.estado
            };
        }

        public static ObtenerListadoUbigeoProvinciaResponseViewModel MaptoViewModelProvincia(dynamic item)
        {
            return new ObtenerListadoUbigeoProvinciaResponseViewModel()
            {
                idUbigeo = item.idUbigeo,
                ubigeo = item.ubigeo,
                provincia = item.provincia,
                descripcion = item.descripcion,
                estado = item.estado
            };
        }

        public static ObtenerListadoUbigeoProvinciaRequestDTO MaptoProvinciaDTO(ObtenerListadoUbigeoProvinciaViewModel item)
        {
            return new ObtenerListadoUbigeoProvinciaRequestDTO()
            {
                departamento = item.departamento
            };
        }

        public static ObtenerListadoUbigeoDistritoResponseViewModel MaptoViewModelDistrito(dynamic item)
        {
            return new ObtenerListadoUbigeoDistritoResponseViewModel()
            {
                idUbigeo = item.idUbigeo,
                ubigeo = item.ubigeo,
                distrito = item.distrito,
                descripcion = item.descripcion,
                estado = item.estado
            };
        }

        public static ObtenerListadoUbigeoDistritoRequestDTO MaptoDistritoDTO(ObtenerListadoUbigeoDistritoViewModel item)
        {
            return new ObtenerListadoUbigeoDistritoRequestDTO()
            {
                departamento = item.departamento,
                provincia = item.provincia
            };
        }

        public static Ubigeo MaptoEntityDepartamento(AgregarUbigeoDepartamentoViewModel request)
        {
            return new Ubigeo()
            {
                
                DESCRIPCION = request.descripcion,                
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Ubigeo MaptoEntityProvincia(AgregarUbigeoProvinciaViewModel request)
        {
            return new Ubigeo()
            {
                DEPARTAMENTO = request.departamento,
                DESCRIPCION = request.descripcion,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static Ubigeo MaptoEntityDistrito(AgregarUbigeoDistritoViewModel request)
        {
            return new Ubigeo()
            {
                DEPARTAMENTO = request.departamento,
                PROVINCIA = request.provincia,
                DESCRIPCION = request.descripcion,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; 
        }

        public static ObtenerDepartamentoRequestDTO MaptoDTO(ObtenerDepartamentoViewModel item)
        {
            return new ObtenerDepartamentoRequestDTO()
            {
                //idUbigeo = item.idUbigeo
                ubigeo = item.ubigeo
            };
        }

        public static ObtenerProvinciaRequestDTO MaptoDTO(ObtenerProvinciaViewModel item)
        {
            return new ObtenerProvinciaRequestDTO()
            {
                //idUbigeo = item.idUbigeo
                ubigeo = item.ubigeo
            };
        }

        public static ObtenerDistritoRequestDTO MaptoDTO(ObtenerDistritoViewModel item)
        {
            return new ObtenerDistritoRequestDTO()
            {
                //idUbigeo = item.idUbigeo
                ubigeo = item.ubigeo
            };
        }

        public static Ubigeo MaptoEntity(ActualizarUbigeoDepartamentoViewModel request)
        {
            return new Ubigeo()
            {
                ID_UBIGEO = request.idUbigeo,
                DEPARTAMENTO = request.departamento,
                DESCRIPCION = request.descripcion,
                //ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; 
        }

        public static Ubigeo MaptoEntity(ActualizarUbigeoProvinciaViewModel request)
        {
            return new Ubigeo()
            {
                ID_UBIGEO = request.idUbigeo,
                DEPARTAMENTO = request.departamento,
                PROVINCIA = request.provincia,
                DESCRIPCION = request.descripcion,
                //ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static Ubigeo MaptoEntity(ActualizarUbigeoDistritoViewModel request)
        {
            return new Ubigeo()
            {
                ID_UBIGEO = request.idUbigeo,
                DEPARTAMENTO = request.departamento,
                PROVINCIA = request.provincia,
                DISTRITO = request.distrito,
                DESCRIPCION = request.descripcion,
                //ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }


        public static ObtenerUbigeoPaginadoResponseDTO MaptoDTO(Ubigeo item)
        {
            return new ObtenerUbigeoPaginadoResponseDTO()
            {
                idUbigeo = item.ID_UBIGEO,                
                ubigeo = item.UBIGEO,
                departamento = item.DEPARTAMENTO,
                provincia = item.PROVINCIA,
                distrito = item.DISTRITO,
                //descripcion = item.DESCRIPCION,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerUbigeoPaginadoRequestDTO MaptoDTO(ObtenerUbigeoPaginadoViewModel item)
        {
            return new ObtenerUbigeoPaginadoRequestDTO()
            {
                ubigeo = item.ubigeo,
                departamento = item.departamento,
                provincia = item.provincia,
                distrito = item.distrito,
                //descripcion = item.descripcion,                
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }
                
    }
}
