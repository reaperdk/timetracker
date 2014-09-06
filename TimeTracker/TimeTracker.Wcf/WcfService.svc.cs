using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TimeTracker.Model;
using TimeTracker.WcfContract;

namespace TimeTracker.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfService : IWcfContract
    {
        public IEnumerable<UserProfile> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void InitializeRoles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<webpages_Roles> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public webpages_Roles GetRoleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
