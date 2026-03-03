using System;
using System.Collections.Generic;
using Mre.ProcesoPersonal.Application.DTO.EscalaCalificacion;
using Mre.ProcesoPersonal.Application.DTO.EscalaLikert;
using Mre.ProcesoPersonal.Application.DTO.EvaluacionFomato;

namespace Mre.ProcesoPersonal.Application.DTO.Cargo
{
    public class ObtenerCargoResponseDTO
    {
        public int idCargo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string abreviatura { get; set; }
        public string codigoCargo { get; set; }

    }
}
