using AplikacjaHodowcy.Models;

namespace AplikacjaHodowcy.KonkursyFactory
{
    public class KonkursKrajowy : Konkurs
    {
        public override string KrajoweRegulacje
        { get => base.KrajoweRegulacje; 
          set => base.KrajoweRegulacje = value; 
        }
    }
}
