using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Veci
{
    class Mec
    {
        public string Nazev { get; set; }
        public double MaxUtok { get; set; }

        public Mec(string nazev, double maxUtok)
        {
            Nazev = nazev;
            MaxUtok = maxUtok;
        }
    }
}
