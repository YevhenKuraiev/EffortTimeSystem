﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class TimeReportInterval
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Completion date")]
        public DateTime EndDate { get; set; }
    }
}