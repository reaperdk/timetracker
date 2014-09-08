using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.WcfContract
{
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
