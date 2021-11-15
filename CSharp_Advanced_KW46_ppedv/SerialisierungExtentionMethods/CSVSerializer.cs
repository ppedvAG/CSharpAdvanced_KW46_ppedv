using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisierungExtentionMethods
{
    //Extention-Methoden (Erweiterungsmethoden) 
    public static class CSVSerializer
    {
        public static void Serialize(this Person p, string path)
        {
            File.WriteAllText(path, $"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand};{p.KreditLimit}");
        }

        public static void Deserialize(this Person p, string path)
        {
            string content = File.ReadAllText(path);
            string[] csvPart = content.Split(';');

            p.Vorname = csvPart[0];
            p.Nachname = csvPart[1];
            p.Alter = Convert.ToInt32(csvPart[2]);
            p.Kontostand = int.Parse(csvPart[3]);
            p.KreditLimit = int.Parse(csvPart[4]);

        }
    }
}
