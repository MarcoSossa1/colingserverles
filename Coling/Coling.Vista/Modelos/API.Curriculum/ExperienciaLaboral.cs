using Azure;
using Azure.Data.Tables;
using Coling.Shared.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Coling.Vista.Modelos.API.Curriculum
{
    public class ExperienciaLaboral : IExperienciaLaboral
    {
        [Display(Name = "Afiliado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Afiliado { get; set; }

        [Display(Name = "Institución")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Institucion { get; set; }

        [Display(Name = "Cargo o Título")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string CargoTitulo { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Final")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaFinal { get; set; }

        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }
    }
}
