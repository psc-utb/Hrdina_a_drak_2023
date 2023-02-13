using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Postavy
{
    class Drak
    {
        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double MaxUtok { get; set; }
        public double MaxObrana { get; set; }

        private Random nahodnyGenerator = new Random();

        public Drak(double zdravi, double maxUtok)
        {
            this.Zdravi = zdravi;
            this.MaxUtok = maxUtok;
        }

        public double Utok(Hrdina hrdina)
        {
            double utok = nahodnyGenerator.NextDouble() * MaxUtok;
            hrdina.Zdravi -= utok;
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
