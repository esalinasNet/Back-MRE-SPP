using Mre.OTI.Presupuesto.Application.DTO.AeiCategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Command;
using Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Queries;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Command;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Responses.AeiCategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Mre.OTI.Presupuesto.Application.Util.VariablesGlobales;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class AeiCategoriaPresupuestalMap
    {
        public static ObtenerAeiCategoriaPresupuestalRequestDTO MaptoCCDTO(ObtenerAeiCategoriaPresupuestalViewModel item)
        {
            return new ObtenerAeiCategoriaPresupuestalRequestDTO()
            {
                idAnio = item.idAnio,                
                idAcciones = item.idAcciones
            };
        }

        public static ObtenerAeiCategoriaPresupuestalResponseViewModel MaptoViewModelAeiCostos(dynamic item)
        {
            return new ObtenerAeiCategoriaPresupuestalResponseViewModel()
            {
                idAeiPresupuestal = item.idAeiPresupuestal,
                idAnio = item.idAnio,
                anio = item.anio,
                idPresupuestal = item.idPresupuestal,
                codigoPresupuestal = item.codigoPresupuestal,
                descripcionPresupuestal = item.descripcionPresupuestal,
                idAcciones = item.idAcciones,
                codigoAcciones = item.codigoAcciones,
                descripcionAcciones = item.descripcionAcciones,
                activo = item.activo
            };
        }

        public static AeiCategoriaPresupuestal MaptoEntity(AgregarAeiCategoriaPresupuestalViewModel request)
        {
            return new AeiCategoriaPresupuestal()
            {
                ID_ANIO = request.idAnio,
                ID_ACCIONES = request.idAcciones,

                ID_PRESUPUESTAL = request.idPresupuestal,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static AeiCategoriaPresupuestal MaptoEntity(EliminarAeiCategoriaPresupuestalViewModel request)
        {
            return new AeiCategoriaPresupuestal()
            {
                ID_ANIO = request.idAnio,
                ID_ACCIONES = request.idAcciones,
                ID_PRESUPUESTAL = request.idPresupuestal,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }
        
    }
}
