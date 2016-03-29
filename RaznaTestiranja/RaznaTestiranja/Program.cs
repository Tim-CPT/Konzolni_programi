using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaznaTestiranja
{
    class
        Biljezenje
    {
        int a;
        int b;
        public void ucitaj()
        {
            a = 0;
            b = 0;
            Console.Write("Cijeli dio: ");
            Int32.TryParse(Console.ReadLine(),out a);
            Console.Write("Decimalni dio: ");
            Int32.TryParse(Console.ReadLine(),out b);
        }
        public double decimalni()
        {
            double ret=0.0;
            Double.TryParse(String.Format("{0},{1}", a, b), out ret);
            return ret;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Biljezenje a = new Biljezenje();
            Biljezenje b = new Biljezenje();
            Console.WriteLine("Unesi prvi decimalni broj: ");
            a.ucitaj();
            Console.WriteLine("Unesi drugi decimalni broj: ");
            b.ucitaj();
            Console.WriteLine("Zbroj {0}+{1}={2}", a.decimalni(), b.decimalni(), a.decimalni() + b.decimalni());
            Console.WriteLine("Za kraj pritisni bilo koju tipku.");
            Console.ReadKey();
        }
    }
}
