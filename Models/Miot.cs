namespace AplikacjaHodowcy.Models
{
    public class Miot
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(30)]
        [Display(Name = "Imię Matki")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(30)]
        [Display(Name = "Imię Ojca")]
        public string FatherName { get; set; }

        [MaxLength(5000)]
        [Display(Name = "O rodzicach")]
        public string ParentsDesc { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(30)]
        [Display(Name = "Nazwa Miotu")]
        public string LitterName { get; set; }

        [Display(Name = "Linia")]
        [ForeignKey("Linia")]
        public int LiniaId { get; set; }

        public virtual Linia Linia { get; set; }

    }

}
