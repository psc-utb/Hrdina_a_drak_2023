using Hrdina_a_drak_2023.Nabytek;
using Hrdina_a_drak_2023.Postavy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Bojiste
{
    class Arena
    {
        public List<Postava> Postavy { get; set; }

        public Arena(List<Postava> postavy)
        {
            Postavy = postavy;
        }

        public void Boj()
        {
            Bedna bedna = new Bedna(100);

            bool postavyZiji = true;
            while (postavyZiji)
            {
                for (int i = 0; i < Postavy.Count; ++i)
                {
                    Postava postava = Postavy[i];
                    if (postava.JeZiva())
                    {
                        double utokPostavy;
                        Postava oponent = postava.VyberOponenta(Postavy);
                        //Postava oponent = postava.VyberOponenta(postavy, pos => pos.Zdravi > 0.1 * postava.Zdravi);
                        if (oponent != null)
                        {
                            utokPostavy = postava.Utok(oponent);

                            string textKvypisu = $"{postava.Jmeno} zaútočil hodnotou: {utokPostavy}. {oponent.Jmeno} má {oponent.Zdravi} zdraví.";
                            Console.WriteLine(textKvypisu);

                            //utok na bednu
                            if (bedna.JeRozbita() == false)
                            {
                                postava.Utok(bedna);
                                Console.WriteLine($"{postava.Jmeno} zaútočil na bednu.");

                                if (bedna.JeRozbita())
                                {
                                    postava.Zdravi += 20;
                                    Console.WriteLine($"{postava.Jmeno} rozbil bednu!");
                                }
                            }

                            Console.WriteLine(Environment.NewLine);
                        }
                    }
                }

                //zjisteni poctu zivych postav
                int pocetZivychPostav = 0;
                for (int i = 0; i < Postavy.Count; ++i)
                {
                    if (Postavy[i].JeZiva())
                        pocetZivychPostav++;
                }
                if (pocetZivychPostav < 2)
                {
                    postavyZiji = false;
                }
            }
        }

        public Task BojAsync()
        {
            return Task.Run(Boj);
        }
    }
}
