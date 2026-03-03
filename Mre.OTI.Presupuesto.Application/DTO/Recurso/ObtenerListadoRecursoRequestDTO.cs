using System;

namespace Mre.OTI.Presupuesto.Application.DTO.Recurso
{
    public class ObtenerListadoRecursoRequestDTO
    {
        public int? idProgramacionTareas { get; set; }
        public string usuarioConsulta { get; set; } // ✅ AGREGADO
    }
}