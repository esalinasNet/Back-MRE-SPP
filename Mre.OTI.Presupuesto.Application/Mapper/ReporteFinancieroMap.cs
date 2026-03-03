using Mre.OTI.Presupuesto.Application.DTO.Reporte;
using Mre.OTI.Presupuesto.Application.Responses.Reporte;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ReporteFinancieroMap
    {
        public static ObtenerReporteFinancieroResponseViewModel MaptoViewModel(ObtenerReporteFinancieroResponseDTO dto)
        {
            if (dto?.header == null) return null;

            return new ObtenerReporteFinancieroResponseViewModel
            {
                header = new ReporteFinancieroActividadHeaderViewModel
                {
                    idProgramacionActividad = dto.header.idProgramacionActividad,
                    idAnio = dto.header.idAnio,
                    anio = dto.header.anio,
                    idCentroCostos = dto.header.idCentroCostos,
                    centroCostos = dto.header.centroCostos,
                    centroCostosDescripcion = dto.header.centroCostosDescripcion,
                    centroCostosPadre = dto.header.centroCostosPadre,
                    centroCostosPadreDescripcion = dto.header.centroCostosPadreDescripcion,
                    codigoProgramacionActividad = dto.header.codigoProgramacionActividad,
                    denominacionActividad = dto.header.denominacionActividad,
                    descripcionActividad = dto.header.descripcionActividad,
                    idObjetivosInstitucionales = dto.header.idObjetivosInstitucionales,
                    objetivosInstitucionalesDescripcion = dto.header.objetivosInstitucionalesDescripcion,
                    idAccionesInstitucionales = dto.header.idAccionesInstitucionales,
                    accionesInstitucionalesDescripcion = dto.header.accionesInstitucionalesDescripcion,
                    idCategoriaPresupuestal = dto.header.idCategoriaPresupuestal,
                    categoriaPresupuestalDescripcion = dto.header.categoriaPresupuestalDescripcion,
                    idProductoProyecto = dto.header.idProductoProyecto,
                    productoProyectoDescripcion = dto.header.productoProyectoDescripcion,
                    idActividadPresupuestal = dto.header.idActividadPresupuestal,
                    actividadPresupuestalDescripcion = dto.header.actividadPresupuestalDescripcion,
                    idFuncion = dto.header.idFuncion,
                    funcionDescripcion = dto.header.funcionDescripcion,
                    idDivisionFuncional = dto.header.idDivisionFuncional,
                    divisionFuncionalDescripcion = dto.header.divisionFuncionalDescripcion,
                    idGrupoFuncional = dto.header.idGrupoFuncional,
                    grupoFuncionalDescripcion = dto.header.grupoFuncionalDescripcion
                },

                jerarquia = dto.jerarquia?.Select(j => new ReporteFinancieroJerarquiaViewModel
                {
                    ordenNivel = j.ordenNivel,
                    nivel = j.nivel,
                    idTarea = j.idTarea,
                    codigoTarea = j.codigoTarea,
                    descripcionTarea = j.descripcionTarea,
                    idFuente = j.idFuente,
                    fuenteFinanciamiento = j.fuenteFinanciamiento,
                    idClasificadorTarea = j.idClasificadorTarea,
                    clasificadorTareaDescripcion = j.clasificadorTareaDescripcion,
                    tipoDetalle = j.tipoDetalle,
                    idDetalle = j.idDetalle,
                    idClasificadorDetalle = j.idClasificadorDetalle,
                    clasificadorDetalleDescripcion = j.clasificadorDetalleDescripcion,
                    // Mapeo directo de propiedades en MAYÚSCULAS
                    MONTO_ENERO = j.MONTO_ENERO,
                    MONTO_FEBRERO = j.MONTO_FEBRERO,
                    MONTO_MARZO = j.MONTO_MARZO,
                    MONTO_ABRIL = j.MONTO_ABRIL,
                    MONTO_MAYO = j.MONTO_MAYO,
                    MONTO_JUNIO = j.MONTO_JUNIO,
                    MONTO_JULIO = j.MONTO_JULIO,
                    MONTO_AGOSTO = j.MONTO_AGOSTO,
                    MONTO_SETIEMBRE = j.MONTO_SETIEMBRE,
                    MONTO_OCTUBRE = j.MONTO_OCTUBRE,
                    MONTO_NOVIEMBRE = j.MONTO_NOVIEMBRE,
                    MONTO_DICIEMBRE = j.MONTO_DICIEMBRE,
                    MONTO_TOTAL = j.MONTO_TOTAL
                }),

                totalGeneral = dto.totalGeneral != null ? new ReporteFinancieroTotalGeneralViewModel
                {
                    idProgramacionActividad = dto.totalGeneral.idProgramacionActividad,
                    montoEnero = dto.totalGeneral.montoEnero,
                    montoFebrero = dto.totalGeneral.montoFebrero,
                    montoMarzo = dto.totalGeneral.montoMarzo,
                    montoAbril = dto.totalGeneral.montoAbril,
                    montoMayo = dto.totalGeneral.montoMayo,
                    montoJunio = dto.totalGeneral.montoJunio,
                    montoJulio = dto.totalGeneral.montoJulio,
                    montoAgosto = dto.totalGeneral.montoAgosto,
                    montoSetiembre = dto.totalGeneral.montoSetiembre,
                    montoOctubre = dto.totalGeneral.montoOctubre,
                    montoNoviembre = dto.totalGeneral.montoNoviembre,
                    montoDiciembre = dto.totalGeneral.montoDiciembre,
                    montoTotal = dto.totalGeneral.montoTotal
                } : null
            };
        }
    }
}