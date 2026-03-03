using System;

namespace Mre.OTI.Presupuesto.Application.Responses.Recurso
{
    public class ObtenerListadoRecursoResponseViewModel
    {
        public int idProgramacionRecurso { get; set; }
        public int idProgramacionActividad { get; set; }
        public int idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public int? anio { get; set; }
        public string codigoTareas { get; set; }
        public string descripcionTareas { get; set; }
        public string codigoProgramacion { get; set; }
        public string denominacionActividad { get; set; }
        public int? idUbigeo { get; set; }
        public string descripcionUbigeo { get; set; }
        public string clasificadorGasto { get; set; }
        public string descripcionFuenteFinanciamento { get; set; }
        public string descripcionClasificador { get; set; }
        public string denominacionRecurso { get; set; }
        public int? idTipoGasto { get; set; }
        public int? idTipoItem { get; set; }
        public decimal? montoTotal { get; set; }
        public int? idFuenteFinanciamiento { get; set; }
        public string descripcionFuenteFinanciamiento { get; set; }
        public int? idUnidadMedida { get; set; }
        public string descripcionUnidadMedida { get; set; }
        public bool? representativa { get; set; }
        public bool? gastoObn { get; set; }
        public bool? gastoProyecto { get; set; }
        public bool? gastoViaticos { get; set; }
        public bool? gastoCajaChica { get; set; }
        public bool? gastoOtrosGastos { get; set; }
        public bool? gastoEncargas { get; set; }
        public bool? gastoPlanilla { get; set; }
        public int idEstado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
    }
}