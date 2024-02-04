using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaHodowcy.Controllers
{
    public class LiniaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LiniaController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Linia> linie;
            linie = _context.Linie.ToList();
            return View(linie);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            Linia linia = new Linia();
            return View(linia);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Linia linia)
        {
            _context.Add(linia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateModalForm()
        {
            Linia linia = new Linia();
            return PartialView("_CreateModalForm", linia);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Linia linia = GetLinia(Id);
            return View(linia);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Linia linia = GetLinia(Id);
            return View(linia);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Linia linia)
        {
            _context.Attach(linia);
            _context.Entry(linia).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private Linia GetLinia(int id)
        {
            Linia linia;
            linia = _context.Linie.Where(l => l.Id == id).FirstOrDefault();
            return linia;
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Linia linia = GetLinia(Id);
            return View(linia);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Linia linia)
        {
            try
            {
                _context.Attach(linia);
                _context.Entry(linia).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(linia).Reload();
                ModelState.AddModelError("", ex.InnerException.Message);
                return View(linia);
            }
            return RedirectToAction(nameof(Index));
        }




    }
}
