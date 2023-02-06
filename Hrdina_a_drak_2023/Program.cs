using Hrdina_a_drak_2023.Postavy;
using System;

namespace Hrdina_a_drak_2023
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hrdina hrdina = new Hrdina();
            //hrdina.Zdravi = 2000;
            //Console.WriteLine(hrdina.Zdravi);
            //hrdina.Zdravi = 1000;
            //Console.WriteLine(hrdina.Zdravi);

            Hrdina hrdina = new Hrdina();
            hrdina.Zdravi = 100;
            hrdina.MaxUtok = 20;
            Drak drak = new Drak();
            drak.Zdravi = 120;
            drak.MaxUtok = 15;

            while (hrdina.JeZiva() && drak.JeZiva())
            {
                double utokHrdiny = hrdina.Utok(drak);
                Console.WriteLine($"Hrdina zaútočil hodnotou: {utokHrdiny}. Drak má {drak.Zdravi} zdraví." + Environment.NewLine);

                if (drak.JeZiva())
                {
                    double utokDraka = drak.Utok(hrdina);
                    Console.WriteLine($"Drak zaútočil hodnotou: {utokDraka}. Hrdina má {hrdina.Zdravi} zdraví.");
                }
                Console.WriteLine(Environment.NewLine + Environment.NewLine);
            }

        }
    }
}
