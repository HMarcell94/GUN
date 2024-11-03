using Newtonsoft.Json; 
using System.Security.Cryptography;

namespace Vizsga_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText(".\\systemlog.json"); // A systemlog.json fájl tartalmának beolvasása egy string változóba
            List<LogEntry> logEntries = JsonConvert.DeserializeObject<List<LogEntry>>(data); // A JSON adatok deszerializálása egy LogEntry objektum listába

            string[] csv = File.ReadAllLines(".\\systemlog.csv"); // A systemlog.csv fájl összes sorának beolvasása egy string tömbbe
            List<LogEntry> logEntries1 = new List<LogEntry>(); // Új üres LogEntry lista létrehozása
            for (int i = 1; i < csv.Length; i++) // Végigmegyünk a csv tömb sorain, kihagyva az első sort (fejléc)
            {
                string[] splitted = csv[i].Split(';'); // Az aktuális sor értékeinek szétválasztása pontosvessző alapján
                logEntries1.Add(new LogEntry() // Új LogEntry objektum hozzáadása a listához az aktuális sor értékeivel feltöltve
                {
                    Id = int.Parse(splitted[0]), // Az első érték az Id (egész számként)
                    CorrelationId = Guid.Parse(splitted[1]), // A második érték a CorrelationId (Guid-ként)
                    DateUtc = DateTime.Parse(splitted[2]), // A harmadik érték a DateUtc (DateTime-ként)
                    Thread = int.Parse(splitted[3]), // A negyedik érték a Thread (egész számként)
                    Level = splitted[4], // Az ötödik érték a Level (stringként)
                    Logger = splitted[5], // A hatodik érték a Logger (stringként)
                    Message = splitted[6], // A hetedik érték a Message (stringként)
                    Exception = splitted[7] // A nyolcadik érték az Exception (stringként)
                });
            }
        }
    }
}
