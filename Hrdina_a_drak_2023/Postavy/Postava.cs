using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Postavy
{
    class Postava
    {
        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double MaxUtok { get; set; }
        public double MaxObrana { get; set; }

        protected Random nahodnyGenerator = new Random();

        public Postava(double zdravi, double maxUtok)
        {
            this.Zdravi = zdravi;
            this.MaxUtok = maxUtok;
        }

        public double Utok(Postava postava)
        {
            double utok = nahodnyGenerator.NextDouble() * MaxUtok;
            postava.Zdravi -= utok;
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
