using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.Wrapper
{
    public interface IServiceWrapper
    {
        IEnumerable<UserProfile> GetAllUsers();
        UserProfile GetUserById(int id);
        void CreateUser(UserProfile user);
        void UpdateUser(UserProfile user);
        void RemoveUser(int id);
        void InitializeRoles();
        IEnumerable<webpages_Roles> GetAllRoles();
        webpages_Roles GetRoleById(int id);
    }
}
