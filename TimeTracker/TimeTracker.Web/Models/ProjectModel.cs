using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracker.Web.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project")]
        public string Name { get; set; }

    }
}