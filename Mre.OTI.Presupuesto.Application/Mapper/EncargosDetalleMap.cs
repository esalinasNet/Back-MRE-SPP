using Mre.OTI.Presupuesto.Application.Features.EncargosDetalle.Command;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class EncargosDetalleMap
    {
        public static EncargosDetalle MaptoEntity(AgregarEncargosDetalleViewModel request)
        {
            return new EncargosDetalle()
            {
                ID_PROGRAMACION_ENCARGOS_DETALLE = request.idProgramacionEncargosDetalle,
                ID_PROGRAMACION_ENCARGOS = request.idProgramacionEncargos,
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