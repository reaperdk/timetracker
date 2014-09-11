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
    [ServiceKnownType(typeof(Model.UserModel))]
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IWcfContract
    {
        /// <summary>
        /// Initialize roles in database
        /// </summary>
        [OperationContract]
        void InitializeRoles();
        /// <summary>
        /// Initialize categories in database
        /// </summary>
        [OperationContract]
        void InitializeCategories();
        /// <summary>
        /// Initialize statuses in database
        /// </summary>
        [OperationContract]
        void InitializeStatuses();
        /// <summary>
        /// Initialize priorities in database
        /// </summary>
        [OperationContract]
        void InitializePriorities();
        /// <summary>
        /// Initialize types in database
        /// </summary>
        [OperationContract]
        void InitializeTypes();
        /// <summary>
        /// Returns all users from database
        /// </summary>
        /// <returns>All users</returns>
        [OperationContract]
        IEnumerable<UserModel> GetAllUsers();
        /// <summary>
        /// Returns user by user's id
        /// </summary>
        /// <param name="id">Id of desired user</param>
        /// <returns>UserProfile if exist, otherwise null</returns>
        [OperationContract]
        UserModel GetUserById(int id);
        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="user">User's profile</param>
        /// <returns>True if user added, otherwise false</returns>
        [OperationContract]
        bool AddUser(UserModel user);
        /// <summary>
        /// Updates user's profile
        /// </summary>
        /// <param name="user">User's profile</param>
        /// <returns>True if updated, otherwise false</returns>
        [OperationContract]
        bool UpdateUser(UserModel user);
        /// <summary>
        /// Removes user by id
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>True if removed, otherwise false</returns>
        [OperationContract]
        bool RemoveUser(int id);
        /// <summary>
        /// Returns all roles
        /// </summary>
        /// <returns>Roles if found, otherwise null</returns>
        [OperationContract]
        IEnumerable<RoleModel> GetAllRoles();
        /// <summary>
        /// Returns role by id
        /// </summary>
        /// <param name="id">Role's id</param>
        /// <returns>RoleModel if exist, otherwise null</returns>
        [OperationContract]
        RoleModel GetRoleById(int id);
        /// <summary>
        /// Returns all categories
        /// </summary>
        /// <returns>Categories if found, otherwise null</returns>
        [OperationContract]
        IEnumerable<CategoryModel> GetAllCategories();
        /// <summary>
        /// Returns category by id
        /// </summary>
        /// <param name="id">Category's id</param>
        /// <returns>CategoryModel if found, otherwise null</returns>
        [OperationContract]
        CategoryModel GetCategoryById(int id);
        /// <summary>
        /// Return all statuses
        /// </summary>
        /// <returns>Statuses if found, otherwise null</returns>
        [OperationContract]
        IEnumerable<StatusModel> GetAllStatuses();
        /// <summary>
        /// Returns status by id
        /// </summary>
        /// <param name="id">Status's id</param>
        /// <returns>StatusModel if found, otherwise null</returns>
        [OperationContract]
        StatusModel GetStatusById(int id);
        /// <summary>
        /// Returns all priorities
        /// </summary>
        /// <returns>Priorities if found, otherwise null</returns>
        [OperationContract]
        IEnumerable<PriorityModel> GetAllPriorities();
        /// <summary>
        /// Returns priority by id
        /// </summary>
        /// <param name="id">PriorityModel if found, otherwise null</param>
        /// <returns></returns>
        [OperationContract]
        PriorityModel GetPriorityById(int id);
        /// <summary>
        /// Returns all types
        /// </summary>
        /// <returns>Types if found, otherwise null</returns>
        [OperationContract]
        IEnumerable<TypeModel> GetAllTypes();
        /// <summary>
        /// Returns type by id
        /// </summary>
        /// <param name="id">Type's id</param>
        /// <returns>TypeModel if found, otherwise null</returns>
        [OperationContract]
        TypeModel GetTypeById(int id);
    }
}
