using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ETS.Contracts.DataContracts;
using WebSite.Models;
using ETS.BLL;

namespace WebSite.Controllers
{
    public class ApprovalController : Controller
    {
        private static readonly IList<ApprovalModel> ApprovalReports = new List<ApprovalModel>
        {
            new ApprovalModel()
            {
                Id = 0,
                TeamMember = "Johny Sins",
                Project = "In space",
                Task = "Do it",
                Effort = 5.2,
                Overtime = 0.0,
                Description = "Let's do it!",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                Status = ReportStatus.Accepted
            },
            new ApprovalModel()
            {
                Id = 1,
                TeamMember = "Jane Air",
                Project = "In space",
                Task = "Fix it",
                Effort = 4.0,
                Overtime = 0.0,
                Description = "Fixing some fix",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                Status = ReportStatus.Notified
            },
            new ApprovalModel()
            {
                Id = 2,
                TeamMember = "Holly Dolly",
                Project = "In space",
                Task = "Development",
                Effort = 8.0,
                Overtime = 3.0,
                Description = "Develop some develop",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                Status = ReportStatus.Declined
            },
            new ApprovalModel()
            {
                Id = 3,
                TeamMember = "Alex",
                Project = "In space",
                Task = "Testing",
                Effort = 3.0,
                Overtime = 0.0,
                Description = "Testing some test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                Status = ReportStatus.Declined
            },
            new ApprovalModel()
            {
                Id = 4,
                TeamMember = "Karl Marks",
                Project = "In space",
                Task = "Fix it",
                Effort = 6.0,
                Overtime = 0.0,
                Description = "Fixing some fix",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                Status = ReportStatus.Accepted
            },
            new ApprovalModel()
            {
                Id = 5,
                TeamMember = "Fedor",
                Project = "In space",
                Task = "Testing",
                Effort = 8.0,
                Overtime = 0.0,
                Description = "Develop some develop",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                Status = ReportStatus.Notified
            },
            new ApprovalModel()
            {
                Id = 6,
                TeamMember = "Bob",
                Project = "In space",
                Task = "Development",
                Effort = 7.0,
                Overtime = 0.0,
                Description = "Develop some develop",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                Status = ReportStatus.Notified
            }
        };
        // GET: Approval
        [HttpGet]
        public ActionResult Index()
        {
            return View(ApprovalReports);
        }

      
        public RedirectToRouteResult Accept(int id)
        {
            ApprovalReports[id].Status = ReportStatus.Accepted;
            return RedirectToAction("Index");

        }

        public RedirectToRouteResult Decline(int id)
        {
            ApprovalReports[id].Status = ReportStatus.Declined;
            return RedirectToAction("Index");
        }
    }
}