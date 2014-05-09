using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using verklegt.DAL;

namespace verklegt.Models
{
	public class SubPartsRepository
	{
		//Connect to DB
		//Get SubParts
		//Update SubPart

		// Búum til tilvik af  gagnagrunninum okkar til vinna með.
		AppContext db = new AppContext();

		// Fall sem sækir alla SubPartana okkar í gagnagrunninn og skilar þeim tilbaka.
		public IEnumerable<SubPart> GetAllSubParts()
		{
			return db.SubParts;
		}

		// Fall sem sækir SubParta eftir Id-i hans eða null gildi ef hann er ekki til.
		public SubPart GetSubPartById(int? id)
		{
			var result = (from s in db.SubParts
						  where s.ID == id
						  select s).SingleOrDefault();

			return result;
		}

		// Fall sem uppfærir SubPart eftir Id-inu hans í gagnagrunninum og skilar 
		// þér í Index eða NotFound View ef engu er skilað til baka
		public void UpdateSubPart(SubPart s)
		{
			SubPart sp = GetSubPartById(s.ID);
			

			if (sp != null)
			{
				sp.StartTime = s.StartTime;
				sp.EndTime = s.EndTime;
				sp.MediaURLExtension = s.MediaURLExtension;
				db.SaveChanges();
			}
		}

		// Fall sem vistar SubPart í gagnagrunni.
		public void SaveSubPart()
		{
			db.SaveChanges();
		}

		// Fall sem býr til SubPart í gagnagrunni.
		public void AddSubPart(SubPart s)
		{
			db.SubParts.Add(s);
		}

		// Fall sem eyðir út SubPart í gagnagrunni.
		public void RemoveSubPart (SubPart s)
		{
			db.SubParts.Remove(s);
		}
	}
}