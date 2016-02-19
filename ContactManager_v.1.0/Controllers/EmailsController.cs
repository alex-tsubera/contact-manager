using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManager_v._1._0.Model;
using ContactManager_v._1._0.Service;

namespace ContactManager_v._1._0.Controllers
{
    public class EmailsController : Controller
    {
        IEmailService _EmailService;

        public EmailsController(IEmailService EmailService)
        {
            _EmailService = EmailService;
        }

        // GET: Emails/Create
        public ActionResult Create(int personID)
        {
            var email = new Email() { PersonID = personID };
            return View(email);
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailID,PersonID,EmailAddress")] Email email)
        {
            if (ModelState.IsValid)
            {
                _EmailService.Create(email);
                return RedirectToAction("Edit", "Contacts", new { id = email.PersonID });
            }
            return View(email);
        }

        // GET: Emails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = _EmailService.GetById((int)id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailID,PersonID,EmailAddress")] Email email)
        {
            if (ModelState.IsValid)
            {
                _EmailService.Update(email);
                return RedirectToAction("Edit", "Contacts", new { id = email.PersonID });
            }
            return View(email);
        }

        // GET: Emails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = _EmailService.GetById((int)id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Email email = _EmailService.GetById(id);
            _EmailService.Delete(email);
            return RedirectToAction("Edit", "Contacts", new { id = email.PersonID });
        }
    }
}