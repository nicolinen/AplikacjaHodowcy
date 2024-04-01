namespace AplikacjaHodowcy.Models
{
    public class SendMail
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string From { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string To { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Body { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Password { get; set; }
    }
}
