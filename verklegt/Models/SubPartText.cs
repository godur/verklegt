using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verklegt.Models
{
	public class SubPartText
	{
		public int ID { get; set; }
		public string UserName { get; set; }
		public string Language { get; set; }
		public string Text1 { get; set; }
		public string Text2 { get; set; }

		List<Point> Points;
	}
}