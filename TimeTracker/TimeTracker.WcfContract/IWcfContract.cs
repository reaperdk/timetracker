using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.WcfContract
{
    [ServiceKnownType(typeof(Model.CategoryModel))]
    [ServiceKnownType(typeof(Model.MembershipModel))]
    [ServiceKnownType(typeof(Model.PriorityModel))]
    [ServiceKnownType(typeof(Model.ProjectModel))]
    [ServiceKnownType(typeof(Model.RoleModel))]
    [ServiceKnownType(typeof(Model.SlotModel))]
    [ServiceKnownType(typeof(Model.StatusModel))]
    [ServiceKnownType(typeof(Model.TaskModel))]
    [ServiceKnownType(typeof(Model.TypeModel))]
    [ServiceKnownType(typeof(Model.UserModel))]
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IWcfContract
    {
        [OperationContract]
        void InitializeDatabase();
        [OperationContract]
        void InitializeRoles();
        [OperationContract]
        void InitializeCategories();
        [OperationContract]
        void InitializeStatuses();
        [OperationContract]
        void InitializePriorities();
        [OperationContract]
        void InitializeTypes();

        [OperationContract]
        IEnumerable<UserModel> GetAllUsers();
        [OperationContract]
        UserModel GetUserById(int id);
        [OperationContract]
        string GetSaltByUserName(string userName);
        [OperationContract]
        void SetSalt(string userName, string salt);
        [OperationContract]
        bool UpdateCreatedUser(UserModel user, string salt);
        [OperationContract]
        bool UpdateUser(UserModel user);

        [OperationContract]
        IEnumerable<ProjectModel> GetAllProjects();
        [OperationContract]
        ProjectModel GetProjectById(int id);
        [OperationContract]
        bool CreateProject(ProjectModel project);
        [OperationContract]
        bool UpdateProject(ProjectModel project);
        [OperationContract]
        bool DeleteProject(int id);

        [OperationContract]
        IEnumerable<TaskModel> GetAllTasks();
        [OperationContract]
        TaskModel GetTaskById(int id);
        [OperationContract]
        bool CreateTask(TaskModel task);
        [OperationContract]
        bool UpdateTask(TaskModel task);
        [OperationContract]
        bool DeleteTask(int id);

        [OperationContract]
        IEnumerable<SlotModel> GetAllSlots();
        [OperationContract]
        SlotModel GetSlotById(int id);
        [OperationContract]
        bool CreateSlot(SlotModel slot);
        [OperationContract]
        bool UpdateSlot(SlotModel slot);
        [OperationContract]
        bool DeleteSlot(int id);

        [OperationContract]
        IEnumerable<RoleModel> GetAllRoles();
        [OperationContract]
        RoleModel GetRoleById(int id);
        [OperationContract]
        IEnumerable<CategoryModel> GetAllCategories();
        [OperationContract]
        CategoryModel GetCategoryById(int id);
        [OperationContract]
        IEnumerable<StatusModel> GetAllStatuses();
        [OperationContract]
        StatusModel GetStatusById(int id);
        [OperationContract]
        IEnumerable<PriorityModel> GetAllPriorities();
        [OperationContract]
        PriorityModel GetPriorityById(int id);
        [OperationContract]
        IEnumerable<TypeModel> GetAllTypes();
        [OperationContract]
        TypeModel GetTypeById(int id);
    }
}
