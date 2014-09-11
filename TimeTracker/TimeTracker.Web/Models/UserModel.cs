using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracker.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Roles { get; set; }
    }
}