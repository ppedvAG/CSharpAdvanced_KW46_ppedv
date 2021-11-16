using System;
using System.Threading;
using System.Threading.Tasks;

namespace _005_TaskMitException
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;

            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start();

                t2 = Task.Factory.StartNew(MachEinenFehler2);

                t3 = Task.Run(MachEinenFehler3);

                t4 = Task.Run(MachKeinenFehler);

                Task.WaitAll(t1, t2, t3, t4); //wir warten bis ALLE Tasks fertig sind 
            }
            catch (AggregateException ex) //AggreageteException wird für Task-Fehler verwendet
            {
                foreach (Exception innerException in ex.InnerExceptions)
                    Console.WriteLine(innerException.Message);
            }



            //Beispiel 2: Ein Task kann Aussagen, wie die Verarbeitung der jeweiligen Methode abgelaufen -> Statusauskunft

            if (t3.IsCompleted)
                Console.WriteLine("IsCompleted: Task 3 ist fertig durchgleaufen");

            if (t3.IsCompletedSuccessfully)
                Console.WriteLine("IsCompletedSuccessfully: Task 3 ist fertig durchgleaufen");

            if (t3.IsFaulted)
                Console.WriteLine("IsFaulted: Task 3 hat einen Fehler erfahren");

            if (t3.IsCanceled)
                Console.WriteLine("IsCanceled - Task 3 wird abgebrochen");



            if (t4.IsCompleted)
                Console.WriteLine("IsCompleted: Task 4 ist fertig durchgleaufen");

            if (t4.IsCompletedSuccessfully)
                Console.WriteLine("IsCompletedSuccessfully: Task 4 ist fertig durchgleaufen");

            if (t4.IsFaulted)
                Console.WriteLine("IsFaulted: Task 4 hat einen Fehler erfahren");

            if (t4.IsCanceled)
                Console.WriteLine("IsCanceled - Task 4 wird abgebrochen");
        }


        private static void MachEinenFehler1()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Thread.Sleep(6000);
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Thread.Sleep(9000);
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
        {
            Console.WriteLine("Einen schönen Tag :-) ");
        }
    }
}
