using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Task_Beenden
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obwohl die Klasse im Namespace System.Threading liegt, wurde CancellationTokenSource ab .NET 4.0 hinzugefügt
            CancellationTokenSource cts = new CancellationTokenSource();

            Task easyTask = new Task(MeineMethodeMitAbbrechen, cts); //cts ist ein Referenztyp
            easyTask.Start(); //eplizietes starten des Tasks

            Thread.Sleep(5000);
            cts.Cancel();
            Console.WriteLine("Fertig");
            Console.ReadLine();
        }


        public static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationTokenSource source = (CancellationTokenSource)param;

            while(true)
            {
                Console.WriteLine("zzzzZZZzzzZZZzzzZZZzzzZZZZZ");
                Thread.Sleep(50);

                //wenn cts.Cancel() -> IsCancellationRequested = true
                if (source.IsCancellationRequested)
                    break;
            }
        }
    }
}
