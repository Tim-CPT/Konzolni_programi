using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* svaki program mora biti u nekom namespaceu i sve njegove klase također */
namespace Konzolni_program
{
    /* prva klasa */
    class KlasaVoce
    {
        static string[] voce = new string[] {"jabuka","limun","trešnja","višnja","narandža","banana"};
        public void ispis()
        {
            foreach (string i in voce)
                Console.WriteLine("Ispis iz klase {0}", i);
        }
    }

    /* druga klasa */
    class UnosBroja
    {
        public void unos()
        {
            Double x;
            while (true)
            {
                Console.WriteLine("Unesi neki decimalni broj (sa zarezom ako je hrvatska lokalizacija)");
                string s = Console.ReadLine();
                try
                {
                    x = Double.Parse(s);
                    Console.WriteLine("Unesen je broj {0}", x);
                    Console.WriteLine("Taj broj pomnožen sa 10 je {0}", x * 10);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Neispravan unos broja: {0}", e.Message);
                }
            }
        }

        public void unos2()
        {
            Int32 i;
            int x;
            Random r = new Random();
            while (true)
            {
                Console.WriteLine("Unesi neki cijeli pozitivan broj manji ili jednak 100.");
                string s = Console.ReadLine();
                try
                {
                    i = Int32.Parse(s);
                    if (i > 100) throw new Exception("prevelik broj");
                    if (i < 0) throw new Exception("broj manji od nule");
                    for (x = 0; x < i; x++)
                        Console.Write("{0}, ", r.Next(i));
                    Console.Write("{0}\n", x);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("greška {0}", e.Message);
                }
            }
        }


        public void radi_s_poljem(ref Double[] polje)
        {
            int i;
            Double avg=0.0;
            if (polje.Count() == 0) return;
            Random r = new Random();
            for (i = 0; i < 20; i++)
                polje[i] = r.NextDouble() * 100.0;

            for(i=0; i < polje.Count(); i++)
            {
                avg = avg + (polje[i] - avg) / (i+1);
                Console.WriteLine("Element polja: {0}, avg: {1}", polje[i], avg);
            }
            Array.Sort(polje);
        }
    }

    /* glavna klasa aplikacije, koja sadrži metodu Main */
    class Program
    {
        static string[] imena = new string[] { "Marko","Janko","Pero","Ivan","Zoran" };

        /* metoda main */
        static void Main(string[] args)
        {
            int i;
            /* prvi način */
            for(i=0; i<imena.Count();i++)
                Console.WriteLine("Ispis teksta u konzoli {0}",imena[i]);
            Console.Write("\n");
            /* drugi način */
            foreach(string s in imena)
                Console.WriteLine("Ispis preko iteratora {0}", i);
            Console.Write("\n");
            /* objekt */
            KlasaVoce voce = new KlasaVoce();
            voce.ispis();
            Console.Write("\n");

            /* objekt sa brojevima */
            UnosBroja broj = new UnosBroja();
            broj.unos();

            broj.unos2();

            Console.WriteLine("\nZa nastavak pritisni bilo koju tipku.");
            Console.ReadKey();

            /* kreiramo polje od 20 double elemenata */
            double[] polje = new double[20];

            /* referenciranje argumenata */
            broj.radi_s_poljem(ref polje);
            /* ispis polja kojega na koje je djelovala metoda i sortirala ga */
            Console.WriteLine("Ispis sortiranog polja:");
            for (i = 0; i < polje.Count() - 1; i++)
                Console.Write("{0,4:E}; ", polje[i]);
            Console.Write("{0}\n", polje[i]);
            string unos=Console.ReadLine();
        }
    }
}
