using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccDetalle
{
    public class ObtenerProyectoMccDetallePorIdPaginadoRequestDTO
    {

        public int paginaActual { get; set; }

        public int tamanioPagina { get; set; }

        public int idProyectoMccDetalle { get; set; }

    }
}
