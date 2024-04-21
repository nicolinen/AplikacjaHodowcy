using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.Mappers;
using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaHodowcy.Services
{
    public class LiniaService : ILiniaService
    {
        private readonly ILiniaRepository _liniaRepository;

        public LiniaService(ILiniaRepository liniaRepository)
        {
            _liniaRepository = liniaRepository;
        }

        public IEnumerable<SelectListItem> GetLinie()
        {
            List<Linia> linie = _liniaRepository.GetAllLinie();

            var listaLinii = linie.Select(l => new SelectListItem
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

            return listaLinii;
        }
    }
}
