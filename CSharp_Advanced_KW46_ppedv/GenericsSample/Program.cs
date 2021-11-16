using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //List verwendet intern ein Array -> Eine Leere Liste ist ein Array von 4 Felder
            //Bedeutet: Wenn die Liste voll ist, verdoppelt sich das interne Array 
            List<string> nameListe = new List<string>();
            nameListe.Add("Harry Weinfuhrt");
            nameListe.Add("Emanuella");

            IDictionary<Guid, string> dict = new Dictionary<Guid, string>();
            dict.Add(Guid.NewGuid(), "Guten Tag");

            dict.Add(new KeyValuePair<Guid, string>(Guid.NewGuid(), "Halloooo :-)"));


            Hashtable hashtable = new Hashtable();
            hashtable.Add(new DateTime(), "Hallo");
            hashtable.Add("Hallo", new DateTime());



            DataStore<string, Guid> dataStore = new DataStore<string, Guid>();

            dataStore.AddOrUpdate(0, "Donald Duck");
            dataStore.AddOrUpdate(1, "Dagobert Duck");

           
        }
    }

    public class DataStore<T, ABC>
    {
        //Array wird auf 10 Felder gesetzt. Typ ist unbekannt
        private T[] _data = new T[10];
        private ABC myABCDataType;

        public ABC MyABCProberty
        {
            get => myABCDataType;
            set => myABCDataType = value;
        }

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }

        public void DisplayDefault<MyType>()
        {
            MyType item = default(MyType);

            Console.WriteLine($"Default value of {typeof(MyType)} is {(item == null ? "null" : item.ToString())}.");
        }


    }
}
