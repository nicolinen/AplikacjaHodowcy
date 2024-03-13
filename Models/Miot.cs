namespace AplikacjaHodowcy.Models
{
    public class Miot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Imię Matki")]
        public string ImieMatki { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Imię Ojca")]
        public string ImieOjca { get; set; }

        [MaxLength(5000)]
        [Display(Name = "O rodzicach")]
        public string OpisRodzicow { get; set; }

        [Required]
        public string PhotoPath { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Nazwa Miotu")]
        public string NazwaMiotu { get; set; }

        [ForeignKey("LiniaId")]
        public int LiniaId { get; set; }

        public virtual Linia Linia { get; set; }

    }

}
