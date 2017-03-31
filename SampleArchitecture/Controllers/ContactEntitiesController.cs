using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleArchitecture.Models;

namespace SampleArchitecture.Controllers
{
    public class ContactEntitiesController : Controller
    {
        private DBContext db = new DBContext();
        private ContactRepository contactRepository = new ContactRepository();

        // GET: ContactEntities
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: ContactEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Contact contact = contactRepository.GetContact(id.Value);
            //ContactEntity contactEntity = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: ContactEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,IsActive")] ContactEntity contactEntity)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contactEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactEntity);
        }

        // GET: ContactEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEntity contactEntity = db.Contacts.Find(id);
            if (contactEntity == null)
            {
                return HttpNotFound();
            }
            return View(contactEntity);
        }

        // POST: ContactEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,IsActive")] ContactEntity contactEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactEntity);
        }

        // GET: ContactEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEntity contactEntity = db.Contacts.Find(id);
            if (contactEntity == null)
            {
                return HttpNotFound();
            }
            return View(contactEntity);
        }

        // POST: ContactEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactEntity contactEntity = db.Contacts.Find(id);
            db.Contacts.Remove(contactEntity);
            db.SaveChanges();
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
