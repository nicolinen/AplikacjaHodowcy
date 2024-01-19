using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Hodowla.Controllers
{
    public class MiotController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiotController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Miot> Mioty;
            Mioty = _context.Mioty.ToList();
            return View(Mioty);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Miot Miot = new Miot();
            ViewBag.Linie = GetLinie();
            return View(Miot);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Miot Miot)
        {
            _context.Add(Miot);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Miot Miot = _context.Mioty.Where(m => m.Id == Id).FirstOrDefault();

            return View(Miot);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Miot Miot = _context.Mioty.Where(m => m.Id == Id).FirstOrDefault();

            ViewBag.Linie = GetLinie();
            return View(Miot);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Miot Miot)
        {
            _context.Attach(Miot);
            _context.Entry(Miot).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Miot Miot = _context.Mioty.Where(m => m.Id == Id).FirstOrDefault();

            return View(Miot);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Miot Miot)
        {
            _context.Attach(Miot);
            _context.Entry(Miot).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetLinie()
        {
            var listaLinii = new List<SelectListItem>();

            List<Linia> Linie = _context.Linie.ToList();

            listaLinii = Linie.Select(lm => new SelectListItem()
            {
                Value = lm.Id.ToString(),
                Text = lm.Nazwa
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Wybierz linię----"
            };

            listaLinii.Insert(0, defItem);

            return listaLinii;
        }
    }
}