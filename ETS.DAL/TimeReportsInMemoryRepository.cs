using System;
using System.Collections.Generic;
using System.Linq;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;

namespace ETS.DAL
{
    public class TimeReportsInMemoryRepository : ITimeReportsRepository
    {
        private static readonly List<TimeReportEntity> TimeReportsStorage = new List<TimeReportEntity>
        {
            new TimeReportEntity
            {
                Id = 1,
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(-1),
                Effort = (float) 8,
                Overtime = (float) 2.5,
                Description = "Fixing issue #3356",
                Status = ReportStatus.Open,
                Task = new TaskEntity
                {
                    Id = 12,
                    Title = "Bug fixing",
                    Description = "This task is related to all activities regarding fixing of customer issues",
                    Project = new ProjectEntity
                    {
                        Id = 3,
                        Name = "W3D3"
                    }
                }
            },
            new TimeReportEntity
            {
                Id = 2,
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(-1),
                Effort = (float) 8,
                Overtime = (float) 2.5,
                Description = "Fixing issue #3356",
                Status = ReportStatus.Open,
                Task = new TaskEntity
                {
                    Id = 12,
                    Title = "Bug fixing",
                    Description = "This task is related to all activities regarding fixing of customer issues",
                    Project = new ProjectEntity
                    {
                        Id = 3,
                        Name = "W3D3"
                    }
                }
            }
        };

        public IEnumerable<TimeReportEntity> GetAll()
        {
            return TimeReportsStorage;
        }

        public TimeReportEntity GetById(int id)
        {
            return TimeReportsStorage.FirstOrDefault(timeReport => timeReport.Id == id);
        }

        public void Add(TimeReportEntity report)
        {
            report.Id = TimeReportsStorage.Count + 1;
            TimeReportsStorage.Add(report);
        }

        public void Update(TimeReportEntity reportWithChanges)
        {
            var reportToUpdate = TimeReportsStorage.First(rp => rp.Id == reportWithChanges.Id);
            reportToUpdate.Effort = reportWithChanges.Effort;
            reportToUpdate.Overtime = reportWithChanges.Overtime;
            reportToUpdate.StartDate = reportWithChanges.StartDate;
            reportToUpdate.EndDate = reportWithChanges.EndDate;
            reportToUpdate.Description = reportWithChanges.Description;
            reportToUpdate.Status = reportWithChanges.Status;
            reportToUpdate.Task = reportWithChanges.Task;
        }

        public void Delete(int id)
        {
            TimeReportsStorage.RemoveAll(r => r.Id == id);
        }
    }
}
