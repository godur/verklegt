using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verklegt.Models
{
	public class Subtitle
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Category { get; set; }
		public string Language { get; set; }
		public DateTime PublishDate { get; set; }
		public string MediaURL { get; set; }
		public string SubtitleFileURL { get; set; }
		public string Status { get; set; }
		public int Votes { get; set; }
		
		List<SubPart> SubParts;
	}
}