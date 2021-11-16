using System;

namespace DelegatesActionsAndFuncsSamples
{
    //Delegate arbeitet mit Methoden zusammen
    //Mit welchen Methoden? -> Methoden mit einem int (ReturnValue) und (int) als Parameter
    delegate int NumbChange(int n); //Delegate - Typdefiniertung - 


    delegate int CalculationsDelegate(int zahl1, int zahl2);

    delegate void LikeTheActionDelegateSample(int number);
    class Program
    {
        static void Main(string[] args)
        {

            #region Delegates
            //Definieren Delegate + Initieren mit einer Methode 
            //Delegates kapseln Methoden und können diese Aufrufen 
            NumbChange numbChange = new NumbChange(AddNumber); //Zeiger der Methode (Adresse der Methode) 

            int result = numbChange(11);
            Console.WriteLine(result); //output: 16

            //Weitere Methode wird mithilfe von += an das delegate drangehängt 
            numbChange += SubNumber;

            //Bekommen den Rückgabewert von der letzten angehängten Methode des Delegates
            result = numbChange(11);

            numbChange -= AddNumber;
            result = numbChange(11); //Rückgabe wird 8 sein.



            CalculationsDelegate calculationsDelegate = new CalculationsDelegate(Addition); //Funktionszeiger wird hier übergeben

            //bekomme 33 zurück
            result = calculationsDelegate(11, 22);
            #endregion

            Action a1 = new Action(A);
            //aufzurufen
            a1();

            a1 += B;
            a1();


            Action<int> a2 = new Action<int>(C);
            a2(123); // Methode C wird aufgerufen und 123 wird ausgegeben 
            Action<int, int, float> a3 = new Action<int, int, float>(D);
            a3(11, 22, 3.33f);

            Func<int, int, float, float> func1 = new Func<int, int, float, float>(E);
            float floatResult = func1(11, 22, 3.33f); //36,33

        }


        public static void A()
        {
            Console.WriteLine("A");
        }


        public static void B()
        {
            Console.WriteLine("B");
        }

        public static void C(int zahl)
        {
            Console.WriteLine(zahl);
        }

        public static void D(int zahl1, int zahl2, float zahl3)
        {
            float result = zahl1 + zahl2 + zahl3;

            Console.WriteLine(result);
        }

        public static float E(int zahl1, int zahl2, float zahl3)
        {
            return  zahl1 + zahl2 + zahl3;
        }


        public static int AddNumber(int number)
        {
            return number += 5; //Offset von 5
        }

        public static int SubNumber(int number)
        {
            return number -= 3; //DownSet von 3
        }



        public static int Addition(int num1, int num2)
        {
            return num1 + num2;
        }
    }


}
