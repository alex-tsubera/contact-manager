using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManager_v._1._0.Service;
using ContactManager_v._1._0.Model;

namespace ContactManager_v._1._0.Controllers
{
    public class ContactsController : Controller
    {
        IPersonService _PersonService;

        public ContactsController(IPersonService PersonService)
        {
            _PersonService = PersonService;
        }

        // GET: Contacts
        public ActionResult Index()
        {
            var people = _PersonService.GetAll();
            return View(_PersonService.GetAll().ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById((int)id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FirstName,LastName")] Person person, [Bind(Include = "PersonID,EmailAddress")] Email email, [Bind(Include = "PersonID,Number")] Phone phone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _PersonService.Create(person,email,phone);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            return View(person);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById((int)id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FirstName,LastName")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _PersonService.Update(person);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            return View(person);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById((int)id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Person person = _PersonService.GetById((int)id);
                _PersonService.Delete(person);

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            return RedirectToAction("Index");
        }
    }
}