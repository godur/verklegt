using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using verklegt.Models;
using verklegt.DAL;
using verklegt.Repositories;

namespace verklegt.Controllers
{
    public class SubtitleController : Controller
    {
		// Búum til tilvik af repository-inum okkar til að vinna með í gegnum föllin.
		SubtitleRepository repo = new SubtitleRepository();

        // GET: /Subtitle/ skilar nýjustu 10 subtitles
        public ActionResult Index()
        {
			//var subtitles = repo.GetFirst10Subtitles();
			var subtitles = repo.GetAllSubtitles();
			return View(subtitles);
        }

        // GET: /Subtitle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			var subtitleById = repo.GetSubtitleById(id);
			
            if (subtitleById == null)
            {
                return HttpNotFound();
            }
            return View(subtitleById);
        }

        // GET: /Subtitle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Subtitle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,Category,Language,PublishDate,MediaURL,SubtitleFileURL,Status,Votes")] Subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
				repo.AddSubtitle(subtitle);
				repo.SaveSubtitle();
                return RedirectToAction("Index");
            }

            return View(subtitle);
        }

        // GET: /Subtitle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var subtitleByID = repo.GetSubtitleById(id);
            if (subtitleByID == null)
            {
                return HttpNotFound();
            }
            return View(subtitleByID);
        }

        // POST: /Subtitle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Title,Category,Language,PublishDate,MediaURL,SubtitleFileURL,Status,Votes")] Subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
				repo.UpdateSubtitle(subtitle);
                return RedirectToAction("Index");
            }
            return View(subtitle);
        }

        // GET: /Subtitle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var subtitleByID = repo.GetSubtitleById(id);
            if (subtitleByID == null)
            {
                return HttpNotFound();
            }
            return View(subtitleByID);
        }

        // POST: /Subtitle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			var subtitleByID = repo.GetSubtitleById(id);
			repo.RemoveSubtitle(subtitleByID);
			repo.SaveSubtitle();
            return RedirectToAction("Index");
        }

		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		db.Dispose();
		//	}
		//	base.Dispose(disposing);
		//}
    }
}
