using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Repository
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            using (var context = new EntitiesContext())
            {
                if (!context.Database.Exists())
                {
                    // Create the SimpleMembership database without Entity Framework migration schema
                    ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                }
            }
        }
    }
}
