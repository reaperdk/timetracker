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
        void InitializeDatabase();
        void InitializeRoles();
        void InitializeCategories();
        void InitializeStatuses();
        void InitializePriorities();
        void InitializeTypes();

        IEnumerable<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        string GetSaltByUserName(string userName);
        void SetSalt(string userName, string salt);
        bool UpdateCreatedUser(UserModel user, string salt);
        bool UpdateUser(UserModel user);

        IEnumerable<ProjectModel> GetAllProjects();
        ProjectModel GetProjectById(int id);
        bool CreateProject(ProjectModel project);
        bool UpdateProject(ProjectModel project);
        bool DeleteProject(int id);

        IEnumerable<RoleModel> GetAllRoles();
        RoleModel GetRoleById(int id);
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
