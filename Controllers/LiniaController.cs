using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaHodowcy.Controllers
{
    public class LiniaController : Controller
    {
        private readonly ILiniaRepository _liniaRepository;

        public LiniaController(ILiniaRepository liniaRepository)
        {
            _liniaRepository = liniaRepository;
        }

        public IActionResult Index()
        {
            List<Linia> linie = _liniaRepository.GetAllLinie();
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
            try
            {
                _liniaRepository.Add(linia);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return View(linia);
            }
            
        }

        [HttpGet]
        public IActionResult CreateModalForm()
       {
            Linia linia = new Linia();
            return PartialView("_CreateModalForm", linia);
        }

        [HttpPost]
        public IActionResult CreateModalForm(Linia linia)
        {
            _liniaRepository.Add(linia);
            _liniaRepository.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Linia linia = _liniaRepository.GetLinia(Id);
            return View(linia);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Linia linia = _liniaRepository.GetLinia(Id);
            return View(linia);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Linia linia)
        {
            try 
            {
                _liniaRepository.Update(linia);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return View(linia);
            }
            
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Linia linia = _liniaRepository.GetLinia(Id);
            return View(linia);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Linia linia)
        {
            try
            {
                Linia exisistingLinia = _liniaRepository.GetLinia(linia.Id);
                _liniaRepository.Delete(exisistingLinia);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException.Message);
                return View(linia);
            }    
        }

        public JsonResult GetLinie()
        {
            var listaLinii = new List<SelectListItem>();
            List<Linia> Linie = _liniaRepository.GetAllLinie();

            listaLinii = Linie.Select(l => new SelectListItem()
            {
                Value = l.Id.ToString(),
                Text = l.Nazwa
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Wybierz Linię----"
            };

            listaLinii.Insert(0, defItem);

            return Json(listaLinii);
        }
    }
}
