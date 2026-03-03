using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccDetalle
{
    public class ObtenerProyectoMccDetallePaginadoRequestDTO : Pagination
    {

       
        public string denominacion {  get; set; }
        public string sigla {  get; set; }
        public int idProyectoMcc { get; set; }

    }
}
