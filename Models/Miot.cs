namespace AplikacjaHodowcy.Models
{
    public class Miot
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(30)]
        [Display(Name = "Imię Matki")]
        public string ImieMatki { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(30)]
        [Display(Name = "Imię Ojca")]
        public string ImieOjca { get; set; }

        [MaxLength(5000)]
        [Display(Name = "O rodzicach")]
        public string OpisRodzicow { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(30)]
        [Display(Name = "Nazwa Miotu")]
        public string NazwaMiotu { get; set; }

        [Display(Name = "Linia")]
        [ForeignKey("Linia")]
        public int LiniaId { get; set; }

        public virtual Linia Linia { get; set; }

    }

}
