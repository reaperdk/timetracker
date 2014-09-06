using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeTracker.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Role")]
        public int RoleId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}