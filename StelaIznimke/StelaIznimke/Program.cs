using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StelaIznimke
{

    class Auto
    {
        char simbol;
        int brzina;
        List<char> polje = new List<char>();

        public void VratiPolje()
        {

            int kraj = polje.Count + brzina;
            int i = polje.Count;

            for (; i < kraj; i++)
            {
                polje.Add(this.simbol);
            }
            polje.ForEach(Console.Write);
        }

        public void UnesiSimbol(char simbol)
        {
            this.simbol = simbol;
        }

        public void UnesiBrzinu(int brzina)
        {
            this.brzina = brzina;
            Console.WriteLine("Brzina je postavljena na " + this.brzina);
        }
    }

    public class MyExeptionError : ApplicationException
    {
        public MyExeptionError(string poruka)
        {
            VratiPoruku = poruka;
        }
        public string VratiPoruku
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int kolicina = 0;


            Console.WriteLine("Kolicina: ");
            try {
                kolicina = int.Parse(Console.ReadLine());

                if (kolicina < 1)
                {
                    throw new MyExeptionError("Kolicina ne može biti manja od 1");
                }
                Auto[] polje2 = new Auto[kolicina];
                for (int i = 0; i < kolicina; i++)
                {
                    polje2[i] = new Auto();
                    Console.WriteLine("Simbol: ");
                    char s = char.Parse(Console.ReadLine());
                    polje2[i].UnesiSimbol(s);

                    Console.WriteLine("Brzina: ");
                    int b = int.Parse(Console.ReadLine());
                    polje2[i].UnesiBrzinu(b);
                }

                while (true)
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    for (int i = 0; i < kolicina; i++)
                    {
                        Console.WriteLine("");
                        polje2[i].VratiPolje();
                    }
                }
            }
            catch(MyExeptionError e)
            {
                Console.WriteLine(e.VratiPoruku);
            }
            catch(Exception e)
            {
                Console.WriteLine("Dogodila se neka druga iznimka. Sustav je vratio poruku " + e.Message);
            }
            Console.WriteLine("Za kraj pritisni bilo koju tipku.");
            Console.ReadKey();
        }
    }
}
