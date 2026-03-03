using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.CajaChica
{
    public class ObtenerListadoCajaChicaRequestDTO
    {
        public int? idProgramacionRecurso { get; set; }
        public int? idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
    }
}