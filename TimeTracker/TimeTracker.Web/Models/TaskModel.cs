using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracker.Web.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Task")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Time Estimate")]
        public string TimeEstimate { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Finish Date")]
        public DateTime FinishDate { get; set; }

        [Display(Name = "Filepath")]
        public string Filepath { get; set; }

        [Display(Name = "Version")]
        public int Version { get; set; }

        [Display(Name = "ProjectId")]
        public int ProjectId { get; set; }
        [Display(Name = "Project")]
        public string ProjectName { get; set; }

        [Display(Name = "AssignedPersonId")]
        public int AssignedPersonId { get; set; }
        [Display(Name = "AssignedPerson")]
        public string AssignedPersonName { get; set; }

        [Display(Name = "AssigningPersonId")]
        public int AssigningPersonId { get; set; }
        [Display(Name = "AssigningPerson")]
        public string AssigningPersonName { get; set; }

        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "StatusId")]
        public int StatusId { get; set; }
        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Display(Name = "PriorityId")]
        public int PriorityId { get; set; }
        [Display(Name = "Priority")]
        public string PriorityName { get; set; }

        [Display(Name = "TypeId")]
        public int TypeId { get; set; }
        [Display(Name = "Type")]
        public string TypeName { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Projects { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AssignedPersons { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AssigningPersons { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Categories { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Statuses { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Priorities { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Types { get; set; }

    }
}