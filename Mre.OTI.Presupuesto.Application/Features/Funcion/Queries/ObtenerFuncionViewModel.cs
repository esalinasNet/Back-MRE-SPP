using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Queries
{
    public class ObtenerFuncionViewModel : IRequest<ObtenerFuncionResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idFuncion { get; set; }
    }
}
