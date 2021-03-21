using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private DetailRequestRepository detailRepo = new DetailRequestRepository();
        private OTRequestContext context = new OTRequestContext();

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
                return View("Page404");
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
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = requestRepo.FindRequestById(id.Value);
            if (request == null)
            {
                return View("Page404");
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
                return View("Page404");
            }
            return View(request);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            requestRepo.DeletedRequestById(id);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ListMyClaim(string status)
        {
            string userAccount = User.Identity.GetUserName();
            var listRequest = requestRepo.FindRequestByUser(userAccount);

            ViewBag.status = status;
            var listRequestByStatus =
                status != "Rejected Or Cancelled" ? listRequest.Where(x => x.Status == status).ToList()
                : listRequest.Where(x => x.Status == "Rejected" || x.Status == "Cancelled").ToList();

            return View("_PartialListClaim", listRequestByStatus);
        }

        //// kết nối với Claim For Approval test
        [Authorize]
        public ActionResult ListForApproval(string status)
        {
            ViewBag.status = status;
            string userAccount = User.Identity.GetUserName();
            string idUser = User.Identity.GetUserId();

            var listForApproval = requestRepo.FindRequestByManager(idUser).ToList();

            return View("_PartialForApproval", listForApproval.Where(x => x.Status == status).ToList());
        }

        //// kết nối với Claim For Approval by Paid test
        [Authorize]
        public ActionResult ListForFinance(string status)
        {
            ViewBag.status = status;
            var listForFinance = context.Requests.Where(x => x.Status == status).ToList();
            return View("_PartialForFinance", listForFinance);
        }

        public string PaidClaim(string ListId)
        {
            if (string.IsNullOrEmpty(ListId)) return "warning";
            var list = ListId.Split(',');

            foreach (var id in list)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        var item = requestRepo.FindRequestById(int.Parse(id));
                        item.Status = "Paid";
                        requestRepo.UpdateRequest(item);
                    }
                    catch
                    {
                        return "fail";
                    }

                }
            }
            return "success";
        }

        public string ApprovalClaim(string ListId, string status, string remark)
        {
            if (string.IsNullOrEmpty(ListId)) return "warning";
            var list = ListId.Split(',');
            foreach (var id in list)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        var item = requestRepo.FindRequestById(int.Parse(id));
                        switch (status)
                        {
                            case "Approve":
                                item.Status = "Approved";
                                break;
                            case "Return":
                                item.Status = "Draft";
                                var Detail = detailRepo.GetDetailRequest(int.Parse(id));
                                Detail.Remark = remark;
                                Detail.RequestDay = DateTime.Now;

                                detailRepo.AddDetailRequest(Detail);
                                break;
                            case "Reject":
                                item.Status = "Rejected";
                                break;
                            default:
                                return "fail";
                        }
                        requestRepo.UpdateRequest(item);
                    }
                    catch
                    {
                        return "fail";
                    }
                }
            }
            return "success";
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