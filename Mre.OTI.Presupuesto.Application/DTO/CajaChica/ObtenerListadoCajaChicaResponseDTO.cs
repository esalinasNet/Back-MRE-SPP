using System;

namespace Mre.OTI.Presupuesto.Application.DTO.CajaChica
{
    public class ObtenerListadoCajaChicaResponseDTO
    {
        public int idProgramacionCajaChica { get; set; }
        public int idProgramacionRecurso { get; set; }
        public int idProgramacionTareas { get; set; }
        public int idAnio { get; set; }
        public int idActividadOperativa { get; set; }
        public int idTarea { get; set; }
        public int? idUnidadMedida { get; set; }
        public bool? representativa { get; set; }
        public int? idFuenteFinanciamiento { get; set; }
        public int? idUbigeo { get; set; }
        public int? tipoUbigeo { get; set; }

        // Montos mensuales
        public decimal? montoEnero { get; set; }
        public decimal? montoFebrero { get; set; }
        public decimal? montoMarzo { get; set; }
        public decimal? montoAbril { get; set; }
        public decimal? montoMayo { get; set; }
        public decimal? montoJunio { get; set; }
        public decimal? montoJulio { get; set; }
        public decimal? montoAgosto { get; set; }
        public decimal? montoSetiembre { get; set; }
        public decimal? montoOctubre { get; set; }
        public decimal? montoNoviembre { get; set; }
        public decimal? montoDiciembre { get; set; }
        public decimal? montoTotal { get; set; }

        // Datos relacionados
        public int anio { get; set; }
        public string codigoTareas { get; set; }
        public string descripcionTareas { get; set; }
        public string codigoProgramacion { get; set; }
        public string denominacionActividad { get; set; }
        public string descripcionUnidadMedida { get; set; }
        public string descripcionFuenteFinanciamiento { get; set; }
        public string descripcionUbigeo { get; set; }

        public int idEstado { get; set; }
        public string estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
    }
}