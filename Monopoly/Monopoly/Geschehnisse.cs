using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Geschehnisse : Feld
    {
        public List<Ereignis> Ereignis {  get; set; }
        public List<Ereignis> Gemeinschaft { get; set; }
    }
}
