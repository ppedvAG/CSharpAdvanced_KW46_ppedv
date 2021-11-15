using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace SerialisierungExtentionMethods
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Muster",
                Alter = 45,
                Kontostand = 1_000_000,
                KreditLimit = 5_000_000
            };

            Person person2 = new Person()
            {
                Vorname = "Maria",
                Nachname = "Muster",
                Alter = 33,
                Kontostand = 10_000_000,
                KreditLimit = 50_000_000
            };


            Stream stream = null;

            #region Binär -> binaryFormatter

            //Schreiben 
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //stream = File.OpenWrite("Person.bin");
            //binaryFormatter.Serialize(stream, person); //warning -> absolete
            ////Obselte - Methoden aufruft -> NotSupportedException 
            //stream.Close();


            ////Lesen
            //stream = File.OpenRead("Person.bin");
            //Person geleandePerson = (Person)binaryFormatter.Deserialize(stream);
            //stream.Close();
            #endregion

            #region XML
            //Schreiben
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            ////FileMode.OpenOrCreate
            //stream = File.OpenWrite("Person.xml");
            //xmlSerializer.Serialize(stream, person2);
            //stream.Flush(); //schreibe alles raus, bis buffer leer ist 
            //stream.Close();

            ////Einlesen
            //stream = File.OpenRead("Person.xml");
            //Person geladenePerson2 = (Person)xmlSerializer.Deserialize(stream);
            //stream.Close();
            #endregion

            #region JSON
            //System.Text.Json
            //Newtonsoft.Json

            //Im alten .NET Framework -> Newtonsoft.Json 
            //Im neuen .NET Framework   < .NET Core 3.1 -> Newtonsoft.Json 
            //                          > .NET Core 3.1 -> System.Text.Json 


            string jsonString = JsonConvert.SerializeObject(person);
            await File.WriteAllTextAsync("Person.json", jsonString);

            jsonString = string.Empty;
            jsonString = await File.ReadAllTextAsync("Person.json");
            //string jsonString2 = File.ReadAllText("Person.json");
            Person geladenePerson3 = JsonConvert.DeserializeObject<Person>(jsonString);
            #endregion

            #region CSV
            person.Serialize("Person.csv");

            person = new Person();

            person.Deserialize("Person.csv");

            //myPerson.Serialize("Person.csv");

            #endregion
        }//myStream.Dispose() 

    }

    //[Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public int Alter { get; set; }


        //[field: NonSerialized]
        //[XmlIgnore]
        public int Kontostand { get; set; }

        //[NonSerialized]
        //[XmlIgnore]
        public int KreditLimit;

        
    }
}
