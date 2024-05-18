using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.Models;

namespace AplikacjaHodowcy.Repositories
{
    public class LiniaRepository : ILiniaRepository
    {
        private readonly ApplicationDbContext _context;

        public LiniaRepository(ApplicationDbContext context)
        {
                _context = context;
        }

        public Linia GetById(int id)
        {
            return _context.Linie.FirstOrDefault( l => l.Id == id);
        }
        public void Add(Linia linia)
        {
            _context.Add(linia);
            _context.SaveChanges();
        }

        public void Delete(Linia linia)
        {
            _context.Remove(linia);
            _context.Attach(linia);
            _context.Entry(linia).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(Linia linia)
        {
            _context.Update(linia);
            _context.Attach(linia);
            _context.Entry(linia).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Linia> GetAllLinie()
        {
            return _context.Linie.ToList();
        }
        public Linia GetLinia(int id)
        {
            Linia linia;
            linia = _context.Linie.Where(l => l.Id == id).FirstOrDefault();
            return linia;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
