using System.Xml.Linq;

namespace AplikacjaHodowcy.Models
{
    public class Szczeniak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data narodzin")]
        public DateTime BirthDate { get; set; } = new DateTime(2022, 1, 1);

        [Required]
        [NotMapped]
        [Display(Name = "Nazwa Linii")]
        public int LiniaId { get; set; }

        [Required]
        [ForeignKey("Miot")]
        [DisplayName("Miot")]
        public int MiotId { get; set; }
        public virtual Miot Miot { get; set; }

        [Required(ErrorMessage = "Proszę dodac zdjecie szczeniaka")]
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
