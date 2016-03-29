using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegularniIzrazi
{
    class Program
    {
        const string ulazniTekst =@"In the Wind of the mind arises the turbulence called I. It breaks; down shower the barren thoughts. 
All life is choked. This desert is the Abyss wherein is the Universe.The Stars are but thistles in that waste. 
Yet this desert is but one spot accursèd in a world of bliss. Now and again Travellers cross the desert; 
they come from the Great Sea, and to the Great Sea they go. As they go they spill water; 
one day they will irrigate the desert, till it flower. See! five footprints of a Camel! V.V.V.V.V.";

        static void ispisi(MatchCollection kolekcija)
        {
            int i=0;
            if (kolekcija.Count > 0)
            {
                if(kolekcija.Count > 1)
                    for (i = 0; i < kolekcija.Count - 1; i++)
                        Console.Write("{0}, ", kolekcija[i].Value);
                Console.WriteLine(kolekcija[0].Value);
            }
            else Console.WriteLine("nema rezultata");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ispisujem riječi:");
            Regex izraz = new Regex("[A-Za-z]{1,}");
            ispisi(izraz.Matches(ulazniTekst));
            Console.WriteLine("\nIspisujem riječi sa dva slova:");
            izraz = new Regex("(^| )[A-Za-z]{2}(.| )");
            ispisi(izraz.Matches(ulazniTekst));
            Console.WriteLine("\nIspisujem slova s točkom:");
            izraz = new Regex("[A-Z]\\.");
            ispisi(izraz.Matches(ulazniTekst));
            Console.WriteLine("\nIspisujem riječi koje završavaju točkom:");
            izraz = new Regex("[A-Za-z]+\\. ");
            ispisi(izraz.Matches(ulazniTekst));

            Console.WriteLine("\nIspisujem riječi sa velikim početnim slovom:");
            izraz = new Regex(" [A-Z][a-z]+");
            ispisi(izraz.Matches(ulazniTekst));
            Console.WriteLine("\nIspisujem riječi sa više od 8 slova:");
            izraz = new Regex("(^| )[A-Za-z]{9}[a-z]+");
            ispisi(izraz.Matches(ulazniTekst));
            Console.WriteLine("\nIspisujem riječi koje završavaju sa d:");
            izraz = new Regex("[A-Za-z]+d(.| )");
            ispisi(izraz.Matches(ulazniTekst));

            Console.ReadKey(); 

        }
    }
}
