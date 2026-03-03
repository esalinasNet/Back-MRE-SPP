using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Sistema;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Sistema
{
    public class ObtenerSistemaPaginadoResponseViewModel : IMapFrom<ObtenerSistemaPaginadoResponseDTO>
    {
        public int idSistema { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codigo_sistema { get; set; }
        public bool? activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerSistemaPaginadoResponseDTO, ObtenerSistemaPaginadoResponseViewModel>();
        }
    }

    public class dtSistemaPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerSistemaPaginadoResponseViewModel> data { get; set; }
    }

}
