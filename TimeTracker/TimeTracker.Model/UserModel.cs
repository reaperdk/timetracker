using System;
using System.Collections;
using System.Collections.Generic;

namespace TimeTracker.Model
{
    public class UserModel : IModelBase
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public IEnumerable<ProjectModel> Projects { get; set; }

        
    }
}