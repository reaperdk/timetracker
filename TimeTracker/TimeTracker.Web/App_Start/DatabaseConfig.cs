using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Wrapper;

namespace TimeTracker.Web
{
    public class DatabaseConfig
    {
        private readonly IWrapper _wrapper;

        public DatabaseConfig()
        {
            _wrapper = new ClassWrapper();
        }

        public DatabaseConfig(IWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public void AddRoles()
        {
            _wrapper.InitializeRoles();
        }
    }
}