namespace Mre.OTI.Presupuesto.Application.DTO.Planilla
{
    public class ObtenerListadoPlanillaRequestDTO
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
    }
}