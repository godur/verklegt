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
    public class SubPartController : Controller
    {
		// Búum til tilvik af repository-inum okkar til að vinna með í gegnum föllin.
		SubPartsRepository repo = new SubPartsRepository();

        // GET: /SubPart/
        public ActionResult Index()
        {
			var result = repo.GetAllSubParts();
			
			return View(result);
        }

        // GET: /SubPart/Details/5
        public ActionResult Details(int? id)
        {
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			var subPartById = repo.GetSubPartById(id);
            
			if (subPartById == null)
            {
                return HttpNotFound();
            }
            
			return View(subPartById);
        }

        // GET: /SubPart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SubPart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,StartTime,EndTime,MediaURLExtension")] SubPart subpart)
        {
            if (ModelState.IsValid)
            {
				repo.AddSubPart(subpart);
				repo.SaveSubPart();
				return RedirectToAction("Index");
            }

            return View(subpart);
        }

        // GET: /SubPart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var subPartByID = repo.GetSubPartById(id);
            if (subPartByID == null)
            {
                return HttpNotFound();
            }
            return View(subPartByID);
        }

        // POST: /SubPart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,StartTime,EndTime,MediaURLExtension")] SubPart subpart)
        {
            if (ModelState.IsValid)
            {
				repo.UpdateSubPart(subpart);
				return RedirectToAction("Index");
            }
            return View(subpart);
        }

        // GET: /SubPart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var subPartByID = repo.GetSubPartById(id);
            if (subPartByID == null)
            {
                return HttpNotFound();
            }
            return View(subPartByID);
        }

        // POST: /SubPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var subPartByID = repo.GetSubPartById(id);
			repo.RemoveSubPart(subPartByID);
			repo.UpdateSubPart(subPartByID);
            return RedirectToAction("Index");
        }
    }
}
