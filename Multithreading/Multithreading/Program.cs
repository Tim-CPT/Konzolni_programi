using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{

    class Program
    {
        static readonly object brava = new object();
        static EventWaitHandle svePokrenuto = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            int i, brojac;
            List<Thread> listaDretvi = new List<Thread>();
            Thread.CurrentThread.Name = "Glavna dretva";
            brojac = 10;
            for(i=0; i<10; i++)
            {
                listaDretvi.Add(new Thread(() => DretvaFunkcija(ref brojac, i)));
                listaDretvi.Last().Name = string.Format("Dretva {0}", i);
                listaDretvi.Last().Start();
            }
            /* glavna dretva ceka da sve dretve budu pokrenute i da ispisu da su pokrenute */
            svePokrenuto.WaitOne();
            lock(brava)
                Console.WriteLine("{0}: sve su dretve pokrenute. Čekam da sve zavrse.", Thread.CurrentThread.Name);
            foreach (Thread dretva in listaDretvi)
                dretva.Join();
            Console.WriteLine("\nSve su dretve završile.\nZa kraj pritisni bilo koju tipku.");
            Console.ReadKey();

        }
        static void DretvaFunkcija(ref int brojac, int sjeme)
        {
            int v = 0;
            Random rnd = new Random(sjeme);
            lock (brava)
                {
                Console.WriteLine("Pokrenuta dretva {0} sa sjemenom {1}", Thread.CurrentThread.Name, sjeme);
                brojac--;
                if (brojac == 0) svePokrenuto.Set();
                }
            Thread.Sleep(rnd.Next(1000));
            for (int j = 0; j < 5; j++)
            {
                lock (brava)
                {
                    Console.Write("{0}: ",Thread.CurrentThread.Name);
                    for (int i = 0; i < 20; i++, v++)
                    {
                        Console.Write("{0} ", v);
                        Thread.Sleep(20);
                    }
                    Console.WriteLine("");
                }
                Thread.Sleep(rnd.Next(2000));
            }
            lock(brava)
                Console.WriteLine("{0} je završila.", Thread.CurrentThread.Name);
        }
    }
}
