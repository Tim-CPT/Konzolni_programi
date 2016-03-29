using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProizvodjacPotrosac
{
    class Program
    {
        /* dva sinkronizacijska objekta, posebno za proizvodjace i posebno za potrosace */
        static readonly object bravaProizvodjac = new object();
        static readonly object bravaPotrosac = new object();

        static Random rnd = null;
        static bool cont;

        /* uvjetna varijabla (condition lock) */
        static bool stop;

        /* main */
        static void Main(string[] args)
        {
            int i, citanje, pisanje;

            List<Thread> listaDretvi = new List<Thread>();
            Thread.CurrentThread.Name = "Glavna dretva";
            rnd = new Random();
            string[] polje = new string[12];
            citanje = 0;
            pisanje = 0;
            stop = true;
            /* kreira se 8 dretvi: 4 proizvodjaca i 4 potrosaca */
            for (i = 0; i < 4; i++)
            {
                listaDretvi.Add(new Thread(() => Proizvodjac(ref polje, ref citanje, ref pisanje, i)));
                listaDretvi.Last().Name = string.Format("Proizvodjac {0}", i);
                listaDretvi.Last().Start();
                listaDretvi.Add(new Thread(() => Potrosac(ref polje, ref citanje, ref pisanje, i)));
                listaDretvi.Last().Name = string.Format("Potrosac {0}", i);
                listaDretvi.Last().Start();
                cont = false;
                lock (bravaPotrosac)
                    while (!cont)
                        Monitor.Wait(bravaPotrosac);
            }

            /* dretva koja na pocetku odbrojava */
            Thread brojac = new Thread(() => Brojac(5));
            Console.WriteLine("\nZa 5 sekundi dretve će započeti rad.\nZa zaustavljanje svih dretvi pritisni bilo koju tipku!\n...");

            brojac.Start();
            brojac.Join();
            
            /* dretve se oslobadjaju i zapocinju rad */
            stop = false;
            lock (bravaProizvodjac)
                Monitor.PulseAll(bravaProizvodjac);
            lock (bravaPotrosac)
                Monitor.PulseAll(bravaPotrosac);

            Console.ReadKey();

            /* dretvama se postavlja uvjet za izlazak, one blokirane se oslobadjaju */
            stop = true;
            lock (bravaProizvodjac)
                Monitor.PulseAll(bravaProizvodjac);
            lock (bravaPotrosac)
                Monitor.PulseAll(bravaPotrosac);

            /* ceka se da sve dretve zavrse */
            foreach (Thread dretva in listaDretvi)
                dretva.Join();
            Console.WriteLine("\nSve su dretve završile.\nZa kraj pritisni tipku.");
            Console.ReadKey();

        }

        static void Proizvodjac(ref string[] polje, ref int citanje, ref int pisanje, int redniBroj)
        {
            int i=0;
            /* otkljucavanje glavne dretve nakon sto je preuzet parametar */
            cont = true;
            lock (bravaPotrosac)
                Monitor.PulseAll(bravaPotrosac);

            /* inicijalno cekanje na pocetku */
            lock (bravaProizvodjac)
                while (stop)
                    Monitor.Wait(bravaProizvodjac);
            Console.WriteLine("Krenula je dretva \"{0}\"", Thread.CurrentThread.Name);

            /* dretva radi u beskonacnoj petlji sve dok se ne postavi stop na true */
            while (!stop)
            {
                /* dretva ceka u monitoru dok se ne ispuni uvjet za nastavak */
                lock(bravaProizvodjac)
                    while (((pisanje + 1) % polje.Length) == citanje&&!stop)
                        Monitor.Wait(bravaProizvodjac);
                /* dretvama iste vrste se ne dozvoljava istovremeni pristup polju */
                if (!stop)
                {
                    lock (bravaProizvodjac)
                    {
                        Console.WriteLine("Dretva \"{0}\" upisuje vrijednost {1}.{2}", Thread.CurrentThread.Name, redniBroj, i);
                        polje[pisanje++] = string.Format("{0}.{1}", redniBroj, i++);
                        if (pisanje == polje.Length) pisanje = 0;
                    }
                    /* dretva proizvodjac je proizvela i oslobadja jednu dretvu za potrosnju iz monitora ako takve ima */
                    lock (bravaPotrosac)
                        Monitor.Pulse(bravaPotrosac);
                    /* dretva pauzira slucajno vrijeme izmedju pola i 1 sekunde */
                    Thread.Sleep(500 + rnd.Next(500));
                }
            };
            Console.WriteLine("Dretva \"{0}\" je prekinuta u izvršavanju.", Thread.CurrentThread.Name);
        }
        static void Potrosac(ref string[] polje, ref int citanje, ref int pisanje, int redniBroj)
        {
            cont = true;
            lock (bravaPotrosac)
                Monitor.PulseAll(bravaPotrosac);

            /* inicijalno cekanje na pocetku */
            lock (bravaPotrosac)
                while (stop)
                    Monitor.Wait(bravaPotrosac);
            Console.WriteLine("Krenula je dretva \"{0}\"", Thread.CurrentThread.Name);

            /* dretva radi u beskonacnoj petlji sve dok se ne postavi stop na true */
            while (!stop)
            {
                /* dretva ceka u monitoru dok se ne ispuni uvjet za nastavak */
                lock (bravaPotrosac)
                     while (citanje == pisanje && !stop)
                        Monitor.Wait(bravaPotrosac);
                /* dretvama iste vrste se ne dozvoljava istovremeni pristup polju */
                if (!stop)
                {
                    lock (bravaPotrosac)
                    {
                        Console.WriteLine("Dretva \"{0}\" čita vrijednost {1}", Thread.CurrentThread.Name, polje[citanje++]);
                        if (citanje == polje.Length) citanje = 0;
                    }
                    /* dretva potrosac je potrosila i oslobadja jednu dretvu za proizvodnju iz monitora ako takve ima */
                    lock (bravaProizvodjac)
                            Monitor.Pulse(bravaProizvodjac);
                    Thread.Sleep(500 + rnd.Next(500));
                }
            };
            Console.WriteLine("Dretva \"{0}\" je prekinuta u izvršavanju.", Thread.CurrentThread.Name);
        }
        static void Brojac(int sekundi)
        {
            int i;
            for(i= sekundi; i>0; i--)
            {
                Thread.Sleep(1000);
                Console.Write("{0}, ", i);
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0}\n", i);
        }
    }
}
