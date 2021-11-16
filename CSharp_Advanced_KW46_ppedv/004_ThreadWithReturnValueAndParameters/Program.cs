using System;
using System.Threading;

namespace _004_ThreadWithReturnValueAndParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            string retValue = string.Empty;
            string meinText = "Hello World";


            //Thread mit anonymer Methode
            Thread thread = new Thread(() =>
            {
                retValue = StringToUpper(meinText);
            });


            thread.Start();
            thread.Join();


            Console.WriteLine(retValue);
            Console.ReadLine();
        }


        public static string StringToUpper(string param1)
        {
            return param1.ToUpper();
        }
    }
}
