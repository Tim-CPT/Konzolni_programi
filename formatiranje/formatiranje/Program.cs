using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formatiranje
{
    class Program
    {
        public static string Indent(int count)
        {
            return "".PadLeft(count*3);
        }
        static void Main(string[] args)
        {
            int i;
            double x;
            Random rnd = new Random();
            x = 0.0;
            for(i=0; i<5; i++ )
            {
                Console.WriteLine("{0:00}: {1:00.00000000} - {1:00.00}", i,x,x);
                x += 0.034;
            }
            x = 0.0;
            Console.WriteLine("========");
            for(i=0; i<5; i++)
            {   
                Console.WriteLine("{0:00}: {1:00.00000000} - {2:#.##}", i, x, x);
                x += 4.034;
            }
            x = -50.0;
            Console.WriteLine("========");
            for (i=0; i<5; i++)
            {
                Console.WriteLine("{0:00}: {1,12:0.00000000} {2,10:0.00}",i,x,x);
                x += 16.712345;
            }
            x = -125.0;
            Console.WriteLine("========");
            for(i=0; i<8; i++)
            {
                Console.WriteLine("{0:00}: {1,12:0.000000} - {2,-10:0.00} <-",i,x,x);
                x += 33.471239;
            }
            x = -50.0;
            Console.WriteLine("========");
            for (i = 0; i < 8; i++)
            {
                Console.WriteLine("{0:00}: {1,12:0.0} {2,10:0.00;(-)0.00;(null)}", i, x, x);
                x += 10.0;
            }
            x = -50.0;
            Console.WriteLine("========");
            for (i = 0; i < 8; i++)
            {
                Console.WriteLine("{0:00}: {1,12:0.0} {2,10:0 . 00}", i, x, x);
                x += 10.0;
            }
            Console.WriteLine("========");
            Console.WriteLine("| Ime    | Prezime   | Broj |");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("| {0,-7}| {1,-10}| {2,4} |", "Pero","Perić",26);
            Console.WriteLine("| {0,-7}| {1,-10}| {2,4} |", "Marko", "Marković", 101);
            Console.WriteLine("| {0,-7}| {1,-10}| {2,4} |", "Ivo", "Ivić", 102);
            Console.WriteLine("========");
            Console.WriteLine(Indent(0) + "1. Glavni A");
            Console.WriteLine(Indent(1) + "1.1 Podnaslov1");
            Console.WriteLine(Indent(2) + "1.1a pod-podnaslov1");
            Console.WriteLine(Indent(2) + "1.1b pod-podnaslov2");
            Console.WriteLine(Indent(1) + "1.2 Podnaslov2");
            Console.WriteLine(Indent(2) + "1.2a pod-podnaslov3");
            Console.WriteLine(Indent(2) + "1.2b pod-podnaslov4");
            Console.WriteLine(Indent(0) + "2. Glavni B");
            Console.WriteLine(Indent(1) + "2.1 Podnaslov3");
            Console.WriteLine(Indent(2) + "2.1a pod-podnaslov5");
            Console.WriteLine(Indent(2) + "2.1b pod-podnaslov6");
            Console.WriteLine(Indent(1) + "2.2 Podnaslov4");
            Console.WriteLine(Indent(2) + "2.2a pod-podnaslov7");
            Console.WriteLine(Indent(2) + "2.2b pod-podnaslov8");
            Console.WriteLine(Indent(2) + "2.2b pod-podnaslov9");
            Console.WriteLine(Indent(1) + "2.3 Podnaslov5");
            Console.WriteLine(Indent(2) + "2.3a pod-podnaslov10");
            Console.WriteLine(Indent(2) + "2.3b pod-podnaslov11");
            Console.ReadKey();
        }
    }
}
