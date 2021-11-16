using System;

namespace GenericConstraints
{
    //Wertetypen: byte, short, long, int, float, decimal, double, struct

    //Referenztypen: string(verhält sich wie ein Wertetyp), class, interfaces, records(ist eine class) }
    class Program
    {

        static void Main(string[] args)
        {
            #region Werte- und Referenztypern
            Console.WriteLine("Hello World!");
            int alter = 21;
            Altern(alter); //eine Kopie wird übergenem
            Console.WriteLine("In Main-Methode Alter: " + alter); //output: 21


            Person p = new Person();
            p.Alter = 21;
            Altern(p);
            Console.WriteLine("In Main-Methode Personen-Alter: " + p.Alter);


            Console.WriteLine("Beispiel 1 mit Struct");
            StructPerson structPerson = new StructPerson(21);
            Altern(structPerson); //Kopie wird übergeben
            Console.WriteLine(structPerson.InnerPersonObject.Alter);



            Console.WriteLine("Beispiel 2 mit Struct");

            
            Person p1 = structPerson.InnerPersonObject;
            Altern(structPerson.InnerPersonObject);
            Console.WriteLine(structPerson.InnerPersonObject.Alter);
            #endregion

            Console.ReadLine();


            #region Generics + Constraints
            ////DataStore<T> where T : class

            //DataStore<string> store1 = new DataStore<string>();
            //DataStore<MyClass> store2 = new DataStore<MyClass>();
            //DataStore<IMyInterface> store3 = new DataStore<IMyInterface>();
            //DataStore<MyStruct> store4 = new DataStore<MyStruct>(); 
            //DataStore<int> store5 = new DataStore<int>(); 
            //DataStore<ArrayList> store6 = new DataStore<ArrayList>();
            //DataStore<MyRecord> store7 = new DataStore<MyRecord>();

            //DataStore1<T> where T : struct 
            //DataStore1<string> store7 = new DataStore1<string>();
            //DataStore1<MyClass> store8 = new DataStore1<MyClass>();
            //DataStore1<IMyInterface> store9 = new DataStore1<IMyInterface>();
            //DataStore1<MyStruct> store10 = new DataStore1<MyStruct>();
            //DataStore1<int> store11 = new DataStore1<int>();
            //DataStore1<MyRecord> store7 = new DataStore1<MyRecord>();
            #endregion
        }

        #region Werte / Referenztyp
        static void Altern (int alter) //Eine Kopie meiner Variable wird übergeben
        {
            alter++;
            Console.WriteLine(alter); //22
        }

        static void Altern(Person person) //Eine Kopie meiner Variable wird übergeben
        {
            person.Alter++;
            Console.WriteLine(person.Alter);
        }


        static void Altern(StructPerson structPerson)
        {
            structPerson.InnerPersonObject.Alter++;
            Console.WriteLine(structPerson.InnerPersonObject.Alter);
        }
        #endregion
    }

    public class Person
    {
        public int Alter { get; set; }
    }

    public struct StructPerson
    {
        public Person InnerPersonObject { get; set; }

        public StructPerson(int Age)
        {
            InnerPersonObject = new Person();
            InnerPersonObject.Alter = Age;
        }
    }

    class DataStore<T> where T : class //Referenztypen dürfen verwendet werden
    {
        public T Data { get; set; }
    }

    class DataStore1<T> where T : struct //Struct oder Werttyp
    {
        public T Data { get; set; }
    }

    class DataStore2<T> where T : Animal //Animal Klasse können wir verwenden oder eine vererbte Klasse von Animal
    {
        public T Data { get; set; }
    }

    class DataStore3<T> where T : new() //Alle Klassen mit einem Default-Konstruktor
    {
        public T Data { get; set; }
    }

    class DataStore4<T> where T : notnull //Klasse darf nicht null sein - Aber was ist mit dem Struct (wenn ja -> Werte und Refernztypen verwendbar)
    {
        public T Data { get; set; }
    }

    public class Animal
    {
        public Animal()
        {

        }
        public string Name { get; set; } = "R2D2";
    }

    public class Dog : Animal
    {
        public string Hunderasse { get; set; } = "ein wau wau";
    }

    public record MyRecord
    {

    }
    public class MyClass
    {

    }

    public interface IMyInterface
    {
    }

    public struct MyStruct
    {
        string Name { get; set; }
    }


}



