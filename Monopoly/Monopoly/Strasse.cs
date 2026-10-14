using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class Strasse : Mietfeld
    {
        int AnzahlHaus {  get; set; }
        public override int BerechneMiete()
        {
            switch(this.AnzahlHaus)
            {
                case 0:
                    return (int)(this.KaufwertOrg * 0.1);
                case 1:
                    return (int)(this.KaufwertOrg * 0.3);
                case 2:
                    return (int)(this.KaufwertOrg * 1);
                case 3:
                    return (int)(this.KaufwertOrg * 1.2);
                case 4:
                    return (int)(this.KaufwertOrg * 1.5);
                case 5:
                    return (int)(this.KaufwertOrg * 2);
                default:
                    break;
            }
            return 0;
        }
    }
}
