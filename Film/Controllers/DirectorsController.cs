using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseProject.DB.Entities;
using CourseProject.DataAcces;

namespace Film.Controllers
{
    public class DirectorsController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();
        private readonly UnitOfWork uow;

        public DirectorsController()
        {
            uow = new UnitOfWork(new MoviesDbContext());
        }

        public DirectorsController(MoviesDbContext context)
        {
            uow = new UnitOfWork(context);
        }

        // GET: Directors
        public ActionResult Index()
        {
            return View(uow.DirectorRepository.GetAll());
        }

        // GET: Directors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = uow.DirectorRepository.GetById((int)id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // GET: Directors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DirectorName")] Director director)
        {
            if (ModelState.IsValid)
            {
                uow.DirectorRepository.Create(director);
                uow.DirectorRepository.Save(director);
                return RedirectToAction("Index");
            }

            return View(director);
        }

        // GET: Directors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = uow.DirectorRepository.GetById((int)id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DirectorName")] Director director)
        {
            if (ModelState.IsValid)
            {
                uow.DirectorRepository.PromoteOrDemote(director);
                return RedirectToAction("Index");
            }
            return View(director);
        }

        // GET: Directors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = uow.DirectorRepository.GetById((int)id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Director director = uow.DirectorRepository.GetById((int)id);
            uow.DirectorRepository.DeleteByID(id);
            uow.DirectorRepository.Save(director);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
