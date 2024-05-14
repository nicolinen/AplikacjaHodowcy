using AplikacjaHodowcy.Models;

namespace AplikacjaHodowcy.KonkursyFactory
{
    public class KonkursMiedzynarodowy : Konkurs
    {
        public string Kraj 
        { 
            get => base.Kraj; 
            set => base.Kraj = value; 
        }

        public static List<string> Kraje = new List<string>
        {
            "Niemcy",
            "Austria",
            "Czechy",
            "Słowacja",
            "Włochy",
            "Szwecja",
            "Norwegia",
        };

        public bool CheckKraj()
        {
            return Kraje.Contains(Kraj, StringComparer.OrdinalIgnoreCase);
        }
    }
}
