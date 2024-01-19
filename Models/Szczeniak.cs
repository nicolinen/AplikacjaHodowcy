namespace AplikacjaHodowcy.Models
{
    public class Szczeniak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Linia")]
        [NotMapped]
        public int LiniaId { get; set; }

        [Required]
        [ForeignKey("Miot")]
        [DisplayName("Miot")]
        public int MiotId { get; set; }
        public virtual Miot Miot { get; set; }

        [Required(ErrorMessage = "Proszę dodac zdjecie szczeniaka")]
        [MaxLength(500)]
        public string PhotoUrl { get; set; }

        [Display(Name = "Zdjecie szczeniaka")]
        [NotMapped]
        public IFormFile PuppyPhoto { get; set; }

        [NotMapped]
        public string ShortPhotoName { get; set; }

    }
}
