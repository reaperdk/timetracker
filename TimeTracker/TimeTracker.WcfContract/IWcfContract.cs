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
        /// <summary>
        /// Returns all users from database
        /// </summary>
        /// <returns>All users</returns>
        [OperationContract]
        IEnumerable<UserProfile> GetAllUsers();
        /// <summary>
        /// Returns user by user's id
        /// </summary>
        /// <param name="id">Id of desired user</param>
        /// <returns>UserProfile if exist, otherwise null</returns>
        [OperationContract]
        UserProfile GetUserById(int id);
        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="user">Username</param>
        [OperationContract]
        bool AddUser(UserProfile user);
        [OperationContract]
        bool UpdateUser(UserProfile user);
        [OperationContract]
        bool RemoveUser(int id);
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
