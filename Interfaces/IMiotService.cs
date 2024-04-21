using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AplikacjaHodowcy.Interfaces
{
    public interface IMiotService
    {
        List<SelectListItem> GetLinie();
    }
}
