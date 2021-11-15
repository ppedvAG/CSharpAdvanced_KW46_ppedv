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


            ProcessBusinessLogic2 processBusinessLogic2 = new ProcessBusinessLogic2();
            processBusinessLogic2.ProcessCompleted += ProcessBusinessLogic2_ProcessCompleted;

            //Methode wird an ProcessCompletedNew drangehängt
            processBusinessLogic2.ProcessCompletedNew += ProcessBusinessLogic2_ProcessCompletedNew;
            processBusinessLogic2.StartProcess();
        }

        private static void ProcessBusinessLogic2_ProcessCompletedNew(object sender, EventArgs e)
        {
            MyEventArgs myEvent = (MyEventArgs)e;

            Console.WriteLine(myEvent.Uhrzeit.ToShortDateString());
        }

        //Event-Methode
        private static void ProcessBusinessLogic2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Wer hat gesenden {sender.ToString()} mit welchen Argumenten {e.ToString()}");
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
