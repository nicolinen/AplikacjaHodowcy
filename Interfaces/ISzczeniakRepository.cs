using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaHodowcy.Interfaces
{
    public interface ISzczeniakRepository
    {
        Szczeniak GetById(int id);
        Szczeniak GetByIdAndDetails(int id);
        void Add(Szczeniak szczeniak);
        void Update(int id, Szczeniak szczeniak);
        void Delete(Szczeniak szczeniak);
        IEnumerable<SelectListItem> GetMiotyWgLinii(int liniaId);
        string GetPuppyPhotoFileName(Szczeniak szczeniak);
        List<SelectListItem> GetMioty(int liniaId);
        List<SelectListItem> GetLinie();

        List<Szczeniak> GetWithMiot();

    }
}
