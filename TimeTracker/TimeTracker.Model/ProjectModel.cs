using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TimeTracker.Model
{
    [Table("Projects")]
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserProfile> Users { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
