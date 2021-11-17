using System;
using System.Threading;

namespace _007_LockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 200; i++)
            {
                ThreadPool.QueueUserWorkItem(MachEinKontoUpdate);
            }

            Console.WriteLine("fertig");
            Console.ReadKey();
        }

        private static void MachEinKontoUpdate(object state) //Diese Methode läuft jeweils in einem speraten Thread
        {
            Random r = new Random();

            for (int i = 0; i < 500000; i++)
            {
                int auswahl = r.Next(0, 10);

                if (auswahl % 2 == 0)
                {
                    Konto.Einzahlen(r.Next(0, 1000));
                }
                else
                    Konto.Abheben(r.Next(0, 1000));
            }
        }
    }
}
