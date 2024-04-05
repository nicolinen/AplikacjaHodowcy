using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.KonkursyFactory.Interfaces;
using AplikacjaHodowcy.KonkursyFactory;

namespace AplikacjaHodowcy.Controllers
{
    public class KonkursController : Controller
    {
        private readonly IKonkursFactory _konkursFactory;

        public KonkursController(IKonkursFactory konkursFactory)
        {
            _konkursFactory = konkursFactory;
        }

        public IActionResult Index()
        {
            List<Konkurs> konkursy = _konkursFactory.GetAllKonkursy();
            return View(konkursy);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var konkurs = new Konkurs();
            return View(konkurs);
        }

        [HttpPost]
        public IActionResult Create(Konkurs konkurs)
        {
            if (!ModelState.IsValid)
            {
                return View(konkurs);
            }

            if (konkurs.Type == "Krajowa")
            {
                var konkursF = _konkursFactory.CreateKrajowy(konkurs.Type, konkurs.Name, konkurs.Desription, konkurs.PhotoPath, konkurs.KrajoweRegulacje);
                _konkursFactory.Add(konkursF);
            }
            else if (konkurs.Type == "Miedzynarodowa")
            {
                var konkursF = _konkursFactory.CreateMiedzynarodowy(konkurs.Type, konkurs.Name, konkurs.Desription, konkurs.PhotoPath, konkurs.Kraj);
                var kMiedzynarodowy = konkursF as KonkursMiedzynarodowy;
                if (kMiedzynarodowy != null && !kMiedzynarodowy.CheckKraj())
                {
                    ModelState.AddModelError("PhotoPath", "Wybrany kraj nie jest dostepny");
                    return View(konkurs);
                }
                _konkursFactory.Add(konkursF);
            }
            else
            {
                return BadRequest("Nieznany typ konkursu.");
            }

            return RedirectToAction(nameof(Index));
        }


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    Konkurs konkurs = new Konkurs();
        //    return View(konkurs);
        //}

        //[HttpPost]
        //public IActionResult Create(Konkurs konkurs)
        //{
        //    try
        //    {
        //        _konkursFactory.Add(konkurs);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
        //        return View(konkurs);
        //    }
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Konkurs konkurs = _konkursFactory.GetKonkurs(id);
            return View(konkurs);
        }

        [HttpPost]
        public IActionResult Edit(Konkurs konkurs)
        {
            try
            {
                _konkursFactory.Update(konkurs);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return View(konkurs);
            }
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Konkurs konkurs = _konkursFactory.GetKonkurs(Id);
            return View(konkurs);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Konkurs konkurs = _konkursFactory.GetKonkurs(id);
            return View(konkurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Konkurs konkurs)
        {
            try
            {
                Konkurs existingKonkurs = _konkursFactory.GetKonkurs(konkurs.Id);
                _konkursFactory.Delete(existingKonkurs);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                return View(konkurs);
            }
        }
    }
}
