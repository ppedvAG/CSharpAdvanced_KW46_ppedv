using System;

namespace EventsEventHandlerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
            processBusinessLogic.ProcessCompleted += ProcessBusinessLogic_ProcessCompleted;
            processBusinessLogic.CurrentPercentStatus += ProcessBusinessLogic_CurrentPercentStatus;

            processBusinessLogic.StartProcess();
        }

        private static void ProcessBusinessLogic_CurrentPercentStatus(int n)
        {
            Console.WriteLine($"Prozentstatus: {n}");
        }

        private static void ProcessBusinessLogic_ProcessCompleted()
        {
            //Hier komme ich am Ende raus, wenn meine Component fertig mit der Methode StartProcess
        }

        //Eine Evnet-Methode erhalten, die die Prozentausgabe darstellt 


        //Eine Methode, die sagt, ich bin fertig
    }
}
