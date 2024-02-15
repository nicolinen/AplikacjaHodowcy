using AplikacjaHodowcy.Models;

namespace AplikacjaHodowcy.Interfaces
{
    public interface ILiniaRepository
    {
        Linia GetById(int id);
        void Add(Linia linia);
        void Update(Linia linia);
        void Delete(Linia linia);
        //IActionResult CreateModalForm();
        List<Linia> GetAllLinie();
        Linia GetLinia(int id);
    }
}
