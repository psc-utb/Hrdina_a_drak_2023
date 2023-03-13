using Hrdina_a_drak_2023.Rozhrani;
using Hrdina_a_drak_2023.Veci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Postavy
{
    class Hrdina : Postava
    {
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

        public Mec Mec { get; set; }

        
        public Hrdina(double zdravi, double maxUtok) : base(zdravi, maxUtok)
        {
        }

        /// <summary>
        /// Konstruktor pro vytvoření hrdiny s mečem
        /// </summary>
        /// <param name="zdravi">zdraví hrdiny</param>
        /// <param name="mec">meč hrdiny</param>
        /// <exception cref="Exception">Dojde k ní, když meč nebude nastavený</exception>
        public Hrdina(double zdravi, Mec mec, double maxUtok, string jmeno) : base(zdravi, maxUtok, jmeno)
        {
            if (mec == null)
                throw new Exception("Meč nemůže být null!");
            this.Mec = mec;
        }

        public override double Utok(IZasazitelny zasazitelnyObjekt)
        {
            double utok;
            if (Mec != null)
                utok = nahodnyGenerator.NextDouble() * Mec.MaxUtok;
            else
                return base.Utok(zasazitelnyObjekt);

            zasazitelnyObjekt.Zdravi -= utok;
            return utok;
        }

    }
}
