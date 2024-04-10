using Azure;
using Azure.Data.Tables;
using Coling.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Coling.Vista.Modelos.API.Curriculum
{
    public class GradoAcademico : IGradoAcademico
    {
        [Display(Name = "Nombre del Grado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string NombreGrado { get; set; }

        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }
    }
}
