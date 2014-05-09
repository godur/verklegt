using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verklegt.Models
{
	public class SubPart
	{
		public int ID { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string MediaURLExtension { get; set; }

		List<SubPartText> SubPartTexts;
	}
}