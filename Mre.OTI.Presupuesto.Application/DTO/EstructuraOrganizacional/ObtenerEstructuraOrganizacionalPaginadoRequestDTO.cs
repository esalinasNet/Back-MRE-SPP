using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.EstructuraOrganizacional
{
    public class ObtenerEstructuraOrganizacionalPaginadoRequestDTO : Pagination
    {
        public string descripcionCargo { get; set; }
        public bool? activo { get; set; }

        public string fraseDesencriptacion {  get; set; }
    }
}
