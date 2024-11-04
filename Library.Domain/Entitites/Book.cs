
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }


        [Display(Name = "Título")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede exceder de 100 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El autor no puede exceder de 50 caracteres.")]
        public string Autor { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [StringLength(30, ErrorMessage = "El {0} no puede exceder de 30 caracteres.")]
        public string Genero { get; set; }


        [Display(Name = "Fecha de publicación")]
        [DataType(DataType.Date)]  
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public DateTime FechaPublicacion { get; set; }


        [Display(Name = "Sinopsis")]
        [StringLength(500, ErrorMessage = "La {0} no puede exceder de 500 caracteres.")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string Sinopsis { get; set; }
    }
}