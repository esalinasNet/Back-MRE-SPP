namespace Mre.OTI.Presupuesto.Application.DTO.EncargosDetalle
{
    public class AgregarEncargosDetalleRequestDTO
    {
        public int idProgramacionEncargosDetalle { get; set; }
        public int idProgramacionEncargos { get; set; }
        public int idClasificador { get; set; }
        public string nombreClasificador { get; set; }
        public string denominacionRecurso { get; set; }
        public decimal monto { get; set; }  // AGREGADO
        public decimal valor { get; set; }
        public int mes { get; set; }
    }
}