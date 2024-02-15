using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaHodowcy.Repositories
{
    public class MiotRepository : IMiotRepository
    {
        private readonly ApplicationDbContext _context;

        public MiotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Miot GetById(int id)
        {
            return _context.Mioty.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Miot miot)
        {
            _context.Add(miot);
            _context.SaveChanges();
        }

        public void Delete(Miot miot)
        {
            _context.Remove(miot);
            _context.Attach(miot);
            _context.Entry(miot).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(Miot miot)
        {
            _context.Update(miot);
            _context.Attach(miot);
            _context.Entry(miot).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Miot> GetWithLinia()
        {
            return _context.Mioty.Include(l => l.Linia).ToList();
        }

        public List<SelectListItem> GetLinie()
        {
            var listaLinii = new List<SelectListItem>();

            List<Linia> Linie = _context.Linie.ToList();

            listaLinii = Linie.Select(lm => new SelectListItem()
            {
                Value = lm.Id.ToString(),
                Text = lm.Nazwa
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Wybierz linię----"
            };

            listaLinii.Insert(0, defItem);

            return listaLinii;
        }
    }
}
