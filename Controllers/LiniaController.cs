using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.Mappers;
using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaHodowcy.Controllers
{
    public class LiniaController : Controller
    {
        private readonly ILiniaRepository _liniaRepository;
        private readonly LiniaMapper _liniaMapper;

        public LiniaController(ILiniaRepository liniaRepository, LiniaMapper liniaMapper)
        {
            _liniaRepository = liniaRepository;
            _liniaMapper = liniaMapper;
        }

        public IActionResult Index()
        {
            List<Linia> linie = _liniaRepository.GetAllLinie().OrderBy(l => l.Nazwa).ToList();
            IEnumerable<LiniaViewModel> linieViewModel = _liniaMapper.MapLinieToViewModels(linie);
            return View(linieViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            LiniaViewModel liniaViewModel = new LiniaViewModel();
            return View(liniaViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(LiniaViewModel liniaViewModel)
        {
            try
            {
                _liniaRepository.Add(liniaViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return View(liniaViewModel);
            }
            
        }

        [HttpGet]
        public IActionResult CreateModalForm()
       {
            LiniaViewModel liniaViewModel = new LiniaViewModel();
            return PartialView("_CreateModalForm", liniaViewModel);
        }

        [HttpPost]
        public IActionResult CreateModalForm(LiniaViewModel liniaViewModel)
        {
            _liniaRepository.Add(liniaViewModel);
            _liniaRepository.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Linia linia = _liniaRepository.GetLinia(Id);
            LiniaViewModel liniaViewModel = _liniaMapper.MapLinieToViewModels(new List<Linia> { linia }).FirstOrDefault();
            return View(liniaViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Linia linia = _liniaRepository.GetLinia(Id);
            LiniaViewModel liniaViewModel = _liniaMapper.MapLinieToViewModels(new List<Linia> { linia }).FirstOrDefault();
            return View(liniaViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(LiniaViewModel liniaViewModel)
        {
            try 
            {
                _liniaRepository.Update(liniaViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return View(liniaViewModel);
            }
            
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Linia linia = _liniaRepository.GetLinia(Id);
            LiniaViewModel liniaViewModel = _liniaMapper.MapLinieToViewModels(new List<Linia> { linia }).FirstOrDefault();
            return View(liniaViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(LiniaViewModel liniaViewModel)
        {
            try
            {
                Linia exisistingLinia = _liniaRepository.GetLinia(liniaViewModel.Id);
                _liniaRepository.Delete(exisistingLinia);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException.Message);
                return View(liniaViewModel);
            }    
        }

        //public JsonResult GetLinie()
        //{
        //    var listaLinii = new List<SelectListItem>();
        //    List<Linia> Linie = _liniaRepository.GetAllLinie();

        //    listaLinii = Linie.Select(l => new SelectListItem()
        //    {
        //        Value = l.Id.ToString(),
        //        Text = l.Nazwa
        //    }).ToList();

        //    var defItem = new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "----Wybierz Linię----"
        //    };

        //    listaLinii.Insert(0, defItem);

        //    return Json(listaLinii);
        //}
    }
}
