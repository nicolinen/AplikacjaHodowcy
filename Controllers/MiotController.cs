using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using AplikacjaHodowcy.Repositories;

namespace Hodowla.Controllers
{
    public class MiotController : Controller
    {
        private readonly IMiotRepository _miotRepository;

        public MiotController(IMiotRepository miotRepository)
        {
            _miotRepository = miotRepository;
        }

        public IActionResult Index()
        {
            List<Miot> mioty = _miotRepository.GetWithLinia();
            return View(mioty);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Miot Miot = new Miot();
            ViewBag.Linie = _miotRepository.GetLinie();
            return View(Miot);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Miot Miot)
        {
            if (ModelState.IsValid)
            {
                _miotRepository.Add(Miot);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Linie = _miotRepository.GetLinie();
            return View(Miot);

        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Miot Miot = _miotRepository.GetById(Id);
            
            if (Miot == null)
            {
                return NotFound();
            }

            return View(Miot);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Miot Miot = _miotRepository.GetById(Id);

            if (Miot == null)
            {
                return NotFound();
            }
            ViewBag.Linie = _miotRepository.GetLinie();
            return View(Miot);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Miot Miot)
        {
            if(ModelState.IsValid)
            {

                _miotRepository.Update(Miot);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Linie =  _miotRepository.GetLinie();
            return View(Miot);
            
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Miot Miot = _miotRepository.GetById(Id);
            if (Miot == null)
            {
                return NotFound();
            }
            return View(Miot);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Miot Miot)
        {
            if (ModelState.IsValid)
            {
                _miotRepository.Delete(Miot);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Linie = _miotRepository.GetLinie();
            return View(Miot);
        }


    }
}