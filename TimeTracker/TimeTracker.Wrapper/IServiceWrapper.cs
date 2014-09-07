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
        void InitializeRoles();
        IEnumerable<UserProfile> GetAllUsers();
        UserProfile GetUserById(int id);
        void CreateUser(UserProfile user, int roleId);
        void UpdateUser(UserProfile user);
        void RemoveUser(int id);
        IEnumerable<webpages_Roles> GetAllRoles();
        webpages_Roles GetRoleById(int id);
    }
}
