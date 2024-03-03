namespace AplikacjaHodowcy.Models
{
    public class Linia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Nazwa Linii")]
        public string Nazwa { get; set; }

        [Required]
        [MaxLength(50)]
        public string Opis { get; set; }

    }
}
