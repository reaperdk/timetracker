using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracker.Web.Models
{
    public class SlotModel
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Finish Date")]
        public DateTime FinishDate { get; set; }

        public int TaskId { get; set; }
    }
}