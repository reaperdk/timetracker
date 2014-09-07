using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TimeTracker.Model;
using TimeTracker.WcfContract;
using TimeTracker.ClassService;

namespace TimeTracker.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfService : IWcfContract
    {
        //These service classes will be used to connect to database and do necessary things
        private readonly IUsersService _usersService;
        private readonly IRolesService _rolesService;

        public WcfService(IUsersService usersService, IRolesService rolesService)
	    {
            _usersService = usersService;
            _rolesService = rolesService;
	    }

        public IEnumerable<UserProfile> GetAllUsers()
        {
            return _usersService.GetAll();
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
