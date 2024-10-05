
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LogCommon.Models
{
    [Table("Logs")]
    public class LogEntry
    {
        [Key]
        public int Id { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTime DateUtc { get; set; }
        public int Thread { get; set; }
        [MaxLength(1000)]
        public string Level { get; set; }
        [MaxLength(1000)]
        public string Logger { get; set; }
        [MaxLength(1000)]
        public string Message { get; set; }
        [AllowNull]
        public string? Exception { get; set; }
    }
}
