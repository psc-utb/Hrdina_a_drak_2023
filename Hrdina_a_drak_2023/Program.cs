using Hrdina_a_drak_2023.Nabytek;
using Hrdina_a_drak_2023.Nahoda;
using Hrdina_a_drak_2023.Postavy;
using Hrdina_a_drak_2023.Rozhrani;
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

            INahodny nahodnyGenerator = Kostka.Instance;
            Hrdina hrdina = new Hrdina(100, mec, 10, "Geralt", nahodnyGenerator);
            Hrdina hrdina2 = new Hrdina(100, mec, 10, "Bilbo", nahodnyGenerator);
            Hrdina hrdina3 = new Hrdina(100, mec, 10, "Zabiják", nahodnyGenerator);
            Drak drak = new Drak(120, 15, "Šmak", nahodnyGenerator);
            Drak drak2 = new Drak(120, 15, "Alduin", nahodnyGenerator);
            Vlk vlk = new Vlk(50, 5, "Wolfie", nahodnyGenerator);


            List<Postava> postavy = new List<Postava>();
            postavy.Add(hrdina2);
            postavy.Add(drak);
            postavy.Add(hrdina);
            postavy.Add(drak2);
            postavy.Add(hrdina3);
            postavy.Add(vlk);

            //postavy.Sort();

            Bedna bedna = new Bedna(100);

            bool postavyZiji = true;
            while (postavyZiji)
            {
                for (int i = 0; i < postavy.Count; ++i)
                {
                    Postava postava = postavy[i];
                    if (postava.JeZiva())
                    {
                        double utokPostavy;
                        Postava oponent = postava.VyberOponenta(postavy);
                        if (oponent != null)
                        {
                            utokPostavy = postava.Utok(oponent);

                            string textKvypisu = $"{postava.Jmeno} zaútočil hodnotou: {utokPostavy}. {oponent.Jmeno} má {oponent.Zdravi} zdraví.";
                            Console.WriteLine(textKvypisu);

                            //utok na bednu
                            if(bedna.JeRozbita() == false)
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
                for (int i = 0; i < postavy.Count; ++i)
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
