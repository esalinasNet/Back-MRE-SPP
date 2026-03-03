using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos
{
    public class EliminaAeiCentroCostosResponseViewModel : IMapFrom<EliminaAeiCentroCostosResponseDTO>
    {
        public int idAeiCostos { get; set; }
        public int idAcciones { get; set; }
        public int idCentroCostos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EliminaAeiCentroCostosResponseDTO, EliminaAeiCentroCostosResponseViewModel>();
        }
    }
}
