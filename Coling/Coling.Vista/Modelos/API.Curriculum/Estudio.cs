using Azure;
using Azure.Data.Tables;
using Coling.Shared.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Coling.Vista.Modelos.API.Curriculum
{
    public class Estudio : IEstudio
    {
        [Display(Name = "Tipo de Estudio")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string TipoEstudio { get; set; }

        [Display(Name = "Afiliado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Afiliado { get; set; }

        [Display(Name = "Grado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Grado { get; set; }

        [Display(Name = "Título Recibido")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string TituloRecibido { get; set; }

        [Display(Name = "Institución")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Institucion { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Año { get; set; }
        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }
    }
}
