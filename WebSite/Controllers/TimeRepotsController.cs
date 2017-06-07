using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ETS.BLL;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;
using ETS.DAL;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class TimeReportsController : Controller
    {
        private readonly TimeReportService reportsRepository = new TimeReportService();
        private readonly ITasksRepository tasksRepository = new TasksInMemoryRepository();
        private readonly IProjectsRepository projectsRepository = new ProjectsInmemoryRepository();

        // GET: TimeReports
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<TimeReportEntity> allRepots = this.reportsRepository.GetAll();

            IEnumerable<TimeReportModel> reportsModel = allRepots.Select(reportEntity => new TimeReportModel
            {
                Id = reportEntity.Id,
                SpentHours = new ReportSpentHours
                {
                    Effort = reportEntity.Effort,
                    Overtime = reportEntity.Overtime
                },
                TimeInterval = new TimeReportInterval
                {
                    StartDate = reportEntity.StartDate,
                    EndDate = reportEntity.EndDate
                },
                ProjectName = reportEntity.Task.Project.Name,
                TaskName = reportEntity.Task.Title,
                Status = reportEntity.Status.ToString(),
                Description = reportEntity.Description
            });

            return View(reportsModel);
        }

        //[HttpPost]
        //public void Delete(TimeReportModel postModel)
        //{
        //    TimeReports.Remove(postModel);
        //}

        [HttpPost]
        public RedirectToRouteResult Save(ManageTimeReportModel postModel)
        {
            TimeReportEntity newReport = new TimeReportEntity
            {
                Id = postModel.Id,
                Effort = postModel.SpentHours.Effort,
                Overtime = postModel.SpentHours.Overtime,
                StartDate = postModel.TimeInterval.StartDate,
                EndDate = postModel.TimeInterval.EndDate,
                Status = ReportStatus.Open,
                Task = tasksRepository.GetById(postModel.TaskId), //todo: if PostModel.ProjectId != Task.Project.Id => Exception - таски должны соответствовать проекту
                Description = postModel.Description
            };
            var report = reportsRepository.GetById(postModel.Id);
            if (report == null)
                this.reportsRepository.Add(newReport);
            else
            {
                reportsRepository.Update(newReport);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult CreateTimeReport()
        {
            //TODO : Таси соотв проекту
            IEnumerable<ProjectEntity> projectEntities = this.projectsRepository.GetAll();
            IEnumerable<TaskEntity> tasksEntities = this.tasksRepository.GetAll();

            var createModel = new ManageTimeReportModel
            {
                Tasks = tasksEntities,
                Projects = projectEntities
            };

            return this.PartialView("EditableTimeReportRow", createModel);
        }

        [HttpGet]
        public PartialViewResult EditTimeReport(int id)
        {
            TimeReportEntity reportEntity = this.reportsRepository.GetById(id);
            var model = new ManageTimeReportModel
            {
                Id = reportEntity.Id,
                SpentHours = new ReportSpentHours
                {
                    Effort = reportEntity.Effort,
                    Overtime = reportEntity.Overtime
                },
                TimeInterval = new TimeReportInterval
                {
                    StartDate = reportEntity.StartDate,
                    EndDate = reportEntity.EndDate
                },
                ProjectId = reportEntity.Task.Project.Id,
                TaskId = reportEntity.Task.Id,
                Tasks = tasksRepository.GetAll(), //todo: проверить чтобы таски соответствовали проекту!!!!
                Description = reportEntity.Description
            };

            return this.PartialView("EditableTimeReportRow", model);
        }

        [HttpGet]
        public RedirectToRouteResult DeleteTimeReport(int id)
        {
            reportsRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public RedirectToRouteResult NotifyTimeReport(int id)
        {
            reportsRepository.Notify(id);
            return RedirectToAction("Index");
        }
    }
}