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

        public MojaKlasa kloniraj()
        {
            MojaKlasa klon = new MojaKlasa(sadrzaj);
            return klon;
        }
    }

    class Program
    {
        static List<MojaKlasa> listaObjekata1 = null;
        static List<MojaKlasa> listaObjekata2 = null;
        static List<MojaKlasa> listaObjekata3 = null;

        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("Kreiram dvije liste objekata klase \"Moja klasa\"");
            listaObjekata1 = new List<MojaKlasa>();
            listaObjekata2 = new List<MojaKlasa>();

            for (i = 0; i < 5; i++)
            {
                MojaKlasa objekt = new MojaKlasa("Sadržaj objekta " + i);
                listaObjekata1.Add(objekt);
                listaObjekata2.Add(objekt);
                Console.WriteLine("Dodan je objekt u obje liste na mjestu " + i);
            }

            Console.WriteLine("\nU obje liste se nalaze reference na iste objekte.");
            Console.WriteLine("   Sadržaj liste 1   |   Sadržaj liste 2");
            for (i = 0; i < listaObjekata1.Count; i++)
                Console.WriteLine("  {0}  |  {1}", listaObjekata1.ElementAt(i).ispis(), listaObjekata2.ElementAt(i).ispis());

            Console.WriteLine("\nMijenjam objekte u listi 2.");
            for(i=0; i<listaObjekata2.Count; i++)
            { 
                listaObjekata2.ElementAt(i).promijeni();
                Console.WriteLine("Promijenjen sadržaj objekta " + i);
            }
            Console.WriteLine("\nIspisujem sadržaj obje liste usporedno.");
            for (i = 0; i < listaObjekata1.Count; i++)
                Console.WriteLine("  {0}  |  {1}", listaObjekata1.ElementAt(i).ispis(), listaObjekata2.ElementAt(i).ispis());

            Console.WriteLine("\nKreiram treću listu i punim je kopijama objekata liste 1.");
            listaObjekata3 = new List<MojaKlasa>();
            for (i = 0; i < listaObjekata1.Count; i++)
                listaObjekata3.Add(listaObjekata1.ElementAt(i).kloniraj());

            Console.WriteLine("\nIspisujem sadržaj obje liste usporedno.");
            for (i = 0; i < listaObjekata1.Count; i++)
                Console.WriteLine("  {0}  |  {1}", listaObjekata1.ElementAt(i).ispis(), listaObjekata3.ElementAt(i).ispis());

            Console.WriteLine("\nMijenjam objekte u listi 3.");
            for (i = 0; i < listaObjekata3.Count; i++)
            {
                listaObjekata2.ElementAt(i).promijeni();
                Console.WriteLine("Promijenjen sadržaj objekta " + i);
            }
            Console.WriteLine("\nIspisujem sadržaj obje liste usporedno.");
            for (i = 0; i < listaObjekata1.Count; i++)
                Console.WriteLine("  {0}  |  {1}", listaObjekata1.ElementAt(i).ispis(), listaObjekata3.ElementAt(i).ispis());

            Console.WriteLine("\nZa nastavak pritisni bilo koju tipku");
            Console.ReadKey();
        }
    }
}
