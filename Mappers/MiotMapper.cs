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
                MotherName = miot.MotherName,
                FatherName = miot.FatherName,
                ParentsDesc = miot.ParentsDesc,
                PhotoPath = miot.PhotoPath,
                LitterName = miot.LitterName,
                LiniaId = miot.LiniaId

            });
        }

        public Miot MapViewModelToMiot(MiotViewModel miotViewModel)
        {
            return new Miot
            {
                Id = miotViewModel.Id,
                MotherName = miotViewModel.MotherName,
                FatherName = miotViewModel.FatherName,
                ParentsDesc = miotViewModel.ParentsDesc,
                PhotoPath = miotViewModel.PhotoPath,
                LitterName = miotViewModel.LitterName,
                LiniaId = miotViewModel.LiniaId
            };
        }

    }
}
