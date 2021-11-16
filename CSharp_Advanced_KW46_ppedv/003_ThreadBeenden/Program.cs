using System;
using System.Threading;

namespace _003_ThreadBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwas);
            thread.Start();

            //Hauptprogramm wartet 3 Sekunden lang
            Thread.Sleep(3000);

            thread.Interrupt();

            Console.WriteLine("ready");
        }
        //Methode benötigt 10 Sekunden zum bearbeiten
        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("zzzZZZZZzzzzzZZZZZ");
                    Thread.Sleep(200);
                }
            }
            catch(ThreadInterruptedException ex)
            {

            }
        }
    }
}
