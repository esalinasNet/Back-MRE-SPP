using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ProgramacionActividad
{
    public class ObtenerListadoProgramacionActividadResponseDTO
    {
        public int idProgramacionActividad { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoProgramacion { get; set; }
        public string denominacion { get; set; }
        public string descripcion { get; set; }
        public string objetivoPrioritario { get; set; }
        public string lineamiento { get; set; }

        public int idPoliticas { get; set; }
        public int idObjetivosEstrategicas { get; set; }
        public int idAccionesEstrategicas { get; set; }
        public int idObjetivosInstitucionales { get; set; }
        public int idAccionesInstitucionales { get; set; }
        public int idCategoriaPresupuestal { get; set; }
        public int idProductoProyecto { get; set; }
        public int idFuncion { get; set; }
        public int idDivisionFuncional { get; set; }
        public int idGrupoFuncional { get; set; }
        public int idActividadPresupuestal { get; set; }
        public int idFinalidad { get; set; }
        public int idUnidadMedida { get; set; }
        public string unidadMedidaDescripcion { get; set; }

        public int tipoUbigeo { get; set; }
        public string ubigeo { get; set; }
        public string region { get; set; }
        public string pais { get; set; }
        public string ose { get; set; }
        public int idMoneda { get; set; }

        public bool? actividadOperativa { get; set; }
        public bool? actividadInversion { get; set; }
        public int idCentroCostos { get; set; }

        public int metaFisica { get; set; }
        public decimal metaFinanciera { get; set; }

        public string observacion { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
                
    }
}
