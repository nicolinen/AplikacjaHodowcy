using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace AplikacjaHodowcy.Controllers
{
    public class SzczeniakController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public SzczeniakController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            List<Szczeniak> Szczeniaki;
            Szczeniaki = _context.Szczeniaki.Include(s => s.Miot).ToList();
            return View(Szczeniaki);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Szczeniak Szczeniak = new Szczeniak();
            ViewBag.Linie = GetLinie();
            return View(Szczeniak);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Szczeniak szczeniak)
        {
            string uniqueFileName = GetPuppyPhotoFileName(szczeniak);
            szczeniak.PhotoUrl = uniqueFileName;

            _context.Add(szczeniak);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Szczeniak szczeniak = _context.Szczeniaki
                .Include(m => m.Miot)
                .Include(l => l.Miot.Linia)
                .Where(sz => sz.Id == Id).FirstOrDefault();

            return View(szczeniak);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Szczeniak szczeniak = _context.Szczeniaki
                .Include(sz => sz.Miot)
                .Where(s => s.Id == Id).FirstOrDefault();

            szczeniak.LiniaId = szczeniak.Miot.LiniaId;

            ViewBag.Linie = GetLinie();
            ViewBag.Mioty = GetMioty(szczeniak.LiniaId);

            return View(szczeniak);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(int id, Szczeniak szczeniak)
        {
            if (szczeniak.PuppyPhoto != null)
            {
                string uniqueFileName = GetPuppyPhotoFileName(szczeniak);
                szczeniak.PhotoUrl = uniqueFileName;
            }

            _context.Attach(szczeniak);
            _context.Entry(szczeniak).State = EntityState.Modified;
            //_context.Entry(szczeniak).State = EntityState.Modified;
            //_context.Entry(szczeniak.Miot).State = EntityState.Detached;
            //_context.Entry(szczeniak.Miot.Linia).State = EntityState.Detached;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Szczeniak szczeniak = _context.Szczeniaki
                .Include(s => s.Miot)
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            // Wypełnij ukryte pola LiniaId i MiotId
            szczeniak.LiniaId = szczeniak.Miot?.LiniaId ?? 0;
            szczeniak.MiotId = szczeniak.Miot?.Id ?? 0;

            return View(szczeniak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Szczeniak szczeniak)
        {
            // Usunięcie z bazy danych
            _context.Attach(szczeniak);
            _context.Entry(szczeniak).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(int id)
        {
            // Przekierowanie do akcji SendMail
            return RedirectToAction("SendMail", "SendMailController");
        }

        private List<SelectListItem> GetLinie()
        {
            var listaLinie = new List<SelectListItem>();
            List<Linia> Linie = _context.Linie.ToList();

            listaLinie = Linie.Select(l => new SelectListItem()
            {
                Value = l.Id.ToString(),
                Text = l.Nazwa
            }).ToList();

            var listaItem = new SelectListItem()
            {
                Value = "",
                Text = "----Wybierz Linie----"
            };

            listaLinie.Insert(0, listaItem);

            return listaLinie;
        }

        [HttpGet]
        public JsonResult GetMiotyWgLinii(int liniaId)
        {
            List<SelectListItem> mioty = _context.Mioty
                    .Where(m => m.LiniaId == liniaId)
                    .OrderBy(x => x.NazwaMiotu)
                    .Select(x =>
                    new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.NazwaMiotu
                    }).ToList();

            return Json(mioty);
        }

        private string GetPuppyPhotoFileName(Szczeniak szczeniak)
        {
            string uniqueFileName = null;

            if (szczeniak.PuppyPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + szczeniak.PuppyPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    szczeniak.PuppyPhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private List<SelectListItem> GetMioty(int liniaId)
        {
            List<SelectListItem> mioty = _context.Mioty
                .Where(m => m.LiniaId == liniaId)
                .OrderBy(n => n.NazwaMiotu)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.NazwaMiotu
                }).ToList();

            return mioty;
        }
    }
}
