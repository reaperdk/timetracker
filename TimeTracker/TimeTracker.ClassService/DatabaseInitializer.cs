using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.ClassService
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            Repository.DatabaseInitializer.InitializeDatabase();
        }
    }
}
