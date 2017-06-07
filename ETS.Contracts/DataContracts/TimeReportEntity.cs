using System;

namespace ETS.Contracts.DataContracts
{
    public class TimeReportEntity
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float Effort { get; set; }

        public float Overtime { get; set; }

        public string Description { get; set; }

        public ReportStatus Status { get; set; }

        public TaskEntity Task { get; set; }
    }
}
