using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.ViewModels;

namespace AplikacjaHodowcy.Mappers
{
    public class LiniaMapper
    {
        public IEnumerable<LiniaViewModel> MapLinieToViewModels(IEnumerable<Linia> linie)
        {
            return linie.Select(linia => new LiniaViewModel
            {
                Id = linia.Id,
                Name = linia.Name,
                Description = linia.Description
                // Tutaj możesz mapować inne właściwości z Linia, jeśli są potrzebne w LiniaViewModel
            });
        }
    }
}
