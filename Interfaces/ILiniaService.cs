using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaHodowcy.Interfaces
{
    public interface ILiniaService
    {
        IEnumerable<SelectListItem> GetLinie();
    }
}
