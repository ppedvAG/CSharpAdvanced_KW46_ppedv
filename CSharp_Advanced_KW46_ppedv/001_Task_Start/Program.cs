using System;
using System.Threading.Tasks;

namespace _001_Task_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            Task easyTask = new Task(MachEtwasInEinemThread);
            easyTask.Start();
            easyTask.Wait();


            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }

            Console.ReadKey();
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
