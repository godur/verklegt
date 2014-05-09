using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using verklegt.Models;

namespace verklegt.DAL
{
	public class AppInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppContext>
	{
		protected override void Seed(AppContext context)
		{
			// Búum til lista af NewsItem klösum og frumstillum þá með titli, texta, flokk og dagsetningu fréttar, til þess að hafa fylla inn í gagnagrunnstöfluna í upphafi.
			var subParts = new List<SubPart>
			{
				new SubPart{
					StartTime=DateTime.Now,
					EndTime=DateTime.Now,
					MediaURLExtension="https://www.youtube.com/watch?v=npbpQloQSwg"
				},
				new SubPart{
					StartTime=DateTime.Now,
					EndTime=DateTime.Now,
					MediaURLExtension="https://www.youtube.com/watch?v=8n6uOxf7W1g"
				}
			};
		}
	}
}	