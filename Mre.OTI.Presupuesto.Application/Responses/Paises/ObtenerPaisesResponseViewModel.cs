using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Anio;
using Mre.OTI.Presupuesto.Application.DTO.Paises;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Paises
{
    public class ObtenerPaisesResponseViewModel : IMapFrom<ObtenerPaisesResponseDTO>
    {
        public int id_paises { get; set; }
        public string codigo { get; set; }
        public string nombre_pais { get; set; }
        public string continente { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public int activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerPaisesResponseDTO, ObtenerPaisesResponseViewModel>();
        }
    }
}
