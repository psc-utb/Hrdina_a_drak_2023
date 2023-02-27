using Hrdina_a_drak_2023.Postavy;
using Hrdina_a_drak_2023.Veci;
using System;
using System.Collections.Generic;
using System.IO;

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


            //try
            //{
            //    Hrdina hrdinaDocasny = new Hrdina(100, null);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            //Mec mec = new Mec("Excalibur", 25);
            //mec = new Mec("obyčejný meč", 20);
            //Hrdina hrdina = new Hrdina(100, mec, 10);
            //Drak drak = new Drak(120, 15);

            //using (StreamWriter streamWriter = File.CreateText("zaznam boje.txt"))
            //{
            //    while (hrdina.JeZiva() && drak.JeZiva())
            //    {
            //        double utokHrdiny = hrdina.Utok(drak);

            //        string textKvypisu = $"Hrdina zaútočil hodnotou: {utokHrdiny}. Drak má {drak.Zdravi} zdraví." + Environment.NewLine;
            //        Console.WriteLine(textKvypisu);
            //        streamWriter.WriteLine(textKvypisu);

            //        if (drak.JeZiva())
            //        {
            //            double utokDraka = drak.Utok(hrdina);

            //            textKvypisu = $"Drak zaútočil hodnotou: {utokDraka}. Hrdina má {hrdina.Zdravi} zdraví.";
            //            Console.WriteLine(textKvypisu);
            //            streamWriter.WriteLine(textKvypisu);
            //        }

            //        textKvypisu = Environment.NewLine + Environment.NewLine;
            //        Console.WriteLine(textKvypisu);
            //        streamWriter.WriteLine(textKvypisu);
            //    }
            //}




            Mec mec = new Mec("Excalibur", 25);
            mec = new Mec("obyčejný meč", 20);
            Hrdina hrdina = new Hrdina(100, mec, 10);
            Drak drak = new Drak(120, 15);

            List<Postava> postavy = new List<Postava>();
            postavy.Add(hrdina);
            postavy.Add(drak);

            bool postavyZiji = true;
            while (postavyZiji)
            {
                for (int i = 0; i < postavy.Count; ++i)
                {
                    Postava postava = postavy[i];
                    if (postava.JeZiva())
                    {
                        double utokPostavy;
                        Postava oponent;
                        if (postava is Hrdina hrd)
                        {
                            oponent = postavy[1];
                            utokPostavy = hrd.Utok(postavy[1]);
                        }
                        else
                        {
                            oponent = postavy[0];
                            utokPostavy = postava.Utok(postavy[0]);
                        }

                        string textKvypisu = $"Postava zaútočila hodnotou: {utokPostavy}. Oponent má {oponent.Zdravi} zdraví." + Environment.NewLine;
                        Console.WriteLine(textKvypisu);
                    }
                }

                int pocetZivychPostav = 0;
                for(int i = 0; i < postavy.Count; ++i)
                {
                    if (postavy[i].JeZiva())
                        pocetZivychPostav++;
                }
                if (pocetZivychPostav < 2)
                {
                    postavyZiji = false;
                }
            }

        }
    }
}
