using AplikacjaHodowcy.Models;

using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.Net;
using System.Net.Mail;

namespace AplikacjaHodowcy.Controllers
{
    public class SendMailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(SendMail sendMail)
        {
            if (!ModelState.IsValid) return View(sendMail);

            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = sendMail.Subject;
                mail.From = new MailAddress(sendMail.From);
                mail.To.Add(sendMail.To);
                mail.IsBodyHtml = true;
                mail.Body = sendMail.Body;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(sendMail.From, sendMail.Password);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }

                ViewBag.Message = "Mail sent successfully";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error sending email: {ex.Message}";
            }

            return View();
        }
    }
}
