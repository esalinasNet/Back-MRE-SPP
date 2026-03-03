using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.UnidadOrganizacionalCargo
{
    public class ListarUnidadOrganizacionalCargoPaginadoRequestDTO : Pagination
    {
        public string codigoUnidadOrganizacional {  get; set; }
    }
}
