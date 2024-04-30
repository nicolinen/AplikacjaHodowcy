using AplikacjaHodowcy.Models;

namespace AplikacjaHodowcy.KonkursyFactory
{
    public class KonkursKrajowy : Konkurs
    {
        public override string DomesticRegulations
        { get => base.DomesticRegulations; 
          set => base.DomesticRegulations = value; 
        }
    }
}
