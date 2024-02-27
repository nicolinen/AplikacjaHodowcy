﻿namespace AplikacjaHodowcy.Models
{
    public class Konkurs
    {
        [Key]
        public int Id { get; set; }
       // [Required]
        public string Type { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Desription { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        //[Required]
        [MaxLength(1000)]
        public string KrajoweRegulacje{ get; set; } // Dodaj właściwość dla krajowych regulacji
        //[Required]
        [MaxLength(50)]
        public string Kraj { get; set; } // Dodaj właściwość dla kraju
    }
}
