using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccDetalle
{
    public class ObtenerProyectoMccDetalleResponseDTO
    {

        public int idProyectoMcc  { get; set; }
        public int idProyectoMccDetalle { get; set; }
        public string codigoCargo { get; set; }


        public string descripcion { get; set; }
        

        public bool esDirectivo { get; set; }


        public int orden { get; set; }


    }
}
