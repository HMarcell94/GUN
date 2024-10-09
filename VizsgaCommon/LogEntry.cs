using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizsgaCommon
{
    [Table("Logs")]
    public class LogEntry
    {
        [Key]
        public int Id { get;set; }
        public string CorrelationId { get; set; }
        public DateTime DateUtc { get; set; }
        public int Thread { get; set; }
        public string Level {  get; set; }
        public string Logger { get;set; }
        public string Message { get; set; }
        public string? Exception { get; set; }
    }
}
