using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Postavy
{
    class Hrdina
    {
        public string Jmeno { get; set; }
        /*private int zdravi;
        public int Zdravi
        {
            get { return zdravi; }
            set {
                if (value > 100)
                {
                    value = 100;
                }
                zdravi = value;
            }
        }*/
        public double Zdravi { get; set; }
        public double MaxUtok { get; set; }
        public double MaxObrana { get; set; }

        private Random nahodnyGenerator = new Random();
        public double Utok(Drak drak)
        {
            double utok = nahodnyGenerator.NextDouble() * MaxUtok;
            drak.Zdravi -= utok;
            return utok;
        }

        public bool JeZiva()
        {
            if (Zdravi > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
