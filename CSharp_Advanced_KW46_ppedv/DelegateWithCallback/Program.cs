using System;

namespace DelegateWithCallback
{



    class Program
    {
        public delegate void MessageDelegate(string message);

        static void Main(string[] args)
        {

            //Beispiel 1:
            MessageDelegate messageDelegate = new MessageDelegate(FinishResultMethode);
            messageDelegate("Hallo Welt");
            MethodWithCallback(11, 22, messageDelegate);

            //Beispiel 2:
            Action<string> actionMessageDelegate = new Action<string>(FinishResultMethode);
            MethodWithCallback(11, 22, actionMessageDelegate);

            
        }


        //Calcuations-Methode
        public static void MethodWithCallback(int param1, int param2, MessageDelegate messageDelegate)
        {
            //Rechenintensives 




            //Callbacks werden immer ganz am Ende einer Verarbeitung aufgerufen. 
            //Ganz am Ende möchte ich nach draußen, Kommunizieren, dass ich fertig bin!
            messageDelegate("This Result is " + (param1 + param2).ToString());
        }

        public static void MethodWithCallback(int param1, int param2, Action<string> messageDelegate)
        {
            //Es wird hier viel berechnet... 
            messageDelegate("The number is " + (param1 + param2).ToString()); //Invoke auf FinishResultMethode
        }

        public static void FinishResultMethode(string msg)
        {
            Console.WriteLine(msg); //33 wird ausgegeben

            //Aufräumarbeiten angehen
        }
    }
}
