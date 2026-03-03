using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Rol
{
    public class ObtenerListaRolResponseViewModel : IMapFrom<ObtenerListaRolResponseDTO>
    {
        public int idRol { get; set; }
        public string nombre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerListaRolResponseDTO, ObtenerListaRolResponseViewModel>();
        }
    }

    public class dtListaRolResponseViewModel
    {
        //public int draw { get; set; }
        //public int recordsTotal { get; set; }
        //public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerListaRolResponseViewModel> data { get; set; }
    }
}
