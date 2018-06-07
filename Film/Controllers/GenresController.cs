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
    public class GenresController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();
        private readonly UnitOfWork uow;

        public GenresController()
        {
            uow = new UnitOfWork(new MoviesDbContext());
        }

        public GenresController(MoviesDbContext context)
        {
            uow = new UnitOfWork(context);
        }

        // GET: Genres
        public ActionResult Index()
        {
            return View(uow.GenreRepository.GetAll());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = uow.GenreRepository.GetById((int)id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GenreName")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                uow.GenreRepository.Create(genre);
                uow.GenreRepository.Save(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = uow.GenreRepository.GetById((int)id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GenreName")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                uow.GenreRepository.Save(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = uow.GenreRepository.GetById((int)id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = uow.GenreRepository.GetById((int)id);
            uow.GenreRepository.DeleteByID(id);
            uow.GenreRepository.Save(genre);
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
