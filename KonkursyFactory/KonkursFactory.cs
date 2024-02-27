using AplikacjaHodowcy.Data;
using AplikacjaHodowcy.KonkursyFactory.Interfaces;
using AplikacjaHodowcy.Models;

namespace AplikacjaHodowcy.KonkursyFactory
{
    public class KonkursFactory : IKonkursFactory
    {
        private readonly ApplicationDbContext _context;

        public KonkursFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Konkurs konkurs)
        {
            _context.Konkursy.Add(konkurs);
            _context.SaveChanges();
        }

        public void Update(Konkurs konkurs)
        {
            _context.Konkursy.Update(konkurs);
            _context.SaveChanges();
        }

        public void Delete(Konkurs konkurs)
        {
            _context.Konkursy.Remove(konkurs);
            _context.SaveChanges();
        }

        public Konkurs GetKonkurs(int id)
        {
            return _context.Konkursy.Find(id);
        }

        public List<Konkurs> GetAllKonkursy()
        {
            return _context.Konkursy.ToList();
        }

        //public Konkurs Create(int id, string type, string name, string desription, string photoPath)
        //{
        //    switch (type)
        //    {
        //        case "Krajowy":
        //            return new KonkursKrajowy { Id = id, Name = name, Desription = desription, PhotoPath = photoPath };
        //        case "Miedzynarodowy":
        //            return new KonkursMiedzynarodowy { Id = id, Name = name, Desription = desription, PhotoPath = photoPath };
        //        default:
        //            throw new ArgumentException("Nieznany typ konkursu.");
        //    }
        //}

        public Konkurs CreateKrajowy(string type, string name, string desription, string photoPath, string krajoweRegulacje)
        {
            if (type != "Krajowy")
            {
                throw new ArgumentException("Niepoprawny typ konkursu.");
            }

            return new KonkursKrajowy
            {
                Type = type,
                Name = name,
                Desription = desription,
                PhotoPath = photoPath,
                KrajoweRegulacje = krajoweRegulacje
            };
        }

        public Konkurs CreateMiedzynarodowy(string type, string name, string desription, string photoPath, string kraj)
        {
            if (type != "Miedzynarodowy")
            {
                throw new ArgumentException("Niepoprawny typ konkursu.");
            }

            return new KonkursMiedzynarodowy
            {
                Type = type,
                Name = name,
                Desription = desription,
                PhotoPath = photoPath,
                Kraj = kraj
            };
        }
    }
}
