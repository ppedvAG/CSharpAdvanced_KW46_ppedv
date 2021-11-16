using System;
using System.Threading.Tasks;

namespace _007_ContinueWithParams
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(DayTime);

            task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.ReadLine();
        }

        public static string DayTime()
        {
            DateTime date = DateTime.Now;

            int zahl = 123;
            string myString = zahl == 123 ? "Es ist 123...definitiv" : "Ist ungleich 123";

            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                ? "afternoon"
                : "morning";
        }

        public static void ShowDayTime(string result)
        {
            Console.WriteLine(result); //output: morning / afternoon / evening
        }
    }
}
