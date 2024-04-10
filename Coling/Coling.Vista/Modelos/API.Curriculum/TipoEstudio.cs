using Azure;
using Azure.Data.Tables;
using Coling.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Coling.Vista.Modelos.API.Curriculum
{
    public class TipoEstudio : ITipoEstudio
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Nombre { get; set; }

        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }
    }
}
