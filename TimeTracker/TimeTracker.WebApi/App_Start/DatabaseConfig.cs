using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.ClassService;

namespace TimeTracker.WebApi
{
    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            DatabaseInitializer.InitializeDatabase();
        }
    }
}