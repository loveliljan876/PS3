using System.ComponentModel.DataAnnotations;

namespace PS3.Pages.Forms
{
    public class YearForm
    {
        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole '{0}' jest wymagane.")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość pola '{0}' musi być z zakresu {1} i {2}.")]
        public int? Year { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole '{0}' jest wymagane.")]
        [StringLength(100, ErrorMessage = "Wartość {0} nie może być dłuższa niż {0} znaków.")]
        public string? Name { get; set; }
    }
}
