using Mre.OTI.Presupuesto.Application.DTO.Programa;
using Mre.OTI.Presupuesto.Application.DTO.SubPrograma;
using Mre.OTI.Presupuesto.Application.Features.Programa.Queries;
using Mre.OTI.Presupuesto.Application.Features.SubPrograna.Command;
using Mre.OTI.Presupuesto.Application.Features.SubPrograna.Queries;
using Mre.OTI.Presupuesto.Application.Responses.SubPrograma;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class SubProgramaMap
    {
        public static ObtenerListadoSubProgramaResponseViewModel MaptoViewModel(dynamic programa)
        {
            return new ObtenerListadoSubProgramaResponseViewModel()
            {
                idsubprograma = programa.id_SubFuncion,
                anio = programa.anio,
                subprograma = programa.subprograma,
                descripcion = programa.descripcion,
                estado = programa.estado
            };
        }

        public static SubPrograma MaptoEntity(AgregarSubProgramaViewModel request)
        {
            return new SubPrograma()
            {
                ID_ANIO = request.idAnio,
                SUB_PROGRAMA = request.subprograma,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }

        public static SubPrograma MaptoEntity(ActualizarSubProgramaViewModel request)
        {
            return new SubPrograma()
            {
                ID_SUB_PROGRAMA = request.idSubPrograma,
                ID_ANIO = request.idAnio,
                SUB_PROGRAMA = request.subprograma,
                DESCRIPCION = request.descripcion,
                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static SubPrograma MaptoEntity(EliminarSubProgramaViewModel request)
        {
            return new SubPrograma()
            {
                ID_SUB_PROGRAMA = request.idSubPrograma,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }

        public static ObtenerSubProgramaPaginadoResponseDTO MaptoDTO(SubPrograma item)
        {
            return new ObtenerSubProgramaPaginadoResponseDTO()
            {
                idSubPrograma = item.ID_SUB_PROGRAMA,
                idAnio = item.ID_ANIO,
                subprograma = item.SUB_PROGRAMA,
                descripcion = item.DESCRIPCION,
                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerSubProgramaPaginadoRequestDTO MaptoDTO(ObtenerSubProgramaPaginadoViewModel item)
        {
            return new ObtenerSubProgramaPaginadoRequestDTO()
            {
                Anio = item.anio,
                subprograma = item.subprograma,
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
