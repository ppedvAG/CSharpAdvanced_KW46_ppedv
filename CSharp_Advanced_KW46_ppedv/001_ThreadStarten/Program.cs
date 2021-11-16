using System;
using System.Threading;

namespace _001_ThreadStarten
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Threading;
            Thread thread = new Thread(MachEtwasInEinemThread); //Thread bekommt einen Funktionszeiger
            thread.Start(); //Führe die Methode MachEtwasInEinemThread wird in einem Thread seperat ausgeführt
            thread.Join(); //Wir warten, bis der Thread fertig abgearbeitet ist
            //Hauptprogramm arbeitet 
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");


            Console.ReadLine();
        }


        private static void MachEtwasInEinemThread()
        {
            for(int i = 0; i <1000; i++)
                Console.WriteLine("#");
        }
    }
}
