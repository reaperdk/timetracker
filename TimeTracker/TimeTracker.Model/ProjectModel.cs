using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker.Model
{
    public class ProjectModel : IModelBase
    {
        public string Name { get; set; }
        public IEnumerable<UserModel> Users { get; set; }
    }
}
