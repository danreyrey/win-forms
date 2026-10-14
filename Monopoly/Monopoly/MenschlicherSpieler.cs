using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class MenschlicherSpieler : Spieler, IWuerfel
    {
        public MenschlicherSpieler(string name, Color color) : base(name, color)
        {
        }
        public int[] Wurf() => new int[] { Form1.rnd.Next(1, 7), Form1.rnd.Next(1, 7) };
        
    }
}
