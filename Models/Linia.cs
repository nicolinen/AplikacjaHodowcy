namespace AplikacjaHodowcy.Models
{
    public class Linia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(20)]
        [Display(Name = "Nazwa Linii")]
        public string Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(2000)]
        public string Description { get; set; }

    }
}
