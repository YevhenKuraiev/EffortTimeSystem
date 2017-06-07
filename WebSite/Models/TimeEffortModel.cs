using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETS.Contracts.DataContracts;

namespace WebSite.Models
{
    public class TimeEffortModel
    {
        public string ProjectName { get; set; }
        public float Effort { get; set; }
        public float Overtime { get; set; }
        public float Total { get; set; }
    }
}