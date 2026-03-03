using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Sistema;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Sistema
{
    public class ObtenerSistemaResponseViewModel : IMapFrom<ObtenerSistemaResponseDTO>
    {
        public int idSistema { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codigo_sistema { get; set; }
        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerSistemaResponseDTO, ObtenerSistemaResponseViewModel>();
        }
    }
}
