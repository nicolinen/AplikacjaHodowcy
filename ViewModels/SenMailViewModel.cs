namespace AplikacjaHodowcy.ViewModels
{
    public class SenMailViewModel
    {
        [Display(Name = "Nadawca")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string From { get; set; }

        [Display(Name = "Odbiorca")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string To { get; set; }

        [Display(Name = "Temat wiadomości")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Subject { get; set; }

        [Display(Name = "Treść wiadomości")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Body { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Password { get; set; }
    }
}
