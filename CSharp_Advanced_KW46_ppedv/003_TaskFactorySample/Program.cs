using System;
using System.Threading.Tasks;

namespace _003_TaskFactorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew(MachEtwasInEinemThread); //Task wird sofort gestartet
            task.Wait();


            Task task1 = Task.Run(MachEtwasInEinemThread); //Intern wird Task.Factory.StartNew aufgerufen -> Task.Run dient lediglich als verkürzte Schreibweise.
            task1.Wait();

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("#");
            }
        }
    }
}
