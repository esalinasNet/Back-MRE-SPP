using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionAnios
{
    public class CopiarProgramacionAniosRequestDTO
    {
        public int anioOrigen { get; set; }
        public List<int> aniosDestino { get; set; }
        public List<int> actividades { get; set; }
    }
}