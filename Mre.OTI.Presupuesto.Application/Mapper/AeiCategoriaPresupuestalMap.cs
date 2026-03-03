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

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class AeiCategoriaPresupuestalMap
    {
        public static ObtenerAeiCategoriaPresupuestalRequestDTO MaptoCCDTO(ObtenerAeiCategoriaPresupuestalViewModel item)
        {
            return new ObtenerAeiCategoriaPresupuestalRequestDTO()
            {
                idAnio = item.idAnio,
                idPresupuestal = item.idPresupuestal
            };
        }

        public static ObtenerAeiCategoriaPresupuestalResponseViewModel MaptoViewModelAeiCostos(dynamic item)
        {
            return new ObtenerAeiCategoriaPresupuestalResponseViewModel()
            {
                idAeiPresupuestal = item.idAeiPresupuestal,
                idAnio = item.idAnio,
                idPresupuestal = item.idPresupuestal,
                idAcciones = item.idAcciones, 
                activo = item.activo
            };
        }


        public static AeiCategoriaPresupuestal MaptoEntity(AgregarAeiCategoriaPresupuestalViewModel request)
        {
            return new AeiCategoriaPresupuestal()
            {
                ID_ANIO = request.idAnio,
                ID_PRESUPUESTAL = request.idPresupuestal,

                ID_ACCIONES = request.idAcciones,

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
                ID_PRESUPUESTAL = request.idPresupuestal,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }
    }
}
