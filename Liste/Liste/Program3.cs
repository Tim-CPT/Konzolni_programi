using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{

    class MojaKlasa
    {
        string sadrzaj;
        public MojaKlasa(string unos)
        {
            sadrzaj = new string(unos.ToCharArray());
        }

        public string ispis()
        {
            return sadrzaj;
        }

        public void promijeni()
        {
            sadrzaj = string.Concat("PROM_", sadrzaj);
        }
    }

    class Program
    {
        static List<string> listaObjekata1 = null;
        static List<string> listaObjekata2 = null;

        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("Kreiram dvije liste objekata klase \"Moja klasa\"");
            listaObjekata1 = new List<string>();
            listaObjekata2 = new List<string>();

            for (i = 0; i < 5; i++)
            {
                string objekt = string.Concat("Sadržaj objekta " + i);
                listaObjekata1.Add(objekt);
                listaObjekata2.Add(objekt);
                Console.WriteLine("Dodan je objekt u obje liste na mjestu " + i);
            }

            Console.WriteLine("\nU obje liste se nalaze objekti nastali iz istog objekta.");
            Console.WriteLine("   Sadržaj liste 1   |   Sadržaj liste 2");
            for (i = 0; i < listaObjekata1.Count; i++)
                Console.WriteLine("  {0}  |  {1}", listaObjekata1.ElementAt(i), listaObjekata2.ElementAt(i));

            Console.WriteLine("\nMijenjam objekte u listi 2.");
            for(i=0; i<listaObjekata2.Count; i++)
            {
                string t = listaObjekata2.ElementAt(i);
                t = string.Concat("PROMJENA_", t);
                listaObjekata2.RemoveAt(i);
                listaObjekata2.Insert(i, t);
                Console.WriteLine("Promijenjen sadržaj objekta " + i);
            }
            Console.WriteLine("\nIspisujem sadržaj obje liste usporedno.");
            for (i = 0; i < listaObjekata1.Count; i++)
                Console.WriteLine("  {0}  |  {1}", listaObjekata1.ElementAt(i), listaObjekata2.ElementAt(i));

            Console.WriteLine("\nZa nastavak pritisni bilo koju tipku");
            Console.ReadKey();
        }
    }
}
