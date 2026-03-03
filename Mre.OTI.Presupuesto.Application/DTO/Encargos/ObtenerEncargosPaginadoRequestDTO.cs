using Mre.OTI.Presupuesto.Application.Base.DTO;

namespace Mre.OTI.Presupuesto.Application.DTO.Encargos
{
    public class ObtenerEncargosPaginadoRequestDTO : Pagination
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? anio { get; set; }
        public int? tipoUbigeo { get; set; }
        public string denominacionRecurso { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}