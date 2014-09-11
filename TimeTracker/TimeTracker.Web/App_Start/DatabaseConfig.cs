using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Wrapper;
using WebMatrix.WebData;

namespace TimeTracker.Web
{
    public class DatabaseConfig
    {
        public static void RegisterDatabase(IServiceWrapper wrapper)
        {
            wrapper.InitializeDatabase();
            wrapper.InitializeRoles();
            wrapper.InitializeCategories();
            wrapper.InitializeStatuses();
            wrapper.InitializePriorities();
            wrapper.InitializeTypes();
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfiles", "UserId", "UserName", autoCreateTables: false);
        }
    }
}