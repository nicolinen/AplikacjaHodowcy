using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using AplikacjaHodowcy.Repositories;
using AplikacjaHodowcy.Mappers;
using AplikacjaHodowcy.ViewModels;
using AplikacjaHodowcy.Interfaces;

namespace Hodowla.Controllers
{
    public class MiotController : Controller
    {
        private readonly IMiotRepository _miotRepository;
        private readonly MiotMapper _miotMapper;
        private readonly IMiotService _miotService;

        public MiotController(IMiotRepository miotRepository, MiotMapper miotMapper, IMiotService miotService)
        {
            _miotRepository = miotRepository;
            _miotMapper = miotMapper;
            _miotService = miotService;
        }

        public IActionResult Index()
        {
            List<Miot> mioty = _miotRepository.GetWithLinia().OrderBy(x => x.LitterName).ToList();
            IEnumerable<MiotViewModel> miotyViewModel = _miotMapper.MapMiotToViewModel(mioty);
            return View(miotyViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Linie = _miotService.GetLinie();
            return View(new MiotViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(MiotViewModel miotViewModel)
        {
            if (ModelState.IsValid)
            {
                _miotRepository.Add(miotViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Linie = _miotService.GetLinie();
            return View(miotViewModel);

        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Miot miot = _miotRepository.GetById(Id);

            if (miot == null)
            {
                return NotFound();
            }

            MiotViewModel miotViewModel = _miotMapper.MapMiotToViewModel(new List<Miot> { miot }).FirstOrDefault(); // Mapuj pojedynczy obiekt Miot
            ViewBag.Linie = _miotService.GetLinie();
            return View(miotViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Miot miot = _miotRepository.GetById(Id);

            if (miot == null)
            {
                return NotFound();
            }

            MiotViewModel miotViewModel = _miotMapper.MapMiotToViewModel(new List<Miot> { miot }).FirstOrDefault(); // Mapuj pojedynczy obiekt Miot
            ViewBag.Linie = _miotService.GetLinie();
            return View(miotViewModel);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(MiotViewModel miotViewModel)
        {
            if (ModelState.IsValid)
            {
                Miot miot = _miotMapper.MapViewModelToMiot(miotViewModel);
                _miotRepository.Update(miot);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Linie = _miotService.GetLinie();
            return View(miotViewModel);
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Miot miot = _miotRepository.GetById(Id);
            if (miot == null)
            {
                return NotFound();
            }

            MiotViewModel miotViewModel = _miotMapper.MapMiotToViewModel(new List<Miot> { miot }).FirstOrDefault();
            return View(miotViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Miot Miot)
        {
                _miotRepository.Delete(Miot);
                return RedirectToAction(nameof(Index));
        }


    }
}