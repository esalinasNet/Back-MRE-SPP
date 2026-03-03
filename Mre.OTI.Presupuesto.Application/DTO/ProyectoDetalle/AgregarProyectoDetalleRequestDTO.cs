namespace Mre.OTI.Presupuesto.Application.DTO.ProyectoDetalle
{
    public class AgregarProyectoDetalleRequestDTO
    {
        public int idProgramacionProyectoDetalle { get; set; }
        public int idProgramacionProyecto { get; set; }
        public string codigoItem { get; set; }
        public string descripcion { get; set; }
        public decimal valor { get; set; }
        public int idUnidadMedida { get; set; }
        public int idClasificador { get; set; }
        public string nombreClasificador { get; set; }

        // Montos mensuales (como CMN)
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
    }
}