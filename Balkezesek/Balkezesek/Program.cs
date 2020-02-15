using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Balkezesek
{
    class Program
    {
        static List<Balkezesek> BalkezesekList;
        static int Evszam;
        static void Main(string[] args)
        {
            Feladat2Beolvasas();
            Console.WriteLine("\n---------------------------------------------------\n");
            Feladat3AdatsorokSzama();
            Console.WriteLine("\n---------------------------------------------------\n");
            Feladat4MagassagCmben();
            Console.WriteLine("\n---------------------------------------------------\n");
            Feldat5Bekeres();
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.ReadKey();
        }

        private static void Feldat5Bekeres()
        {
            Console.WriteLine("\n5.Feladat: Kérjen be egy évszámot 1990 és 1999 között");
            eleje:
            Console.Write("\tKérem adjon meg egy évszámot 1990 és 1999 között:");
            Evszam = int.Parse(Console.ReadLine());
            if(1990<Evszam|| 1999<Evszam)
            {
                Console.WriteLine("\tSikeresen adta meg az évszámot");
                Feladat6BekertEvSzerintiAtlagMagassag();
            }
            else
            {
                Console.WriteLine("Hibás adat!");
                goto eleje;
            }
        }

        private static void Feladat6BekertEvSzerintiAtlagMagassag()
        {
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.WriteLine("6.Feladat: At előzó feladatban bekért évben pályara lépők átlag súlya");
            double OsszSuly = 0;
            double Atlag = 0;
            int db = 0;
            foreach (var b in BalkezesekList)
            {
                if(b.PalyaraLepes.Contains(Evszam.ToString()) || b.PalyarolLelepes.Contains(Evszam.ToString()))
                {
                    db++;
                    OsszSuly += b.SulyFontban;
                    Atlag = OsszSuly / db;
                }
            }
            Console.WriteLine("\tEbben az évben indulók átlag testsúlya: {0:0.00}", Atlag);
        }

        private static void Feladat4MagassagCmben()
        {
            Console.WriteLine("\n4.Feladat: írja ki azoknak a magasságát cm-ben akik utoljára 1999-októberében léptek pályára");
            double MagassagCm = 0;
            foreach (var b in BalkezesekList)
            {
                if(b.PalyarolLelepes.Contains("1999-10"))
                {
                    MagassagCm = b.MagassagInchben * 2.54;
                    Console.WriteLine("\t{0}:{1} ", b.Nev, MagassagCm);
                }                
            }
        }

        private static void Feladat3AdatsorokSzama()
        {
            Console.WriteLine("\n3.Feladat: Határozza meg hány adatsor található az állományban");
            Console.WriteLine("\n\tAz állományban {0} adatsor található", BalkezesekList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("\n2.Feladat: Adatok beolvasása");
            BalkezesekList = new List<Balkezesek>();
            var sr = new StreamReader(@"balkezesek.csv", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                BalkezesekList.Add(new Balkezesek(sr.ReadLine()));
                db++;
            }
            if(db>0)
            {
                Console.WriteLine("\n\tSikeres beolvasás: {0} db sor beolvasva", db );
            }
            else
            {
                Console.WriteLine("\n\tSikertlene beolvasás");
            }
        }
    }
}
