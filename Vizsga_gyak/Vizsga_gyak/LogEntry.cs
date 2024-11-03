using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga_gyak
{
	internal class LogEntry
	{
		public int Id { get; set; }
		public Guid CorrelationId { get; set; }
		public DateTime DateUtc { get; set; }
		public int Thread { get; set; }
		public string Level { get; set; }
		public string Logger { get; set; }
		public string Message { get; set; }
		public string Exception { get; set; } 
	}
}
