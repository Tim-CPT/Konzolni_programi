using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Filozofi
{

    class Program
    {
        static readonly object brava = new object();
        static Byte[] vilice = null;
        static Random rnd = null;
        static bool stop, cont;
        static void Main(string[] args)
        {
            int i, brojFilozofa;
            
            List<Thread> filozofi = new List<Thread>();
            Console.Write("Unesi broj filozofa: ");
            while (!Int32.TryParse(Console.ReadLine(), out brojFilozofa)||brojFilozofa<1||brojFilozofa>100)
                Console.WriteLine("Pogrešan unos. Pokušajte ponovno.");
            vilice = new Byte[brojFilozofa];
            for (i = 0; i < vilice.Length; i++)
                vilice[i] = 0;
            stop = true;
            rnd = new Random();
            for (i = 0; i < brojFilozofa; i++)
            {
                filozofi.Add(new Thread(()=>Filozof(i)));
                filozofi.Last().Name = string.Format("Filozof {0}", i+1);
                filozofi.Last().Start();
                /* osigurava da se pretlja nece nastaviti dok dretva ne preuzme parametar */
                cont = false;
                lock(brava)
                    while (!cont)
                        Monitor.Wait(brava);
            }
                
            Console.WriteLine("Filozofi su spremni.\n=====Za prekid programa pritisni bilo koju tipku.\n=====");
            stop = false;
            lock(brava)
                Monitor.PulseAll(brava);
            Console.ReadKey();
            stop = true;
            lock (brava)
               Monitor.PulseAll(brava);
            foreach (Thread dretva in filozofi)
                dretva.Join();
            Console.WriteLine("Filozofi su otišli. Za nastavak pritisni bilo koju tipku.");
            Console.ReadKey();
        }

        static void Filozof(int broj)
        {
            int brojacObroka = 0;
            /* dretva otkljucava glavnu dretvu nakon što je sa sigurnoću preuzela parametar*/
            cont = true;
            lock(brava)
                Monitor.PulseAll(brava);

            /* dretva se zakljucava i čeka na barijeri da sve mogu krenuti istovremeno*/
            lock (brava)
                while (stop)
                    Monitor.Wait(brava);

            while (stop==false)
            {
                Console.WriteLine("{0} razmišlja.", Thread.CurrentThread.Name);
                Thread.Sleep(2000+rnd.Next(3000));
                Console.WriteLine("{0} je ogladnio.", Thread.CurrentThread.Name);
                if (stop == false)
                {
                    lock (brava)
                    {
                        while (vilice[broj] == 1 || vilice[(broj + 1) % vilice.Length] == 1)
                        {
                            Console.WriteLine("{0} čeka na slobodne vilice.", Thread.CurrentThread.Name);
                            Monitor.Wait(brava);
                        }
                        vilice[broj] = 1;
                        vilice[(broj + 1) % vilice.Length] = 1;
                        Monitor.PulseAll(brava);
                    }

                    Console.WriteLine("{0} je uzeo vilice {1} i {2} i počeo jesti.", Thread.CurrentThread.Name, broj + 1, ((broj + 1) % vilice.Length) + 1);
                    brojacObroka++;
                    Thread.Sleep(2000);
                    Console.WriteLine("{0} je završio s jelom i odlazi filozofirati.", Thread.CurrentThread.Name);
                    lock (brava)
                    {
                        vilice[broj] = 0;
                        vilice[(broj + 1) % vilice.Length] = 0;
                        Monitor.PulseAll(brava);
                    }
                }
            }
            Console.WriteLine("{0} odlazi. U toku ovog programa jeo je {1} puta.", Thread.CurrentThread.Name, brojacObroka);
        }
    }
}
