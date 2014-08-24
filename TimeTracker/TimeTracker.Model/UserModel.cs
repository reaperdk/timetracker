using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Model
{
    public class UserModel : IModelBase
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public virtual ICollection<ProjectModel> Projects { get; set; }
        //[InverseProperty("AssignedPerson")]
        public virtual ICollection<TaskModel> AssignedTasks { get; set; }
        //[InverseProperty("AssigningPerson")]
        //public virtual ICollection<TaskModel> AssigningTasks { get; set; }
    }
}