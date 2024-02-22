using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.Models;
using System;

namespace AplikacjaHodowcy.Controllers
{
    public class SzczeniakController : Controller
    {
        private ISzczeniakRepository _szczeniakRepository;

        public SzczeniakController(ISzczeniakRepository szczeniakRepository)
        {
            _szczeniakRepository = szczeniakRepository;
        }

        public IActionResult Index()
        {
            List<Szczeniak> szczeniaki = _szczeniakRepository.GetWithMiot();
            return View(szczeniaki);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Szczeniak Szczeniak = new Szczeniak();
            ViewBag.Linie = _szczeniakRepository.GetLinie();
            return View(Szczeniak);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Szczeniak szczeniak)
        {
            string uniqueFileName = _szczeniakRepository.GetPuppyPhotoFileName(szczeniak);
            szczeniak.PhotoUrl = uniqueFileName;

            _szczeniakRepository.Add(szczeniak);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Szczeniak szczeniak = _szczeniakRepository.GetByIdAndDetails(Id);
            return View(szczeniak);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Szczeniak szczeniak = _szczeniakRepository.GetByIdAndDetails(Id);

            szczeniak.LiniaId = szczeniak.Miot.LiniaId;

            ViewBag.Linie = _szczeniakRepository.GetLinie();
            ViewBag.Mioty = _szczeniakRepository.GetMioty(szczeniak.LiniaId);

            return View(szczeniak);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(int id, Szczeniak szczeniak)
        {
            if (szczeniak.PuppyPhoto != null)
            {
                string uniqueFileName = _szczeniakRepository.GetPuppyPhotoFileName(szczeniak);
                szczeniak.PhotoUrl = uniqueFileName;
            }

            _szczeniakRepository.Update(id, szczeniak);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Szczeniak szczeniak = _szczeniakRepository.GetByIdAndDetails(Id);


            // Wypełnij ukryte pola LiniaId i MiotId
            szczeniak.LiniaId = szczeniak.Miot?.LiniaId ?? 0;
            szczeniak.MiotId = szczeniak.Miot?.Id ?? 0;

            return View(szczeniak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Szczeniak szczeniak)
        {

            _szczeniakRepository.Delete(szczeniak);

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(int id)
        {
            // Przekierowanie do akcji SendMail
            return RedirectToAction("SendMail", "SendMailController");
        }

        [HttpGet]
        public IActionResult GetMiotyWgLinii(int liniaId)
        {
            var mioty = _szczeniakRepository.GetMiotyWgLinii(liniaId);
            return Json(mioty);
        }

    }
}
