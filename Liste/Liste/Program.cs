using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{

    class Program
    {
        static List<string> listaStringova = null;
        static string[] poljeStringova = null;

        static void moja_metoda(string s)
        {
            Console.WriteLine(string.Concat("DODATAK_", s));
        }

        static void Main(string[] args)
        {
            int i;
            listaStringova = new List<string>();
            /* primjer 1 */
            Console.WriteLine("Upisujem 10 stringova u listu stringova.");
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}: upisano.", i);
                listaStringova.Add(string.Format("String {0} sa vrijednošću korjena {1}.", i, Math.Sqrt(i)));
            }
            /* primjer 2 */
            Console.WriteLine("\nIspisujem sve iz liste:");
            for (i = 0; i < listaStringova.Count; i++)
                Console.WriteLine(listaStringova.ElementAt(i));
            /* primjer 3 */
            Console.WriteLine("\nDrugi način ispisa iz liste:");
            foreach (string s in listaStringova)
                Console.WriteLine(s);
            /* primjer 4 */
            Console.WriteLine("\nPrebacujem sadržaj liste stringova u polje stringova i ispisujem to polje unatrag.");
            poljeStringova = listaStringova.ToArray();
            for (i = poljeStringova.Length - 1; i >= 0; i--)
                Console.WriteLine(poljeStringova[i]);
            /* primjer 5 */
            Console.WriteLine("\nKreiram drugu listu, prebacujem sadržaj polja u nju i to ispisujem:");
            List<string> listaStringova2 = poljeStringova.ToList();
            foreach (string s in listaStringova2)
                Console.WriteLine(s);
            /* primjer 7 */
            Console.WriteLine("\nMijenjam sadrzaj prve liste i dokazujem da nisu povezani:");
            for (i = 0; i < listaStringova.Count; i++)
            {
                listaStringova.RemoveAt(i);
                listaStringova.Insert(i, string.Format("Novi sadrzaj {0} i kub {1}", i, Math.Pow(i, 3)));
            }
            for (i = 0; i < listaStringova.Count; i++)
                Console.WriteLine("lista1, element{0}: {1}\nlista2, element{0}: {2}", i, listaStringova.ElementAt(i), listaStringova2.ElementAt(i));
            /* primjer 8 */
            Console.WriteLine("\nOkrećem poredak elemenata u listi i ispisujem ih:");
            listaStringova.Reverse();
            foreach (string s in listaStringova)
                Console.WriteLine(s);
            /* primjer 9 */
            Console.WriteLine("\nMijenjam i ispisujem elemente liste koristeći metodu:");
            listaStringova.ForEach(moja_metoda);
            /* primjer 10 */
            Console.WriteLine("\nMijenjam i ispisujem elemente liste koristeći neimenovanu (lambda) funkciju:");
            listaStringova.ForEach(s => { s = string.Concat("LAMBDA_", s); Console.WriteLine(s); });
            /* primjer 11 */
            Console.WriteLine("Koristim delegat i u njega enkapsuliram neimenovanu funkciju");
            Action<string> delegat = s => { s = string.Concat("DELEGAT_", s); Console.WriteLine(s); };
            listaStringova.ForEach(delegat);

            Console.WriteLine("\nZa nastavak pritisni bilo koju tipku");
            Console.ReadKey();
        }
    }
}
