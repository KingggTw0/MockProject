using Microsoft.AspNet.Identity;
using OTRequest.Core.Models;
using OTRequest.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OTRequest.MVC.Controllers
{
    public class RequestsController : Controller
    {
        private RequestRepository requestRepo = new RequestRepository();

        // GET: Requests
        public ActionResult Index()
        {
            string userAccount = User.Identity.GetUserName();
            var listRequest = requestRepo.FindRequestByUser(userAccount);
            return View(listRequest);
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = requestRepo.FindRequestById(id.Value);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,DepartmentName,Status,TotalRemarks,TotalHours,ProjectId")] Request request)
        {
            if (ModelState.IsValid)
            {
                requestRepo.CreateRequest(request);
                return RedirectToAction("Index");
            }

            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = requestRepo.FindRequestById(id.Value);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,DepartmentName,Status,TotalRemarks,TotalHours,ProjectId")] Request request)
        {
            if (ModelState.IsValid)
            {
                requestRepo.UpdateRequest(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = requestRepo.FindRequestById(id.Value);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            requestRepo.DeletedRequestById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                requestRepo.Dipose();
            }
            base.Dispose(disposing);
        }
    }
}