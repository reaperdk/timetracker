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
        void InitializeRoles();
        [OperationContract]
        IEnumerable<RoleModel> GetAllRoles();
        [OperationContract]
        RoleModel GetRoleById(int id);
    }
}
