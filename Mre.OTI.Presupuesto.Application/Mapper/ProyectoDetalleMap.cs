using Mre.OTI.Presupuesto.Application.Features.ProyectoDetalle.Command;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProyectoDetalleMap
    {
        public static ProyectoDetalle MaptoEntity(AgregarProyectoDetalleViewModel request)
        {
            return new ProyectoDetalle()
            {
                ID_PROGRAMACION_PROYECTO_DETALLE = request.idProgramacionProyectoDetalle,
                ID_PROGRAMACION_PROYECTO = request.idProgramacionProyecto,
                CODIGO_ITEM = request.codigoItem,
                DESCRIPCION = request.descripcion,
                VALOR = request.valor,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                ID_CLASIFICADOR = request.idClasificador,
                NOMBRE_CLASIFICADOR = request.nombreClasificador,

                MONTO_ENERO = request.montoEnero ?? 0,
                MONTO_FEBRERO = request.montoFebrero ?? 0,
                MONTO_MARZO = request.montoMarzo ?? 0,
                MONTO_ABRIL = request.montoAbril ?? 0,
                MONTO_MAYO = request.montoMayo ?? 0,
                MONTO_JUNIO = request.montoJunio ?? 0,
                MONTO_JULIO = request.montoJulio ?? 0,
                MONTO_AGOSTO = request.montoAgosto ?? 0,
                MONTO_SETIEMBRE = request.montoSetiembre ?? 0,
                MONTO_OCTUBRE = request.montoOctubre ?? 0,
                MONTO_NOVIEMBRE = request.montoNoviembre ?? 0,
                MONTO_DICIEMBRE = request.montoDiciembre ?? 0,

                ACTIVO = true,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }
    }
}