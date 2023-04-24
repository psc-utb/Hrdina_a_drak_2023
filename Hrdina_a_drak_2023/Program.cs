using Hrdina_a_drak_2023.Bojiste;
using Hrdina_a_drak_2023.Nabytek;
using Hrdina_a_drak_2023.Nahoda;
using Hrdina_a_drak_2023.Postavy;
using Hrdina_a_drak_2023.Rozhrani;
using Hrdina_a_drak_2023.Veci;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023
{
    class Program
    {
        static async Task Main(string[] args)
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



            //List postav -> dynamicke pole: je mozne pridavat, vkladat, mazat data a pristupovat na konkretni pozici pole (skrz index).
            List<Postava> postavy = new List<Postava>();
            postavy.Add(hrdina2);
            postavy.Add(drak);
            postavy.Add(hrdina);
            postavy.Add(drak2);
            postavy.Add(hrdina3);
            postavy.Add(vlk);
            //postavy.Insert(2, hrdina);
            //postavy.RemoveAt(2);

            //lambda vyrazy
            double prumernyUtok = postavy.Average(pos => pos.MaxUtok);
            Console.WriteLine($"Průměrný útok postav je: {prumernyUtok} - polovina je: {prumernyUtok / 2}");

            List<Postava> postavyPrumernyUtok = postavy.FindAll(pos => pos.MaxUtok >= (prumernyUtok / 2));

            postavyPrumernyUtok.ForEach(pos => Console.WriteLine($"Nadprůměrná postava: {pos.Jmeno} s útokem: {pos.MaxUtok}"));


            //napojeni eventu
            foreach(Postava postava in postavy)
            {
                postava.VyberNovehoOponenta += VypisVyberuOponenta;
            }


            //Dictionary s klicem typu string a postavami: je mozne pridavat prvky jen s klicem, rychle vyhledani prvku pomoci klice
            Dictionary<string, Postava> dictionaryPostav = new Dictionary<string, Postava>();
            //pridani hrdiny do Dictionary na pozici klice "aaa"
            dictionaryPostav["aaa"] = hrdina;
            //vyber postavy na pozici klice "aaa"
            Postava postavaZDictionary = dictionaryPostav["aaa"];
            //vypis vybrane postavy z dictionary
            Console.WriteLine(postavaZDictionary.Jmeno);

            dictionaryPostav["aaa"] = hrdina3;
            Console.WriteLine(dictionaryPostav["aaa"].Jmeno);

            dictionaryPostav.Add("bbb", drak2);

            dictionaryPostav[hrdina2.Jmeno] = hrdina2;
            Console.WriteLine(dictionaryPostav[hrdina2.Jmeno].Jmeno);

            Dictionary<int, Postava> dictionaryInt = new Dictionary<int, Postava>();
            dictionaryInt[100] = hrdina;
            dictionaryInt[541564] = drak;



            //postavy.Sort();


            //Arena arena = new Arena(postavy);
            //arena.Boj();

            List<Postava> postavyArena1 = new List<Postava>();
            postavyArena1.Add(hrdina);
            postavyArena1.Add(hrdina2);
            postavyArena1.Add(hrdina3);


            List<Postava> postavyArena2 = new List<Postava>();
            postavyArena2.Add(drak);
            postavyArena2.Add(drak2);
            postavyArena2.Add(vlk);


            Arena arenaAsync1 = new Arena(postavyArena1);
            Arena arenaAsync2 = new Arena(postavyArena2);

            await arenaAsync1.BojAsync();
            await arenaAsync2.BojAsync();


            Console.ReadKey(true);
        }

        static void VypisVyberuOponenta(Postava postava, Postava oponent)
        {
            Console.WriteLine($"{postava.Jmeno} si vybral nového oponenta: {oponent.Jmeno}");
        }
    }
}
