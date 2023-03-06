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

        public Postava(double zdravi, double maxUtok, string jmeno) : this(zdravi, maxUtok)
        {
            this.Jmeno = jmeno;
        }

        public Postava VyberOponenta(List<Postava> postavy)
        {
            foreach(var postava in postavy)
            {
                if (postava != null && postava != this
                    && postava.JeZiva())
                {
                    return postava;
                }
            }

            return null;
        }

        public virtual double Utok(Postava postava)
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
