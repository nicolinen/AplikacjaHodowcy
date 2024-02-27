using AplikacjaHodowcy.Models;

namespace AplikacjaHodowcy.KonkursyFactory.Interfaces
{
    public interface IKonkursFactory
    {
        //Konkurs Create(int id, string type, string name, string description, string photoPath);
        List<Konkurs> GetAllKonkursy();
        void Add(Konkurs konkurs);
        void Update(Konkurs konkurs);
        void Delete(Konkurs konkurs);
        Konkurs GetKonkurs(int id);
        Konkurs CreateKrajowy(string type, string name, string desription, string photoPath, string krajoweRegulacje);
        Konkurs CreateMiedzynarodowy(string type, string name, string desription, string photoPath, string krajoweRegulacje);
    }
}
