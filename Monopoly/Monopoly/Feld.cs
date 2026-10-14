using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Feld
    {
        public int Number {  get; set; }
        public string Type { get; set; }
        public Color? Color { get; set; }
        public string Name { get; set; }
        public Spieler[]? BesetztVon {  get; }
        public int[] Location { get; set; }
        public void SetLocation()
        {
            int x = 0;
            int y = 0;
            Location = new int[2];
            int stepsInPixel = (Number % 10) * 1000 / 11;
            if (Number >= 0 &&  Number <= 9)
            {
                x = 1000 - stepsInPixel;
                y = 1000;

            }
            else if(Number <= 19)
            {
                x = 0;
                y = 1000 - stepsInPixel;
            }
            else if(Number <= 29)
            {
                x = 0 + stepsInPixel;
                y = 0;
            }
            else
            {
                x = 1000;
                y = 0 + stepsInPixel;
            }
            Location[0] = x;
            Location[1] = y;
        }

    }
}