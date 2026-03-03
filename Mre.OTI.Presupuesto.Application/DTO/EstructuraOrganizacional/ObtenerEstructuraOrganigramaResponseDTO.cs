using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.EstructuraOrganizacional
{
    public class ObtenerEstructuraOrganigramaResponseDTO
    {
        public int key { get; set; }
        public int parent { get; set; }
        public string name { get; set; }
        public string fullTitle { get; set; }

    }
}
