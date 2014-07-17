using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker.Model
{
    public class ProjectModel
    {
        public IEnumerable<UserModel> Users { get; set; }
    }
}
