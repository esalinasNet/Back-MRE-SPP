using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoCargoFuncion
{
    public class ObtenerProyectoCargoFuncionResponseDTO
    {
        public int idCargoFuncion {  get; set; }
        public int idProyectoMccDetalle {  get; set; }
        public string descripcion { get; set; }
        public int orden {  get; set; }

    }
}
