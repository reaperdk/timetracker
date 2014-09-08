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

        public void CreateUser(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriorityModel> GetAllPriorities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleModel> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusModel> GetAllStatuses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeModel> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public PriorityModel GetPriorityById(int id)
        {
            throw new NotImplementedException();
        }

        public RoleModel GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public StatusModel GetStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public TypeModel GetTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void InitializeCategories()
        {
            throw new NotImplementedException();
        }

        public void InitializePriorities()
        {
            throw new NotImplementedException();
        }

        public void InitializeRoles()
        {
            throw new NotImplementedException();
        }

        public void InitializeStatuses()
        {
            throw new NotImplementedException();
        }

        public void InitializeTypes()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserProfile user)
        {
            throw new NotImplementedException();
        }
    }
}
