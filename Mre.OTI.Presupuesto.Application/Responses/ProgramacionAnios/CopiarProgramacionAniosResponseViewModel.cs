using System;

namespace Mre.OTI.Presupuesto.Application.Responses.ProgramacionAnios
{
    public class CopiarProgramacionAniosResponseViewModel
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public int aniosDestinoProcesados { get; set; }
        public int actividadesCopiadas { get; set; }
    }
}