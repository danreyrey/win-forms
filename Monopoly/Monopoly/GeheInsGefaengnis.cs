using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GeheInsGefaengnis : Feld
    {
        public bool GeheInDenKnast(Spieler spieler)
        {
            return spieler.ImGefaengnis;
        }
    }
}