using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEoDetalle
{
    public class ObtenerProyectoMccDetallePorIdPaginadoRequestDTO
    {
        public int paginaActual { get; set; }

        public int tamanioPagina { get; set; }

        public int idProyectoEoDetalle { get; set; }
    }
}
