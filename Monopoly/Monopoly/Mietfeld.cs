using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Mietfeld : Feld
    {
        public int KaufwertOrg {  get; }
        public int KaufwertNeu { get; set; }
        public Spieler Besitzer { get; set; }
        public bool IsAufHypothek { get; set; }

        int BerechneHypothek(int KaufwertOrg)
        {
            return (int)(KaufwertOrg * 0.5);
        }
        public abstract int BerechneMiete();
    }
}
