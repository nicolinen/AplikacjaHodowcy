using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaHodowcy.Repositories
{
    public class SzczeniakRepository : ISzczeniakRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public SzczeniakRepository(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public Szczeniak GetById(int id)
        { 
        return _context.Szczeniaki.FirstOrDefault(x => x.Id == id);
        }

        public Szczeniak GetByIdAndDetails(int id)
        {
            return _context.Szczeniaki
                           .Include(sz => sz.Miot)
                               .ThenInclude(m => m.Linia)
                           .Where(sz => sz.Id == id)
                           .FirstOrDefault();
        }

        public void Add(Szczeniak szczeniak)
        {
            _context.Add(szczeniak);
            _context.SaveChanges();
        }

        public void Update(int id, Szczeniak szczeniak)
        {
            _context.Update(szczeniak);
            _context.Attach(szczeniak);
            _context.Entry(szczeniak).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Szczeniak szczeniak)
        {
            _context.Remove(szczeniak);
            _context.Attach(szczeniak);
            _context.Entry(szczeniak).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetMiotyWgLinii(int liniaId)
        {
            return _context.Mioty
                .Where(m => m.LiniaId == liniaId)
                .OrderBy(x => x.NazwaMiotu)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NazwaMiotu
                }).ToList();
        }

        public List<Szczeniak> GetWithMiot()
        {
            return _context.Szczeniaki.Include(m => m.Miot).ToList();
        }

        public string GetPuppyPhotoFileName(Szczeniak szczeniak)
        {
            string uniqueFileName = null;

            if (szczeniak.PuppyPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + szczeniak.PuppyPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    szczeniak.PuppyPhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        public List<SelectListItem> GetMioty(int liniaId)
        {
            List<SelectListItem> mioty = _context.Mioty
                .Where(m => m.LiniaId == liniaId)
                .OrderBy(n => n.NazwaMiotu)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.NazwaMiotu
                }).ToList();

            return mioty;
        }

        public List<SelectListItem> GetLinie()
        {
            var listaLinie = new List<SelectListItem>();
            List<Linia> Linie = _context.Linie.ToList();

            listaLinie = Linie.Select(l => new SelectListItem()
            {
                Value = l.Id.ToString(),
                Text = l.Nazwa
            }).ToList();

            var listaItem = new SelectListItem()
            {
                Value = "",
                Text = "----Wybierz Linie----"
            };

            listaLinie.Insert(0, listaItem);

            return listaLinie;
        }



    }
}
