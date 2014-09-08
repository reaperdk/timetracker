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
        void InitializeCategories();
        void InitializeStatuses();
        void InitializePriorities();
        void InitializeTypes();
        IEnumerable<UserProfile> GetAllUsers();
        UserProfile GetUserById(int id);
        void CreateUser(UserProfile user, int roleId);
        void UpdateUser(UserProfile user);
        void RemoveUser(int id);
        IEnumerable<webpages_Roles> GetAllRoles();
        webpages_Roles GetRoleById(int id);
        IEnumerable<CategoryModel> GetAllCategories();
        CategoryModel GetCategoryById(int id);
        IEnumerable<StatusModel> GetAllStatuses();
        StatusModel GetStatusById(int id);
        IEnumerable<PriorityModel> GetAllPriorities();
        PriorityModel GetPriorityById(int id);
        IEnumerable<TypeModel> GetAllTypes();
        TypeModel GetTypeById(int id);
    }
}
