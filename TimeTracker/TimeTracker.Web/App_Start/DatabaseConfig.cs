using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracker.Web.Services;
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
            string admin = "admin";
            if (!WebSecurity.UserExists(admin))
            {
                string salt = WebSecurityService.GetSalt();
                WebSecurity.CreateUserAndAccount(admin, admin + "_Tt" + salt);
                wrapper.UpdateCreatedUser(
                    new Model.UserModel
                    {
                        UserName = admin,
                        webpages_Roles = new [] { new Model.RoleModel { RoleId = 1 } }
                    }, salt
                );
            }
        }
    }
}