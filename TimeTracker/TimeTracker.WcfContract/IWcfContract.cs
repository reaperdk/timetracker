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
    [ServiceKnownType(typeof(Model.OAuthMembershipModel))]
    [ServiceKnownType(typeof(Model.PriorityModel))]
    [ServiceKnownType(typeof(Model.ProjectModel))]
    [ServiceKnownType(typeof(Model.RoleModel))]
    [ServiceKnownType(typeof(Model.SlotModel))]
    [ServiceKnownType(typeof(Model.StatusModel))]
    [ServiceKnownType(typeof(Model.TaskModel))]
    [ServiceKnownType(typeof(Model.TypeModel))]
    [ServiceKnownType(typeof(Model.UserProfile))]
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IWcfContract
    {
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
        IEnumerable<UserProfile> GetAllUsers();
        [OperationContract]
        UserProfile GetUserById(int id);
        [OperationContract]
        void CreateUser(UserProfile user);
        [OperationContract]
        void UpdateUser(UserProfile user);
        [OperationContract]
        void RemoveUser(int id);
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
