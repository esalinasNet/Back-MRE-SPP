using Mre.OTI.Presupuesto.Application.Base.DTO;

namespace Mre.OTI.Presupuesto.Application.DTO.Planilla
{
    public class ObtenerPlanillaPaginadoRequestDTO : Pagination
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? anio { get; set; }
        public int? tipoUbigeo { get; set; }
        public string nombreTrabajador { get; set; }
        public string cargo { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}