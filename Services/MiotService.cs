using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaHodowcy.Services
{
    public class MiotService : IMiotService
    {
        private readonly ILiniaRepository _liniaRepository;

        public MiotService(ILiniaRepository liniaRepository)
        {
            _liniaRepository = liniaRepository;
        }

        public List<SelectListItem> GetLinie()
        {
            var listaLinii = new List<SelectListItem>();

            List<Linia> linie = _liniaRepository.GetAllLinie();

            listaLinii = linie.Select(m => new SelectListItem()
            {
                Value = m.Id.ToString(),
                Text = m.Name
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
