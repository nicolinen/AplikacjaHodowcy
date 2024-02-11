namespace AplikacjaHodowcy.Models
{
    public class SendMail
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
