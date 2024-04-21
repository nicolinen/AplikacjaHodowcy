using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace AplikacjaHodowcy.Repositories
{
    public interface IMiotRepository
    {
        Miot GetById(int id);
        void Add(Miot miot);
        void Update(Miot miot);
        void Delete(Miot miot);

        List<Miot> GetWithLinia();
        //List<SelectListItem> GetLinie();

        List<Miot> GetAll();
    }
}
