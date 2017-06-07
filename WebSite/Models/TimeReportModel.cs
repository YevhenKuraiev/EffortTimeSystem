namespace WebSite.Models
{
    public class TimeReportModel
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        public ReportSpentHours SpentHours { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public TimeReportInterval TimeInterval { get; set; }
    }
}