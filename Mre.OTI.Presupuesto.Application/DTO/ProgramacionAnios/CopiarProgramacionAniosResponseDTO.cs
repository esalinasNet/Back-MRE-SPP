using System;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionAnios
{
    public class CopiarProgramacionAniosResponseDTO
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public int aniosDestinoProcesados { get; set; }
        public int actividadesCopiadas { get; set; }
    }
}