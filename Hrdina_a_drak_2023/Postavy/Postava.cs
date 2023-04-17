using Hrdina_a_drak_2023.Nahoda;
using Hrdina_a_drak_2023.Rozhrani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Postavy
{
    class Postava : IZasazitelny
    {
        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double MaxUtok { get; set; }
        public double MaxObrana { get; set; }

        protected INahodny nahodnyGenerator;

        private Postava oponentPredchozi = null;
        public event Action<Postava, Postava> VyberNovehoOponenta;

        public Postava(double zdravi, double maxUtok, INahodny nahodny)
        {
            this.Zdravi = zdravi;
            this.MaxUtok = maxUtok;
            this.nahodnyGenerator = nahodny;
        }

        public Postava(double zdravi, double maxUtok, string jmeno, INahodny nahodny) : this(zdravi, maxUtok, nahodny)
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
                    if (postava != oponentPredchozi)
                    {
                        oponentPredchozi = postava;
                        if(VyberNovehoOponenta != null)
                            VyberNovehoOponenta(this, postava);
                    }
                    return postava;
                }
            }

            return null;
        }

        public virtual double Utok(IZasazitelny zasazitelnyObjekt)
        {
            double utok = nahodnyGenerator.NextDouble() * MaxUtok;
            zasazitelnyObjekt.Zdravi -= utok;

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
