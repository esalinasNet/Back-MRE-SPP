using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerPlanEstudioDTO : Pagination
    {
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

        public int idAreaCurricular { get; set; }

        public int idModeloServicioEducativo { get; set; }

        public int totalHorasGrado { get; set; }

        public int registro { get; set; }

        public int totalRegistro { get; set; }


    }
    public class ObtenerPlanEstudioResponseDTO
    {


        public int idPlanEstudio { get; set; }
        public int idNivelEducativo { get; set; }
        public int idModeloServicioEducativo { get; set; }
        public int idFormaAtencion { get; set; }
        public int idPeriodoPromocional { get; set; }
        public int anio { get; set; }
        public string nombrePlanEstudio { get; set; }
        public int grado1roHLD { get; set; }
        public int grado2doHLD { get; set; }
        public int grado3roHLD { get; set; }
        public int grado4toHLD { get; set; }
        public int grado5toHLD { get; set; }


        public int totalHorasGrado { get; set; }
    }
    public class ObtenerPlanEstudioRequestDTO
    {

        public int idNivelEducativo { get; set; }
        public int idModeloServicioEducativo { get; set; }
        public int idFormaAtencion { get; set; }
        public int idPeriodoPromocional { get; set; }
        public int anioEmision { get; set; }
    }
    public class ObtenerPlanEstudioPorPlanRequestDTO
    {

        public int idPlanEstudio { get; set; }

    }
    public class ObtenerPlanEstudioPorIdRequestDTO
    {
        public int idPlanEstudio { get; set; }

    }
    public class PlanEstudioResumenTotalesDTO
    {
        public int totalDocentes { get; set; }
        public int totalAlumnos { get; set; }
        public int totalSeccion { get; set; }

        public int totalGrados { get; set; }
        public int totalHoras { get; set; }

        public int totalBolsaHoras { get; set; }
    }
    public class PlanEstudioRequestDTO
    {
        public int anio { get; set; }
        public int idSubUnidadEjecutora { get; set; }
    }
    public class PlanEstudioResumenHorasTotalesPorUgelDTO
    {
        public int totalBolsaUgel { get; set; }
        public int totalBolsaAsignadaUgel { get; set; }
        public int totalHorasPlanEstudio { get; set; }

    }

}
