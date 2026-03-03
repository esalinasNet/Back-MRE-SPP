using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class ObtenerListarUsuariosResponseDTO
    {
        public int idUsuario { get; set; }

        public string nombres { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }
    }
}
