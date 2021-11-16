using System;
using System.Threading;
using System.Threading.Tasks;


namespace _006_ContinueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                //Task als anonyme Methode
                Console.WriteLine("Task 1 ist gestartet");
                Thread.Sleep(1000);
                //throw new Exception();
            });

            t1.Start();

            //Task 2 -> Allgemeiner Folgetask
            t1.ContinueWith(t1 => AllgemeinerFolgetask());
            t1.ContinueWith(t1 => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted);
            t1.ContinueWith(t1 => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.ReadLine();
        }

        private static void AllgemeinerFolgetask()
        {
            Console.WriteLine("Allgemeiner Folgetask");
        }

        private static void FolgetaskBeiFehler()
        {
            Console.WriteLine("FolgetaskBeiFehler");
        }

        private static void FolgetaskBeiErfolg()
        {
            Console.WriteLine("FolgetaskBeiErfolg");
        }
    }
}
