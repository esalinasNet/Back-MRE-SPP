namespace Mre.OTI.Presupuesto.Application.DTO.Proyecto
{
    public class ObtenerListadoProyectoRequestDTO
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public int? idActividadOperativa { get; set; }
    }
}