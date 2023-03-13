using Hrdina_a_drak_2023.Rozhrani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Nabytek
{
    class Bedna : IZasazitelny
    {
        public double Zdravi { get; set; }

        public Bedna(double zdravi)
        {
            Zdravi = zdravi;
        }

        public bool JeRozbita()
        {
            if (Zdravi <= 0)
                return true;
            else
                return false;
        }
    }
}
