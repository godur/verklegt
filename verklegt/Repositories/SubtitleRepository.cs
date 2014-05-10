using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using verklegt.DAL;
using verklegt.Models;

namespace verklegt.Repositories
{
	public class SubtitleRepository
	{
		// Búum til tilvik af gagnagrunninum okkar til að vinna með.
		AppContext db = new AppContext();

		// Fall sem sækir alla skjátexta í gagnagrunn og skilar 10 nýjustu
		public IEnumerable<Subtitle> GetFirst10Subtitles()
		{
			var first10Subtitles = (from s in db.Subtitles
									orderby s.PublishDate ascending
									select s).Take(10);

			return first10Subtitles;
		}

		// Fall sem sækir alla skjátexta í gagnagrunninn og skilar þeim tilbaka.
		public IEnumerable<Subtitle> GetAllSubtitles()
		{
			return db.Subtitles;
		}

		// Fall sem sækir alla skjátexta fyrir gefinn flokk
		public IEnumerable<Subtitle> GetSubtitleByCategories(int? id)
		{
			var getSubtitleByCategories = (from c in db.Categories
										   join s in db.Subtitles on c.CategoryName equals s.Category
										   where c.ID == id
										   select s).Take(10);

			return getSubtitleByCategories;
		}

		// FilterSubtitlesByCategories Á EFTIR AÐ ÚTFÆRA!!
		// Fall sem raðar öllum skjátextum eftir gefnum flokk

		// Fall sem ber saman titil við titil í töflu í gagnagrunni
		public Title CompareSubtitleTitle(string title)
		{
			var compareSubtitleTitle = (from t in db.Titles
									   where t.TitleName == title
									   select t).SingleOrDefault();

			return compareSubtitleTitle;
		}
		
		// Fall sem hækkar "upvote" um einn á skjátexta
		public void AddSubtitleCount(Subtitle s)
		{
			s.Votes = s.Votes++;
			db.SaveChanges();
		}

		// Fall sem sækir Subtitles eftir Id-i hans eða null ef hann er ekki til.
		public Subtitle GetSubtitleById(int? id)
		{
			var getSubtitleById = (from s in db.Subtitles
								   where s.ID == id
								   select s).SingleOrDefault();

			return getSubtitleById;
		}

		// Fall sem uppfærir Subtitle eftir Id-inu hans í gagnagrunninum og skilar
		// þér í Index eða NotFound View ef engu er skilað til baka
		public void UpdateSubtitle(Subtitle s)
		{
			Subtitle subtitleByID = GetSubtitleById(s.ID);

			if (subtitleByID != null)
			{
				subtitleByID.Category = s.Category;
				subtitleByID.Language = s.Language;
				subtitleByID.MediaURL = s.MediaURL;
				subtitleByID.PublishDate = s.PublishDate;
				subtitleByID.Status = s.Status;
				subtitleByID.SubtitleFileURL = s.SubtitleFileURL;
				subtitleByID.Title = s.Title;
				subtitleByID.Votes = s.Votes;
			}
		}
		
		// Fall sem vistar Subtitles í gagnagrunni.
		public void SaveSubtitle()
		{
			db.SaveChanges();
		}

		// Fall sem býr til Subtitle í gagnagrunni.
		public void AddSubtitle(Subtitle s)
		{
			db.Subtitles.Add(s);
		}

		// Fall sem eyðir út Subtitle í gagnagrunni.
		public void RemoveSubtitle(Subtitle s)
		{
			db.Subtitles.Remove(s);
		}

		// ÚTFÆRT Í CONTROLLER:
		
		// MergeSubtitleFile
		// Fall sem sækir alla SubParts fyrir gefinn Subtitle, 
		// merge-ar þá saman í .srt skrá sem hann býr til
		

		// GetSubPartsBySubtitleID
		// Fall sem skilar SubParts lista fyrir gefinn Subtitle út frá ID-inu hans
		
		// TrimSubtitleFile
	}
}