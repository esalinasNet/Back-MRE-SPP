using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccDetalle
{
    public class ObtenerProyectoMccDetalleFuncionPaginadoResponseDTO
    {
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public int idCargoFuncion { get; set; }
        

        public string descripcion { get; set; }
        public int orden { get; set; }
       
    }
}
