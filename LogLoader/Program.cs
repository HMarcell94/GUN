using LogCommon;
using LogCommon.Models;
using Microsoft.EntityFrameworkCore;


namespace LogLoader
{
    internal class Program
    {
        private static LogEntry _FormatLog(string raw)
        {
            LogEntry entry = new LogEntry();
            var list = raw.Split(';');
            entry.Id = int.Parse(list[0]);
            entry.CorrelationId = Guid.Parse(list[1]);
            entry.DateUtc = DateTime.Parse(list[2]);
            entry.Thread = int.Parse(list[3]);
            entry.Level = list[4];
            entry.Logger = list[5];
            entry.Message = list[6];
            entry.Exception = list[7] == "" ? null : list[7];
            return entry;
        }


        static void Main(string[] args)
        {
            try
            {
                var dbContext = new LogCommon.SQL();
                var path = "";
                if (args.Length > 1 && args[0].Contains("InputFile"))
                {
                    if (args[1].Contains(".csv") == false) throw new ArgumentException("Invalid argument, try: -InputFile filename.csv");
                    path = Path.Combine(Directory.GetCurrentDirectory(), args[1]);
                }
                else
                {
                    throw new ArgumentException("Invalid argument, try: -InputFile filename.csv");
                }

                if (!File.Exists(path)) throw new ArgumentException("File not found");
                Console.WriteLine("File found!");

                var raw = File.ReadAllLines(path);
                var before = dbContext.Logs.Count();

                for (int i = 1; i < raw.Length; i++)
                {
                    dbContext.Logs.Add(_FormatLog(raw[i]));
                }
                dbContext.SaveChanges();



                Console.WriteLine($"Sorok száma fejléccel együtt: {raw.Length}");
                Console.WriteLine($"Beilesztett sorok: {dbContext.Logs.Count() - before}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }

        }
    }
}
