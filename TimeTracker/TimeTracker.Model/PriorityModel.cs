﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    public class PriorityModel : IModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
