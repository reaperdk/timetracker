using System;
using System.Collections;
using System.Collections.Generic;

namespace TimeTracker.Model
{
    public class UserModel
    {
        public string Login { get; set; }
        public IEnumerable<ProjectModel> Projects { get; set; }

        
    }
}