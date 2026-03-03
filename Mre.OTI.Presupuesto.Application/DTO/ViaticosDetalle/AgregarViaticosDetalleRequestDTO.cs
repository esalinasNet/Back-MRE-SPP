namespace Mre.OTI.Presupuesto.Application.DTO.ViaticosDetalle
{
    public class AgregarViaticosDetalleRequestDTO
    {
        public int idProgramacionViaticosDetalle { get; set; }
        public int idProgramacionViaticos { get; set; }
        public int idClasificador { get; set; }
        public string nombreClasificador { get; set; }
        public string denominacionRecurso { get; set; }
        public decimal monto { get; set; }
        public int cantidadPersonas { get; set; }
        public int dias { get; set; }
        public int mes { get; set; }
    }
}