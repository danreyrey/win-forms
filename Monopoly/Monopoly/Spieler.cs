using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Spieler
    {
        public Spieler(string name, Color color) 
        {
            Position = 0;
            Immobilien = new Mietfeld[0];
            Geld = 1500;
            ImGefaengnis = false;
            KommAusDemGefaengnisFrei = 0;
            Name = name;
            Color = color;
        }
        public Spieler()
        {
            Name = "Bank";
            Geld = Int32.MaxValue - 1000000000;
            int streets = 0;
            foreach(Feld d in Form1.fields)
            {
                if (d is Mietfeld)
                {
                    streets++;
                }
            }
            Immobilien = new Mietfeld[streets];
            int counter = 0;
            for (int i = 0; i < Form1.fields.Count; i++)
            {
                if(Form1.fields[i] is Mietfeld)
                {
                    Immobilien[counter++] = (Mietfeld)Form1.fields[i];
                }  
            }
        }

        public Mietfeld[]? Immobilien {  get; set; }
        public string? Name { get; set; }
        public int Geld { get; set; }
        public bool ImGefaengnis { get; set; }
        public int KommAusDemGefaengnisFrei { get; set; }
        public int Position {  get; set; }
        public Color Color { get; set; }
    }
}