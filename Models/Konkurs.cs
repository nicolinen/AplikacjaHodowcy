using System.Xml.Linq;

namespace AplikacjaHodowcy.Models
{
    public class Konkurs
    {
        [Key]
        public int Id { get; set; }
        // [Required]

        [Display(Name = "Rodzaj wystawy")]
        public string Type { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Nazwa")]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Opis")]
        [MaxLength(2000)]
        public string Desription { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Ścieżka do pliku")]
        public string PhotoPath { get; set; }

        //[Required]
        [MaxLength(1000)]
        public virtual string KrajoweRegulacje { get; set; } // Dodaj właściwość dla krajowych regulacji

        //[Required]
        [MaxLength(50)]
        public string Kraj { get; set; } // Dodaj właściwość dla kraju
    }
}
