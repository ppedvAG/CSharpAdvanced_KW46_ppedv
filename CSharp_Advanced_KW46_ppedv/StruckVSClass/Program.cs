using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruckVSClass
{
   
    class PersonC
    {
        public string name;
        public int alter;

        public PersonC(string name, int alter)
        {
            this.name = name;
            this.alter = alter;
        }

    }

    //STRUCTS sind Klassenähnliche Konstrukte, welche nicht, wie Klassen, als Referenztypen behandelt werden, sondern ein Wertetyp sind. D.h
    //bei Übergabe eines Structs an eine Methode oder Variable wird eine Kopie dieses Objekts erstellt
    struct PersonS
    {
        public string name;
        public int alter;

        public PersonS(string name, int alter)
        {
            this.name = name;
            this.alter = alter;
        }
    }


    class Program
    {
        public static void Altern (PersonC cPerson)
        {
            cPerson.alter++;
        }

        public static void Altern(PersonS sPerson)
        {
            sPerson.alter++;
        }

        //Mittels des REF-Stichworts können Wertetypen als Referenz an Methoden übergeben werden. D.h. die übergebene Speicherstelle selbst 
        ///wird manipuliert und nicht, wie normalerweise bei Wertetypen, eine Kopie des Werts.
        public static void Altern(ref PersonS sPerson)
        {
            sPerson.alter++;
        }

        static void Main(string[] args)
        {
            //Erstellung von Objekten
            PersonC cPerson = new PersonC("Heiko", 35);
            PersonS sPerson = new PersonS("Anna", 35);
            PersonS sPerson1 = new PersonS("Anna2", 35);
            //Ausgabe
            Console.WriteLine($"{cPerson.name}: {cPerson.alter}");
            Console.WriteLine($"{sPerson.name}: {sPerson.alter}");

            //Funktionsaufruf
            Altern(cPerson);
            Altern(sPerson);

            //Erneute Ausgabe: Nur das Klassenobjekt (Referenztyp) hat sich verändert
            Console.WriteLine($"{cPerson.name}: {cPerson.alter}");
            Console.WriteLine($"{sPerson.name}: {sPerson.alter}");

            //Übergabe des Wertetyps als Refernz mittels Ref-Stichwort
            Altern(ref sPerson);
            Console.WriteLine($"{sPerson.name}: {sPerson.alter}");


            PersonS newPerson = sPerson; //Jede Properties wird einzeln kopiert

            
            Console.ReadKey();
        }
    }
}
