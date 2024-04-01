using System.Xml.Linq;

namespace AplikacjaHodowcy.Models
{
    public class Szczeniak
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(2000)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Date)]
        [Display(Name = "Data narodzin")]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "To pole jest wymagane")]
        [NotMapped]
        [Display(Name = "Nazwa Linii")]
        public int LiniaId { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [ForeignKey("Miot")]
        [DisplayName("Miot")]
        public int MiotId { get; set; }
        public virtual Miot Miot { get; set; }

        [Required(ErrorMessage = "Proszę dodaj zdjecie szczeniaka")]
        [MaxLength(500)]
        [Display(Name = "Zdjęcie szczeniaka")]
        public string PhotoUrl { get; set; }

        [NotMapped]
        [Display(Name = "Zdjęcie szczeniaka")]
        public IFormFile PuppyPhoto { get; set; }

        [NotMapped]
        public string ShortPhotoName { get; set; }

    }
}
