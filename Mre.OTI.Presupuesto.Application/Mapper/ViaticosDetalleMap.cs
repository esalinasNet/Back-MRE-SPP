using Mre.OTI.Presupuesto.Application.Features.ViaticosDetalle.Command;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ViaticosDetalleMap
    {
        public static ViaticosDetalle MaptoEntity(AgregarViaticosDetalleViewModel request)
        {
            return new ViaticosDetalle()
            {
                ID_PROGRAMACION_VIATICOS_DETALLE = request.idProgramacionViaticosDetalle,
                ID_PROGRAMACION_VIATICOS = request.idProgramacionViaticos,
                ID_CLASIFICADOR = request.idClasificador,
                NOMBRE_CLASIFICADOR = request.nombreClasificador,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                MONTO = request.monto,
                CANTIDAD_PERSONAS = request.cantidadPersonas,
                DIAS = request.dias,
                MES = request.mes,

                ACTIVO = true,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }
    }
}