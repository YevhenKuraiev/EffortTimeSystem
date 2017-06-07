using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETS.BLL.Infrastructure;
using ETS.Contracts.DataContracts;
using ETS.Contracts.Interfaces;
using ETS.DAL;

namespace ETS.BLL
{
    public class TimeReportService : ITimeReportsRepository
    {
        private readonly ITimeReportsRepository _reportsRepository = new TimeReportsInMemoryRepository();
        public IEnumerable<TimeReportEntity> GetAll()
        {
            return _reportsRepository.GetAll();
        }

        public TimeReportEntity GetById(int id)
        {
            return _reportsRepository.GetById(id);
        }
        

        public void Add(TimeReportEntity report)
        {
            if (report.Id == 0) report.Id = _reportsRepository.GetAll().Last().Id + 1;
            if (_reportsRepository.GetById(report.Id) != null) throw new ValidationException("Duplicated ID found", "id");
            ReportValidate(report);
            _reportsRepository.Add(report);
        }

        public void Update(TimeReportEntity reportWithChanges)
        {
            if (_reportsRepository.GetById(reportWithChanges.Id) == null) throw new ValidationException("ID not found", "id");
            ReportValidate(reportWithChanges);
            _reportsRepository.Update(reportWithChanges);
        }

        public void Delete(int id)
        {
            if(_reportsRepository.GetById(id) != null) _reportsRepository.Delete(id);
            else throw new ValidationException("Report with this id is not exist", "id");
        }

        private void ReportValidate(TimeReportEntity report)
        {
            if (report.EndDate < report.StartDate) throw new ValidationException("Start date can't be later then end date", "StartDate");
            if (report.Effort <= 0) throw new ValidationException("Effort can't be equal to zero or below zero", "Effort");
            if (report.Effort > 8) throw new ValidationException("Effort can't be bigger then '8'", "Effort");
            if (report.Overtime < 0) throw new ValidationException("Overtime can't be below zerp", "Overtime");
            if (report.Effort < 8 && report.Overtime > 0) throw new ValidationException("Overtime can't be above zero if Effort is below eight", "Overtime");
            //Project, Task are allways correct because of TimeReportsView. Description can be empty 
        }

        public void Accept(int id)
        {
            if (_reportsRepository.GetById(id) == null) throw new ValidationException("ID not found", "id");
            var report = _reportsRepository.GetById(id);
            report.Status = ReportStatus.Accepted;
        }
        public void Decline(int id)
        {
            if (_reportsRepository.GetById(id) == null) throw new ValidationException("ID not found", "id");
            var report = _reportsRepository.GetById(id);
            report.Status = ReportStatus.Declined;
        }
        public void Notify(int id)
        {
            if (_reportsRepository.GetById(id) == null) throw new ValidationException("ID not found", "id");
            var report = _reportsRepository.GetById(id);
            report.Status = ReportStatus.Notified;
        }
    }
}
