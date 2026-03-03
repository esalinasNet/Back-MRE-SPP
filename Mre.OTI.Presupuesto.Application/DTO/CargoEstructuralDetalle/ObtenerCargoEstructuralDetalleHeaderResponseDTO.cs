using AutoMapper;
using Mre.OTIv1.Application.DTO.CargoEstructural;
using Mre.OTIv1.Application.Responses.CargoEstructural;
using Mre.OTIv1.Application.Responses.CargoEstructuralDetalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoEstructuralDetalleHeaderResponseDTO
    {
        public string nombreCargoEstructural { get; set; }
        public string nombre { get; set; }
        public string sigla { get; set; }

        public string siglaGenerada { get; set; }

    }
}
