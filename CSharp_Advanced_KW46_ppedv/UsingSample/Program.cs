using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace UsingSample
{
    class Program
    {
        static void Main(string[] args)
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


            Stream stream1 = null;
            try
            {
                //SqlDataConnection -> System.Data (SqlProvider) -> Open() / Close() -> Close wird in Finally-Block verwendet
                //kritischer Codeblock
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                xmlSerializer.Serialize(stream1, person2);
            }
            catch (IOException ex)
            {
                //IOException -> Fehler beim schreiben

            }
            catch (Exception ex)
            {
                //weitere und allgemeinere Fehler
            }
            finally
            {
                //stream1.Flush();
                //stream1.Close();
                stream1.Dispose();
            }



            #region using Sample

            using Stream stream = File.OpenWrite("Person123.bin");


            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, person);
            stream.Close();


            using (HttpClient httpClient = new HttpClient())
            {

            }//httpClient.Dispose() -> hat ein wenig mehr, als man zuerst sieht -> 

            #endregion
        }
    }

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
