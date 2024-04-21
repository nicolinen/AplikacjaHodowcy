using AplikacjaHodowcy.Models;
using AplikacjaHodowcy.ViewModels;

namespace AplikacjaHodowcy.Mappers
{
    public class MiotMapper
    {
        public IEnumerable<MiotViewModel> MapMiotToViewModel(IEnumerable<Miot> mioty)
        {
            return mioty.Select(miot => new MiotViewModel
            {
                Id = miot.Id,
                ImieMatki = miot.ImieMatki,
                ImieOjca = miot.ImieOjca,
                OpisRodzicow = miot.OpisRodzicow,
                PhotoPath = miot.PhotoPath,
                NazwaMiotu = miot.NazwaMiotu,
                LiniaId = miot.LiniaId

            });
        }

        public Miot MapViewModelToMiot(MiotViewModel miotViewModel)
        {
            return new Miot
            {
                Id = miotViewModel.Id,
                ImieMatki = miotViewModel.ImieMatki,
                ImieOjca = miotViewModel.ImieOjca,
                OpisRodzicow = miotViewModel.OpisRodzicow,
                PhotoPath = miotViewModel.PhotoPath,
                NazwaMiotu = miotViewModel.NazwaMiotu,
                LiniaId = miotViewModel.LiniaId
            };
        }

    }
}
