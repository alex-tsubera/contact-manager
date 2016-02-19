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
    public class PhonesController : Controller
    {
        IPhoneService _PhoneService;

        public PhonesController(IPhoneService PhoneService)
        {
            _PhoneService = PhoneService;
        }

        // GET: Phones/Create
        public ActionResult Create(int personID)
        {
            var phone = new Phone() { PersonID = personID };
            return View(phone);
        }

        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneID,PersonID,Number")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _PhoneService.Create(phone);
                return RedirectToAction("Edit", "Contacts", new { id = phone.PersonID });
            }
            return View(phone);
        }

        // GET: Phones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = _PhoneService.GetById((int)id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneID,PersonID,Number")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _PhoneService.Update(phone);
                return RedirectToAction("Edit", "Contacts", new { id = phone.PersonID });
            }
            return View(phone);
        }

        // GET: Phones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = _PhoneService.GetById((int)id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = _PhoneService.GetById(id);
            _PhoneService.Delete(phone);
            return RedirectToAction("Edit", "Contacts", new { id = phone.PersonID });
        }
    }
}
