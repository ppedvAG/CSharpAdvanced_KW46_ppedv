using System;

namespace RecordSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonClass person1 = new PersonClass(1, "Mario Bath");
            PersonClass person2 = new PersonClass(1, "Mario Bath");

            PersonRecord personR1 = new PersonRecord(1, "Helge Schneider");
            PersonRecord personR2 = new PersonRecord(1, "Helge Schneider");
            
            #region == Operator
            if (person1 == person2)
            {
                Console.WriteLine("person1 == person2");
            }
            else
                Console.WriteLine("person1 != person2");

            if (personR1 == personR2)
            {
                Console.WriteLine("personR1 == personR2");
            } else Console.WriteLine("personR1 != personR2");
            #endregion

            #region Equals
            if (person1.Equals(person2))
            {
                Console.WriteLine("person1.Equals(person2) = true");
            }
            else
                Console.WriteLine("person1.Equals(person2) = false");
            #endregion  

            #region Equals
            if (personR1.Equals(personR2))
            {
                Console.WriteLine("personR1.Equals(personR2) = true");
            }
            else
                Console.WriteLine("personR1.Equals(personR2) = false");
            #endregion

            #region ToString()
            //Person Class
            Console.WriteLine("ToString() - Sample:");
            Console.WriteLine("class Person:");
            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());

            Console.WriteLine("record Person:");
            Console.WriteLine(personR1.ToString());
            Console.WriteLine(personR2.ToString());

            #endregion


            #region Dekonstrion
            (int id, string name) = personR1; //indirekt calle ich personR1.Deconstruct 


            (int id2, string name2) = person1;

            #endregion

            //Setzen von Variablen geht nicht, weil Name {get;init;}
            //personR1.Name = "Karajan"; //gibt ein Fehler


            //personRecord3 wird auch initialisiert und mithilfe von "with" kann ich bestehende Werte modifizieren
            PersonRecord personRecord3 = personR1 with { Name = "Herbert Grönemeiyer" };
        }
    }

    //public class PersonRecord : IEquatable<PersonRecord>
    public record PersonRecord(int Id, string Name);

    public record EmployeeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PersonClass
    {
        public PersonClass(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public int Id { get; init; }
        public string Name { get; init; }


        public void Deconstruct(out int Id, out string Name)
        {
            Id = this.Id;
            Name = this.Name;
        }
    }
}
