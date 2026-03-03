namespace Mre.OTI.Presupuesto.Application.DTO.OtrosGastosDetalle
{
    public class AgregarOtrosGastosDetalleRequestDTO
    {
        public int idProgramacionOtrosGastosDetalle { get; set; }
        public int idProgramacionOtrosGastos { get; set; }
        public string generico { get; set; }
        public int idClasificador { get; set; }
        public string nombreClasificador { get; set; }
        public string denominacionRecurso { get; set; }
        public decimal monto { get; set; }  // AGREGADO
        public decimal valor { get; set; }
        public int mes { get; set; }
    }
}