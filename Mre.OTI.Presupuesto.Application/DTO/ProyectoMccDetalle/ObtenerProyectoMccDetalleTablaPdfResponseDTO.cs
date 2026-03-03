using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccDetalle
{
    public class ObtenerProyectoMccDetalleTablaPdfResponseDTO
    {
        public string codigoCargo { get; set; }
        public string descripcion {  get; set; }
        public string siglaGenerada {  get; set; }
        public bool esDirectivo { get; set; }
    }
}
