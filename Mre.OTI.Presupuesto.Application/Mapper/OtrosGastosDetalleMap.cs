using Mre.OTI.Presupuesto.Application.Features.OtrosGastosDetalle.Command;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class OtrosGastosDetalleMap
    {
        public static OtrosGastosDetalle MaptoEntity(AgregarOtrosGastosDetalleViewModel request)
        {
            return new OtrosGastosDetalle()
            {
                ID_PROGRAMACION_OTROS_GASTOS_DETALLE = request.idProgramacionOtrosGastosDetalle,
                ID_PROGRAMACION_OTROS_GASTOS = request.idProgramacionOtrosGastos,
                GENERICO = request.generico,
                ID_CLASIFICADOR = request.idClasificador,
                NOMBRE_CLASIFICADOR = request.nombreClasificador,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                MONTO = request.monto,  // AGREGADO
                VALOR = request.valor,
                MES = request.mes,

                ACTIVO = true,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }
    }
}