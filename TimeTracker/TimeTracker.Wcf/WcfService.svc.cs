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
        private readonly ICategoriesService _categoriesService;
        private readonly IPrioritiesService _prioritiesService;
        private readonly ITypesService _typesService;
        private readonly IUsersRolesService _usersRolesService;
        private readonly IStatusesService _statusesService;

        public WcfService(
            IUsersService usersService, 
            IRolesService rolesService,
            ICategoriesService categoriesService,
            IPrioritiesService prioritiesService,
            ITypesService typesService,
            IUsersRolesService usersRolesService,
            IStatusesService statusesService)
	    {
            _usersService = usersService;
            _rolesService = rolesService;
            _categoriesService = categoriesService;
            _prioritiesService = prioritiesService;
            _typesService = typesService;
            _usersRolesService = usersRolesService;
            _statusesService = statusesService;
	    }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _usersService.GetAll();
        }

        public bool AddUser(UserModel user)
        {
            //_usersService.Add(user);
            //TODO: _usersService.Add should return value if function finished succesfully. Now it is void
            return true;
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return _categoriesService.GetAll();
        }

        public IEnumerable<PriorityModel> GetAllPriorities()
        {
            return _prioritiesService.GetAll();
        }

        public IEnumerable<RoleModel> GetAllRoles()
        {
            return _rolesService.GetAll();
        }

        public IEnumerable<StatusModel> GetAllStatuses()
        {
            return _statusesService.GetAll();
        }

        public IEnumerable<TypeModel> GetAllTypes()
        {
            return _typesService.GetAll();
        }

        public CategoryModel GetCategoryById(int id)
        {
            return _categoriesService.Get(id);
        }

        public PriorityModel GetPriorityById(int id)
        {
            return _prioritiesService.Get(id);
        }

        public RoleModel GetRoleById(int id)
        {
            return _rolesService.GetById(id);
        }

        public StatusModel GetStatusById(int id)
        {
            return _statusesService.Get(id);
        }

        public TypeModel GetTypeById(int id)
        {
            return _typesService.Get(id);
        }

        public UserModel GetUserById(int id)
        {
            return _usersService.GetById(id);
        }

        public void InitializeCategories()
        {
            _categoriesService.InitializeCategories();
        }

        public void InitializePriorities()
        {
            _prioritiesService.InitializePriorities();
        }

        public void InitializeRoles()
        {
            _rolesService.InitializeRoles();
        }

        public void InitializeStatuses()
        {
            _statusesService.InitializeStatuses();
        }

        public void InitializeTypes()
        {
            _typesService.InitializeTypes();
        }

        public bool RemoveUser(int id)
        {
            //_usersService.Remove(id);
            //TODO: _usersService.Remove should return boolean answer
            return true;
        }

        public bool UpdateUser(UserModel user)
        {
            _usersService.Update(user);
            //TODO: _usersService.Update should return boolean answer
            return true;
        }
    }
}
