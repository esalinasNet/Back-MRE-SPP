using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerPlanEstudioContextualizadoDTO : Pagination
    {
        public int idDetallePlanEstudioContextualizado { get; set; }
        public int idPlanEstudioContextualizado { get; set; }
        public int idPlanEstudio { get; set; }
        public string descripcionAreaCurricular { get; set; }
        public int grado1roHoraSemana { get; set; }
        public int grado2doHoraSemana { get; set; }
        public int grado3roHoraSemana { get; set; }
        public int grado4toHoraSemana { get; set; }
        public int grado5toHoraSemana { get; set; }
        public bool ampliacion { get; set; }
        public bool desdobla { get; set; }
        public bool esPlan { get; set; }


        public int idNivelEducativo { get; set; }

        public int idModeloServicioEducativop { get; set; }
        public int idAreaCurricular { get; set; }
        public int idParametroInicial { get; set; }

        public int? grado1roHorasLDAsignado { get; set; }
        public int? grado2doHorasLDAsignado { get; set; }
        public int? grado3roHorasLDAsignado { get; set; }
        public int? grado4toHorasLDAsignado { get; set; }
        public int? grado5toHorasLDAsignado { get; set; }

    }
    public class ObtenerPlanEstudioContextualizadoRequestDTO
    {
        public int idParametroInicial { get; set; }

    }
    public class PlanEstudioContextualizadoResumenTotalesDTO
    {
        public int totalDocentes { get; set; }
        public int totalAlumnos { get; set; }
        public int totalSeccion { get; set; }

        public int totalGrados { get; set; }
        public int totalHoras { get; set; }

        public int totalBolsaHoras { get; set; }
    }
    public class PlanEstudioContextualizadoRequestDTO
    {
        public int anio { get; set; }
        public int idSubUnidadEjecutora { get; set; }
    }
    public class PlanEstudioContextualizadoResumenHorasTotalesPorUgelDTO
    {
        public int totalBolsaUgel { get; set; }
        public int totalBolsaAsignadaUgel { get; set; }
        public int totalHorasPlanEstudioContextualizado { get; set; }

    }
    public class ObtenerPlanEstudioHoraMinimoRequestDTO
    {
        public int idParametroInicial { get; set; }
        public int idUnidadEjecutora { get; set; }
        public int idSubUnidadEjecutora { get; set; }
        public int idInstitucionEducativa { get; set; }
        public int anio { get; set; }
    }
}
