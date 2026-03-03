using System;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.DTO.Services
{
    public class ProyectoResolucionGenerarDirectoRequestDTO
    {
        public string nombreSolicitante { get; set; }
        public int codigoTipoResolucion { get; set; }
        public string codigoDre { get; set; }
        public string codigoUgel { get; set; }
        public int codigoSistema { get; set; }
        public bool generarProyectoResolucion { get; set; }
        public DetalleProyectoResolucionDirectoDTO detalle { get; set; }
        public List<DocumentoSustentoProyectoDirectoDTO> documentos { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }

    public class DetalleProyectoResolucionDirectoDTO
    {
        public int codigoRegimenLaboral { get; set; }
        public int codigoGrupoAccion { get; set; }
        public int codigoAccion { get; set; }
        public int codigoMotivoAccion { get; set; }
        public int? codigoTipoDocumentoIdentidad { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public long? codigoServidorPublico { get; set; }
        public string codigoPlaza { get; set; }
        public DateTime fechaInicioAccion { get; set; }
        public DateTime? fechaFinAccion { get; set; }
        public bool? esMandatoJudidicial { get; set; }
        public bool esLista { get; set; }
        public List<DetalleVistaProyectoDirectoDTO> detallesVistaProyecto { get; set; }
    }

    public class DetalleVistaProyectoDirectoDTO
    {
        public string nombreCampo { get; set; }
        public int? valorEntero { get; set; }
        public string valorTexto { get; set; }
        public DateTime? valorFecha { get; set; }
        public decimal? valorDecimal { get; set; }
        public bool? valorBit { get; set; }
        public DateTime? valorFechaHora { get; set; }
    }

    public class DocumentoSustentoProyectoDirectoDTO
    {
        public int codigoTipoDocumentoSustento { get; set; }
        public int codigoTipoFormatoSustento { get; set; }
        public string numeroDocumentoSustento { get; set; }
        public string entidadEmisora { get; set; }
        public DateTime fechaEmision { get; set; }
        public int numeroFolios { get; set; }
        public string sumilla { get; set; }
        public string codigoDocumentoSustento { get; set; }
        public bool vistoProyecto { get; set; }
    }

}
