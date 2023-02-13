using Hrdina_a_drak_2023.Veci;
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

        public Mec Mec { get; set; }

        private Random nahodnyGenerator = new Random();

        public Hrdina(double zdravi, double maxUtok)
        {
            this.Zdravi = zdravi;
            this.MaxUtok = maxUtok;
        }

        /// <summary>
        /// Konstruktor pro vytvoření hrdiny s mečem
        /// </summary>
        /// <param name="zdravi">zdraví hrdiny</param>
        /// <param name="mec">meč hrdiny</param>
        /// <exception cref="Exception">Dojde k ní, když meč nebude nastavený</exception>
        public Hrdina(double zdravi, Mec mec)
        {
            this.Zdravi = zdravi;
            if (mec == null)
                throw new Exception("Meč nemůže být null!");
            this.Mec = mec;
        }

        public double Utok(Drak drak)
        {
            double utok;
            if (Mec != null)
                utok = nahodnyGenerator.NextDouble() * Mec.MaxUtok;
            else
                utok = nahodnyGenerator.NextDouble() * MaxUtok;

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
