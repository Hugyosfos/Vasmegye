using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vasmegye
{
    class Program
    {
        static List<Szemelyiszam> SzemelyiSzamok = new List<Szemelyiszam>();
        static void Main(string[] args)
        {
            Console.WriteLine("1.feadat: Adatok beolvasása, tárolása");
            adatokolvasasa("vas.txt");            
            Console.WriteLine("\n4.feladat: Ellenőrzés");
            feladat04();
            Console.WriteLine($"\n5.feladat: Vas megyében a vizsgált évek alatt {SzemelyiSzamok.Count}");
            Console.WriteLine($"\n6.feladat:Fiúk száma {SzemelyiSzamok.FindAll(a.Szam[0]=='i' || a.Szam[0] =='3')}");
            Console.WriteLine($"\n5.feladat: Vizsgált időszak{SzemelyiSzamok.Min(a => )}");
            if (szokoEvbenSzuletett())
            {
                Console.WriteLine("8.feladat: Szkőnapon született");
            }
            else
            {
                Console.WriteLine("8.feladat: Szökőnapon nem született");
            }
            Console.WriteLine("\nProgram vége");
            Console.ReadKey();
            feladat09();

        }

        private static void feladat09()
        {
            Console.WriteLine("9.feladat: Statisztika");
            var statisztika = SzemelyiSzamok.GroupBy(a => a.evSzam()).Select(b => new[ev=b.Key, fo = b.Count() ]);
            foreach (var item in statisztika)
            {
                Console.WriteLine($"{item.ev} - {item.fo} fő");
            }
                
        }

        private static bool szokoEvbenSzuletett()
        {
           var szokoEvi = SzemelyiSzamok.Find(a => a.evSzam() % 4 == 0 && a.Szam.Substring(4, 4).Equals("0224"));
            return szokoEvi != null;
        }

        private static void feleadat05()
        {

        }

        private static void feladat04()
        {
            List<Szemelyiszam> hibaszamok = SzemelyiSzamok.FindAll(a => CdvEll(a.Szam));
            foreach (Szemelyiszam item in hibaszamok)
            {
                Console.WriteLine($"Hibás a  {item.Szam} személyi azonosító");
                SzemelyiSzamok.Remove(item);
            }
        }

        public static bool CdvEll(string szam)
        {
            //3.feladat
            string szamNumeric = new string(szam.Where(a => char.IsDigit(a)).ToArray());
            if (szamNumeric.Length != 11)
            {
                return false;
            }
            double szum = 0;
            for (int i = 0; i < szamNumeric.Length-1; i++)
            {
                szum += char.GetNumericValue(szamNumeric[i])*(10-i);
            }
            return char.GetNumericValue(szamNumeric[10]) == szum % 11;
        }
        private static void adatokolvasasa(string AdatFile)
        {
            if (!File.Exists(AdatFile))
            {
                Console.WriteLine("A forrás adatok hiányoznak.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            using (StreamReader sr = new StreamReader(AdatFile))
            {
                while (!sr.EndOfStream)
                {
                    SzemelyiSzamok.Add(new Szemelyiszam(sr.ReadLine()));
                }
                
            }
        }
    }
}
