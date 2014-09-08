using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Wrapper;

namespace TimeTracker.Web
{
    public class DatabaseConfig
    {
        private readonly IServiceWrapper _wrapper;

        public DatabaseConfig()
        {
            _wrapper = new ClassWrapper();
        }

        public DatabaseConfig(IServiceWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public static void InitializeDatabase()
        {
            ClassWrapper.InitializeDatabase();
        }

        public void AddRoles()
        {
            _wrapper.InitializeRoles();
        }

        public void AddCategories()
        {
            _wrapper.InitializeCategories();
        }

        public void AddStatuses()
        {
            _wrapper.InitializeStatuses();
        }

        public void AddPriorities()
        {
            _wrapper.InitializePriorities();
        }

        public void AddTypes()
        {
            _wrapper.InitializeTypes();
        }
    }
}