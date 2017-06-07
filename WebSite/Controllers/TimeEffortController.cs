using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;
using ETS.DAL;
using WebSite.Models;
namespace WebSite.Controllers
{
    public class TimeEffortController : Controller
    {
        private ITimeReportsRepository reportsRepository = new TimeReportsInMemoryRepository();
        private IEnumerable<TimeReportEntity> timeReports;
        private List<TimeEffortModel> timeEfforts = new List<TimeEffortModel>();

        public ActionResult Index()
        {
            timeReports = reportsRepository.GetAll();
            foreach (var report in timeReports)
            {
                var projectEffort = timeEfforts.FirstOrDefault(x => x.ProjectName != report.Task.Project.Name);
                if (projectEffort == null)
                {//project is not exist in timeEffort list
                    timeEfforts.Add(new TimeEffortModel()
                    {
                        ProjectName = report.Task.Project.Name,
                        Effort = report.Effort,
                        Overtime = report.Overtime,
                        Total = report.Effort + report.Overtime
                    });
                }
                else
                {//project exist in timeEffort list
                    projectEffort.Effort += report.Effort;
                    projectEffort.Overtime += report.Overtime;
                    projectEffort.Total = projectEffort.Effort + projectEffort.Overtime;
                }

            }
            return View(timeEfforts);
        }
    }
}